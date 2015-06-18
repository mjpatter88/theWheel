import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

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
 * A value of "A" is the source.
 * A value of "B" is the destination.
 */
public class GridMap {
    int numRows;
    int numCols;
    Cell cells[][];

    public GridMap() {
        // Create a default map of 63 x 40 cells
        numCols = 63;
        numRows = 40;
        initializeBlankMap();
    }

    public GridMap(String fileName) {
        // Create a map based on the input file
        Scanner inpScanner = null;
        File inpFile = new File(fileName);
        try {
            inpScanner = new Scanner(inpFile);
            // Scan the first few lines to get dimensions and make sure it's a valid file.
            String line = inpScanner.nextLine();
            if(!line.equals("MapConfig")) {
                throw new RuntimeException("First line must contain the string \"MapConfig\".");
            }
            line = inpScanner.nextLine();
            if(!line.substring(0, 5).equals("COLS:")) {
                throw new RuntimeException("Next line must contain the string \"COLS:\".");
            }
            numCols = Integer.parseInt(line.substring(6, line.length()));
            line = inpScanner.nextLine();
            if(!line.substring(0, 5).equals("ROWS:")) {
                throw new RuntimeException("Next line must contain the string \"ROWS:\".");
            }
            numRows = Integer.parseInt(line.substring(6, line.length()));

            // Create and initialize map to default values.
            initializeBlankMap();

            while(inpScanner.hasNext()) {
                line = inpScanner.nextLine();
                if(line.length()==0) {
                    continue;
                }
                int rowIndex = Integer.parseInt(line.substring(line.indexOf('<') + 1, line.indexOf(',')));
                int colIndex = Integer.parseInt(line.substring(line.indexOf(',') + 1, line.indexOf('>')));
                int time = Integer.parseInt(line.substring(line.indexOf(' ') + 1));
                cells[rowIndex][colIndex] = new Cell(time);
            }
        }
        catch (FileNotFoundException e) {
            System.out.println("File \""+ fileName + "\" not found!");
            System.out.println("Falling back to default map.");
            numCols = 63;
            numRows = 40;
            initializeBlankMap();
        }
        catch (RuntimeException e) {
            System.out.println("Problem with the MapConfig file.");
            System.out.println(e.getMessage());
            System.out.println("Falling back to default map.");
            numCols = 63;
            numRows = 40;
            initializeBlankMap();
        }
        finally {
            if(inpScanner!=null) {
                inpScanner.close();
            }
        }
    }

    public void initializeBlankMap() {
        cells = new Cell[numRows][numCols];
        for(int i=0; i<numRows; i++) {
            for(int j=0; j<numCols; j++) {
                cells[i][j] = new Cell(1); // Default cell value
            }
        }
    }

    @Override
    public String toString() {
        String toReturn = "COLS: " + numCols + "\n";
        toReturn += "ROWS: " + numRows + "\n";
        for(int i=0; i<numRows; i++) {
            for(int j=0; j<numCols; j++) {
                toReturn += cells[i][j] + " ";
            }
            toReturn += "\n";
        }
        return toReturn;
    }


}
