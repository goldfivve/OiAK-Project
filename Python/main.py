import math


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


def dijkstra_on_adjacency_matrix(graph, vertices, start):
    q = [vertex for vertex in range(0, vertices)]  # graph vertices
    s = []
    positive_infinity = math.inf
    d = [positive_infinity for vertex in range(0, vertices)]
    d[start] = 0
    p = [-1 for vertex in range(0, vertices)]

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


def bellman_ford_on_adjacency_matrix(graph, vertices, start):
    positive_infinity = math.inf
    d = [positive_infinity for vertex in range(0, vertices)]
    d[start] = 0
    p = [-1 for vertex in range(0, vertices)]

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


def floyd_warshall_on_adjacency_matrix(graph, vertices):
    positive_infinity = math.inf
    d = [[positive_infinity for val in range(0, vertices)] for vertex in range(0, vertices)]

    for vertex in range(0, vertices - 1):
        d[vertex][vertex] = 0
        for edge in range(0, vertices):
            d[vertex][edge] = graph[vertex][edge]

    for iteration in range(0, vertices):

        for vertex in range(0, vertices):
            for edge in range(0, vertices):

                if d[vertex][edge] > d[vertex][iteration] + d[iteration][edge]:
                    d[vertex][edge] = d[vertex][iteration] + d[iteration][edge]
    return d


if __name__ == '__main__':
    matrix_graph_list = []

    first_line_int = read_file("graph_simple.txt", matrix_graph_list)
    vertex_number = first_line_int[0]
    edge_number = first_line_int[1]
    start_vertex = first_line_int[2]

    graph_matrix = create_adjacency_matrix(matrix_graph_list, vertex_number, edge_number)
    graph_list = create_adjacency_list(matrix_graph_list, vertex_number, edge_number)
    dijkstra_on_adjacency_matrix(graph_matrix, vertex_number, start_vertex - 1)
    bellman_ford_on_adjacency_matrix(graph_matrix, vertex_number, start_vertex - 1)
    floyd_warshall_on_adjacency_matrix(graph_matrix, vertex_number, start_vertex - 1)