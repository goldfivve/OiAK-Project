import math
from time import perf_counter_ns

positive_infinity = math.inf


def read_file(file, matrix_list):
    values_list = []
    first_line_input = []
    with open(file, "r") as graph_file:
        first_line = graph_file.readline().replace("\n", "").split(" ")
        for item in first_line:
            first_line_input.append(int(item))

        for line in graph_file:
            split_line = line.replace("\n", "").split(" ")
            for values in split_line:
                value_as_int = int(values)
                values_list.append(value_as_int)
            matrix_list.append(list(values_list))
            values_list.clear()
    return first_line_input


def create_adjacency_matrix(entered_graph, vertices, edges):
    new_matrix = []
    for vertex in range(0, vertices):  # iterate every vertex that exists
        temp_list = [0] * vertices  # create empty list filled with 0 equivalent with vertices quantity
        for edge in range(0, edges):  # iterate every connection on list
            if entered_graph[edge][0] == vertex + 1:  # check if this is connection to checked vertex
                temp_list[entered_graph[edge][1] - 1] = entered_graph[edge][2]  # if yes, then set value
        new_matrix.append(temp_list)  # add created list to all lists
    return new_matrix  # return created matrix


def create_adjacency_list(entered_graph, vertices, edges):
    new_dict = {}
    for vertex in range(0, vertices):
        for edge in range(0, edges):
            temp_list = []
            if vertex not in new_dict:
                new_dict[vertex] = []
            if entered_graph[edge][0] == vertex + 1:
                temp_list.append(entered_graph[edge][1])
                temp_list.append(entered_graph[edge][2])
                new_dict[vertex].append(temp_list)
    return new_dict


def prepare_dijkstra(vertices, start):
    q = [vertex for vertex in range(0, vertices)]  # graph vertices
    s = []
    d = [positive_infinity] * vertices
    d[start] = 0
    p = [-1] * vertices
    return q, s, d, p


def dijkstra_on_adjacency_matrix(graph, vertices, start):
    q, s, d, p = prepare_dijkstra(vertices, start)

    while len(q) > 0:
        min_cost_index = 0
        min_cost = positive_infinity

        for edge_cost in range(0, vertices):
            if d[edge_cost] < min_cost and edge_cost in q:
                min_cost_index = edge_cost
                min_cost = d[edge_cost]

        s.append(min_cost_index)
        q.remove(min_cost_index)

        for vertex in range(0, vertices):
            if graph[min_cost_index][vertex] != 0 and vertex in q:
                if d[vertex] > d[min_cost_index] + graph[min_cost_index][vertex]:
                    d[vertex] = d[min_cost_index] + graph[min_cost_index][vertex]
                    p[vertex] = min_cost_index


def dijkstra_on_adjacency_list(graph, vertices, start):
    q, s, d, p = prepare_dijkstra(vertices, start)
    while len(q) > 0:
        min_cost_index = 0
        min_cost = positive_infinity

        for edge_cost in range(0, vertices):
            if d[edge_cost] < min_cost and edge_cost in q:
                min_cost_index = edge_cost
                min_cost = d[edge_cost]

        s.append(min_cost_index)
        q.remove(min_cost_index)

        len(graph[min_cost_index])

        for i in range(len(graph[min_cost_index])):
            minimal_cost = d[graph[min_cost_index][i][0] - 1]
            actual_cost = d[min_cost_index] + graph[min_cost_index][i][1]
            if graph[min_cost_index][i][0] - 1 in q:
                if minimal_cost > actual_cost:
                    minimal_cost = actual_cost
                    p[graph[min_cost_index][i][0] - 1] = min_cost_index


def prepare_bellman_ford(vertices, start):
    d = [positive_infinity] * vertices
    d[start] = 0
    p = [-1] * vertices
    return d, p


def bellman_ford_on_adjacency_matrix(graph, vertices, start):
    d, p = prepare_bellman_ford(vertices, start)
    for iteration in range(0, vertices - 1):
        test = True
        for vertex in range(0, vertices):
            for edge in range(0, vertices):
                if graph[vertex][edge] != 0:
                    if d[edge] <= d[vertex] + graph[vertex][edge]:
                        continue

                    test = False
                    d[edge] = d[vertex] + graph[vertex][edge]
                    p[edge] = vertex

        if test:
            return True
    for vertex in range(0, vertices):
        for edge in range(0, vertices):
            if d[edge] > d[vertex] + graph[vertex][edge]:
                return False
    return True


def bellman_ford_on_adjacency_list(graph, vertices, start):
    d, p = prepare_bellman_ford(vertices, start)
    for iteration in range(0, vertices - 1):
        test = True
        for vertex in range(0, vertices):
            for i in range(len(graph[vertex])):

                if d[graph[vertex][i][0] - 1] <= d[vertex] + graph[vertex][i][1]:
                    continue

                test = False
                d[graph[vertex][i][0] - 1] = d[vertex] + graph[vertex][i][1]
                p[graph[vertex][i][0] - 1] = vertex

        if test:
            return True
    for vertex in range(0, vertices):
        for i in range(len(graph[vertex])):
            if d[graph[vertex][i][0] - 1] > d[vertex] + graph[vertex][graph[vertex][i][1]]:
                return False
    return True


def prepare_floyd_warshall(vertices):
    d = [[positive_infinity for val in range(0, vertices)] for vertex in range(0, vertices)]
    return d


def floyd_warshall_path_iteration(vertices, d):
    for iteration in range(0, vertices):

        for vertex in range(0, vertices):
            for edge in range(0, vertices):

                if d[vertex][edge] > d[vertex][iteration] + d[iteration][edge]:
                    d[vertex][edge] = d[vertex][iteration] + d[iteration][edge]
    return d


def floyd_warshall_on_adjacency_matrix(graph, vertices):
    d = prepare_floyd_warshall(vertices)

    for vertex in range(0, vertices):
        d[vertex][vertex] = 0
        for edge in range(0, vertices):
            d[vertex][edge] = graph[vertex][edge]

    floyd_warshall_path_iteration(vertices, d)

    return d


def floyd_warshall_on_adjacency_list(graph, vertices):
    d = prepare_floyd_warshall(vertices)

    for vertex in range(0, vertices):
        d[vertex][vertex] = 0
        for edge in range(len(graph[vertex])):
            d[vertex][graph[vertex][edge][0] - 1] = graph[vertex][edge][1]

    floyd_warshall_path_iteration(vertices, d)

    return d


def time_measure(function, *args, test_number=1):
    time_sum = 0

    for i in range(0, 10):
        for j in range(0, test_number):
            start = perf_counter_ns()
            function(*args)
            end = perf_counter_ns()
            time_sum = time_sum + (end - start)

        print(time_sum / test_number, " ns")
        time_sum = 0


def wait():
    input("Press any key to start the algorithm...")


if __name__ == '__main__':
    matrix_graph_list = []

    first_line_int = read_file("graph_1500.txt", matrix_graph_list)
    vertex_number = first_line_int[0]
    edge_number = first_line_int[1]
    start_vertex = first_line_int[2]

    graph_matrix = create_adjacency_matrix(matrix_graph_list, vertex_number, edge_number)
    # graph_list = create_adjacency_list(matrix_graph_list, vertex_number, edge_number)

    wait()

    dijkstra_on_adjacency_matrix(graph_matrix, vertex_number, start_vertex)
    # bellman_ford_on_adjacency_matrix(graph_matrix, vertex_number, start_vertex)
    # floyd_warshall_on_adjacency_matrix(graph_matrix, vertex_number)

    # dijkstra_on_adjacency_list(graph_matrix, vertex_number, start_vertex)
    # bellman_ford_on_adjacency_list(graph_list, vertex_number, start_vertex)
    # floyd_warshall_on_adjacency_list(graph_list, vertex_number)

    # time_measure(dijkstra_on_adjacency_matrix, graph_matrix, vertex_number, start_vertex - 1, test_number=1000)
    # time_measure(bellman_ford_on_adjacency_matrix, graph_matrix, vertex_number, start_vertex - 1, test_number=1000)
    # time_measure(floyd_warshall_on_adjacency_matrix, graph_matrix, vertex_number, test_number=1000)

    # time_measure(dijkstra_on_adjacency_list, graph_list, vertex_number, start_vertex - 1, test_number=1000)
    # time_measure(bellman_ford_on_adjacency_list, graph_list, vertex_number, start_vertex - 1, test_number=1000)
    # time_measure(floyd_warshall_on_adjacency_list, graph_list, vertex_number, test_number=1000)
