public class Main {

    public static void main(String[] args) {
        System.out.println("Graph List");

        GraphList graphList = new GraphList();
        graphList.showAdjacencyList();
        graphList.dijkstra();
        graphList.showDist();
        graphList.clearDistAndVisited();

        System.out.println("Graph Matrix");

        GraphMatrix graphMatrix = new GraphMatrix();
        graphMatrix.showAdjacencyMatrix();
        graphMatrix.dijkstra();
        graphMatrix.showDist();
        graphMatrix.clearDistAndVisited();

    }
}
