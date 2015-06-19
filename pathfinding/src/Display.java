/**
 * Created by Michael on 6/16/2015.
 *
 * This class extends the Canvas class to draw the grid on which algorithms are displayed.
 */

import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;
import javafx.scene.paint.Paint;

import java.util.ArrayList;


public class Display extends Canvas
{
    GridMap map;
    int cellWidth = 10;
    int cellHeight = 10;

    public Display(GridMap map) {
        super();
        this.map = map;
        // +1 is needed to have room for the border all the way around
        this.setHeight((cellHeight * map.numRows) + 1);
        this.setWidth((cellWidth * map.numCols) + 1);
        init();
    }



    public void init() {
        GraphicsContext gc = getGraphicsContext2D();
        gc.setFill(Color.LIGHTGRAY);
        gc.fillRect(0, 0, getWidth(), getHeight());

        // Draw the grid lines
        gc.setStroke(Color.rgb(0, 149, 182, 1.0));
        gc.setLineWidth(1.0);
        // Horizontal Lines (plus borders)
        for(int i=0; i<map.numRows + 1; i++) {
            // 0.5 offset so we get sharp single pixel lines
            double coord = 0.5 + (i * cellHeight);
            gc.strokeLine(0, coord, getWidth(), coord);
        }
        // Vertical Lines (plus borders)
        for(int i=0; i<map.numCols + 1; i++) {
            // 0.5 offset so we get sharp single pixel lines
            double coord = 0.5 + (i * cellWidth);
            gc.strokeLine(coord, 0, coord, getHeight());
        }

        // Draw the map features
        for (int i = 0; i < map.numRows; i++) {
            for (int j = 0; j < map.numCols; j++) {
                if (map.cells[i][j].property == 'A') {
                    // shade the cell bright blue
                    paintCell(i, j, Color.rgb(0, 127, 255, 1.0));
                } else if (map.cells[i][j].property == 'B') {
                    // shade the cell bright gold
                    paintCell(i, j, Color.rgb(255, 240, 0, 1.0));
                } else if (map.cells[i][j].property == 'W') {
                    // shade the cell dark gray/brown
                    paintCell(i, j, Color.rgb(79, 58, 60, 1.0));
                } else {
                    // shade the cell based on the "time" value (shades of brown)
                    int time = map.cells[i][j].time;
                    if (time > 1) {
                        double opacity = 0.1 * map.cells[i][j].time;
                        paintCell(i, j, Color.rgb(100, 65, 23, opacity));
                    }
                }
            }
        }
    }

    public void paintPath(ArrayList<Cell> path) {

    }

    private void paintCell(int rowNum, int colNum, Paint color) {
        GraphicsContext gc = getGraphicsContext2D();
        double topLeftY = 1 + (rowNum * cellHeight); // Add 1.5 to not overwrite the border
        double topLeftX = 1 + (colNum * cellWidth);
        gc.setFill(color);
        gc.fillRect(topLeftX, topLeftY, cellWidth - 1, cellHeight - 1); // Sub 1 to not overwrite the border
    }
}
