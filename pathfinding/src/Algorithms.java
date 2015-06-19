import java.util.ArrayList;

/**
 * Created by Michael on 6/18/2015.
 * Static methods for each of the path-finding algorithms.
 */
public class Algorithms {
    public static ArrayList<Cell> aStar(GridMap map) {
        System.out.println("A*");
        ArrayList<Cell> path = new ArrayList<Cell>();
        path.add(map.cells[0][1]);
        path.add(map.cells[0][2]);
        path.add(map.cells[0][3]);
        path.add(map.cells[0][4]);
        path.add(map.cells[0][5]);
        return path;
    }

    public static ArrayList<Cell> dijkstra(GridMap map) {
        System.out.println("Dijkstra");
        return null;
    }

    public static ArrayList<Cell> breadthFirstSearch(GridMap map) {
        System.out.println("Breadth First Search");
        return null;
    }

    public static ArrayList<Cell> depthFirstSearch(GridMap map) {
        System.out.println("Depth First Search");
        return null;
    }

    public static ArrayList<Cell> bellmanFord(GridMap map) {
        System.out.println("Bellman Ford");
        return null;
    }

    public static ArrayList<Cell> floydWarshall(GridMap map) {
        System.out.println("Floyd Warshall");
        return null;
    }

    public static ArrayList<Cell> johnson(GridMap map) {
        System.out.println("Johnson");
        return null;
    }

}
