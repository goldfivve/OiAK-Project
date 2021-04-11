def read_file(file, matrix_list):
    values_list = []
    first_line_input = []
    with open(file, "r") as graph_file:
        first_line = graph_file.readline().replace("\n", "").split(" ")
        for item in first_line:
            first_line_input.append(int(item))
        print(first_line_input)
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


if __name__ == '__main__':
    matrix_graph_list = []

    first_line_int = read_file("graph_simple.txt", matrix_graph_list)
    vertex_number = first_line_int[0]
    edge_number = first_line_int[1]
    start_vertex = first_line_int[2]
    print(matrix_graph_list)

    graph_matrix = create_adjacency_matrix(matrix_graph_list, vertex_number, edge_number)

    print(graph_matrix)
