/**
 * Created by Michael on 6/17/2015.
 *
 * This class represents a grid data structure used for pathfinding algorithms and visualizations.
 * It can be initialized to a default map or by an input file.
 *
 * Simple map: Each cell has a value, that is the "time" to enter/exit that cell
 * Complex map: Each cell has 4 values, those are the "time" to cross left, top, right, and bottom edges respectively.
 *
 * A value of "0" represents a wall that is impassable.
 * A value of "A" is the source..
 * A value of "B" is the destination.
 */
public class GridMap {
    int numRows;
    int numCols;

    public GridMap() {
        // Create a default map of 63 x 40 cells
        numCols = 63;
        numRows = 40;
    }


    public GridMap(String fileName) {
        // Create a map based on the input file
    }
}
