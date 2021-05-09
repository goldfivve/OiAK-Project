package src;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.PriorityQueue;
import java.util.Scanner;

public class GraphList {
    int verticesNumber, edgesNumber, startingVertex;
    int INF = Integer.MAX_VALUE;
    ArrayList<ArrayList<Pair>> adjacencyList;

    int[] dist;
    boolean[] visited;
    int[] predecessor;
    int[][] dist2D;

    PriorityQueue<Pair> priorityQueue;

    GraphList() {
        priorityQueue = new PriorityQueue<Pair>();

        createAdjacencyList();

        dist = new int[verticesNumber+1];
        visited = new boolean[verticesNumber+1];
        predecessor = new int[verticesNumber+1];
        dist2D = new int[verticesNumber+1][verticesNumber+1];

        for(int i=0; i<=verticesNumber; i++){
            dist[i] = INF;
            visited[i] = false;
            predecessor[i] = -1;
            for(int j=0; j<=verticesNumber; j++) {
                dist2D[i][j] = INF;
            }
        }

        priorityQueue = new
                PriorityQueue<Pair>(edgesNumber, new PairComparator());

        System.out.println(verticesNumber + " " + edgesNumber);

    }

    private void createAdjacencyList() {
        try {
            //File myObj = new File("graph_simple.txt");
            File myObj = new File("graph3.txt");
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

    public void bellmanFord() {
        dist[startingVertex] = 0;
        int v, w;
        for (int k = 0; k < verticesNumber; k++) {
            for (int u = 1; u <= verticesNumber; u++) {
                for (int i = 0; i < adjacencyList.get(u).size(); i++) {
                    v = adjacencyList.get(u).get(i).vertex;
                    w = adjacencyList.get(u).get(i).weight;
                    if (dist[u] + w < dist[v]) {
                        dist[v] = dist[u] + w;
                        predecessor[v] = u;
                    }
                }
            }
        }
    }

    public void floydWarshall() {

        for (int u = 1; u <= verticesNumber; u++) {
            for (int i = 0; i < adjacencyList.get(u).size(); i++) {
                int v = adjacencyList.get(u).get(i).vertex;
                dist2D[u][v] = adjacencyList.get(u).get(i).weight;
            }
        }

        for (int v = 1; v <= verticesNumber; v++) {
            dist2D[v][v] = 0;
        }

        for (int k = 1; k <= verticesNumber; k++) {
            for (int i = 1; i <= verticesNumber; i++) {
                for (int j = 1; j <= verticesNumber; j++) {
                    if (dist2D[i][j] > dist2D[i][k] + dist2D[k][j]) {
                        dist2D[i][j] = dist2D[i][k] + dist2D[k][j];
                    }
                }
            }
        }
    }

    public void showDist() {
        for(int i=1; i<=verticesNumber; i++){
            System.out.print(dist[i] + " ");
        }
        System.out.println();
    }

    public void showDist2D() {
        for(int i=1; i<=verticesNumber; i++) {
            for(int j=1; j<=verticesNumber; j++) {
                System.out.print(dist2D[i][j] + " ");
            }
            System.out.println();
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
