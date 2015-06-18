/**
 * Created by Michael on 6/17/2015.
 *
 * This class represents an individual cell.
 */
public class Cell {
    int time;

    public Cell() {
        time = 1;
    }

    public Cell(int time) {
        this.time = time;
    }

    @Override
    public String toString() {
        return "" + time;
    }
}
