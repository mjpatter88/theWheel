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
    public Display() {
        super();
        init();
    }

    public Display(int width, int height) {
        super(width, height);
        init();
    }

    public void init()
    {
        GraphicsContext gc = getGraphicsContext2D();
        gc.setFill(Color.DARKGRAY);
        gc.fillRect(0, 0, getWidth(), getHeight());

    }
}
