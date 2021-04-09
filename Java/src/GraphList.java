import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.PriorityQueue;
import java.util.Scanner;

class PairComparator implements Comparator<Pair> {

    public int compare(Pair pair1, Pair pair2) {
        if (pair1.weight < pair2.weight)
            return -1;
        if (pair1.weight > pair2.weight)
            return 1;
        return 0;
    }
}

public class GraphList {
    int verticesNumber, edgesNumber, startingVertex;
    int INF = Integer.MAX_VALUE;
    ArrayList<ArrayList<Pair>> adjacencyList;

    int[] dist;
    boolean[] visited;

    PriorityQueue<Pair> priorityQueue;

    GraphList() {
        priorityQueue = new PriorityQueue<Pair>();

        createAdjacencyList();

        dist = new int[verticesNumber+1];
        visited = new boolean[verticesNumber+1];

        for(int i=0; i<=verticesNumber; i++){
            dist[i] = INF;
            visited[i] = false;
        }

        priorityQueue = new
                PriorityQueue<Pair>(edgesNumber, new PairComparator());

        System.out.println(verticesNumber + " " + edgesNumber);

    }

    private void createAdjacencyList() {
        try {
            File myObj = new File("graph_simple.txt");
            Scanner myReader = new Scanner(myObj);

            boolean firstLine = true;

            while (myReader.hasNextLine()) {
                String data = myReader.nextLine();

                String[] splited = data.split(" ");

                if(firstLine) {
                    verticesNumber = Integer.parseInt(splited[0]);
                    edgesNumber = Integer.parseInt(splited[1]);
                    startingVertex = Integer.parseInt(splited[2]);
                    firstLine = false;

                    adjacencyList = new ArrayList<>(verticesNumber+1);
                    for(int i = 0; i <= verticesNumber ; i++)  {
                        adjacencyList.add(new ArrayList<Pair>());
                    }
                    continue;
                }

                int firstVertex = Integer.parseInt(splited[0]);
                int secondVertex = Integer.parseInt(splited[1]);
                int edgeWeight = Integer.parseInt(splited[2]);

                adjacencyList.get(firstVertex).add(new Pair(secondVertex, edgeWeight));
                adjacencyList.get(secondVertex).add(new Pair(firstVertex, edgeWeight));

            }
            myReader.close();
        } catch (FileNotFoundException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
    }

    public void clearDistAndVisited() {
        for(int i=0; i<=verticesNumber; i++){
            dist[i] = INF;
            visited[i] = false;
        }
    }

    public void dijkstra() {
        dist[startingVertex] = 0;  //distance from startingVertex to itself is 0
        priorityQueue.add(new Pair(startingVertex, 0));

        while (!priorityQueue.isEmpty()) {
            int u = (priorityQueue.poll()).vertex;

            if (visited[u]) {
                continue; //if this vertex is already visited, skip the rest of the loop
            }

            visited[u] = true;

            for (int i = 0; i < adjacencyList.get(u).size(); i++) {
                int v = adjacencyList.get(u).get(i).vertex;
                int c = adjacencyList.get(u).get(i).weight;

                if (dist[v] > dist[u] + c) {
                    dist[v] = dist[u] + c;
                    priorityQueue.add(new Pair(v, dist[v]));
                }
            }
        }
    }

    public void BellmanFord() {
        return;
    }

    public void FloydWarshall() {
        return;
    }

    public void showDist() {
        for(int i=1; i<=verticesNumber; i++){
            System.out.println(dist[i]);
        }
    }

    public void showAdjacencyList() {
        for(int i=1; i<=verticesNumber; i++) {
            System.out.print(i + ": ");
            for(int j=0; j<adjacencyList.get(i).size(); j++){
                System.out.print(adjacencyList.get(i).get(j).vertex + " ");
            }
            System.out.println("");
        }
    }
}
