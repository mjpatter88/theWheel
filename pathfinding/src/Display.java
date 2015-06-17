/**
 * Created by Michael on 6/16/2015.
 *
 * This class extends the Canvas class to draw the grid on which algorithms are displayed.
 */

import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.paint.Color;


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
        System.out.println(getWidth());
        init();
    }



    public void init() {
        GraphicsContext gc = getGraphicsContext2D();
        gc.setFill(Color.LIGHTGRAY);
        gc.fillRect(0, 0, getWidth(), getHeight());

        // Draw the grid
        gc.setStroke(Color.DARKCYAN);
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
    }
}
