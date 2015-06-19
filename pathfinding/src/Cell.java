/**
 * Created by Michael on 6/17/2015.
 *
 * This class represents an individual cell.
 */
public class Cell {
    int time;
    char property;

    public Cell() {
        time = 1;
        this.property = 0;
    }

    public Cell(int time) {
        this.time = time;
        this.property = 0;
    }

    public Cell(char property) {
        this.property = property;
    }

    @Override
    public String toString() {
        String toRet = "";
        if(property != 0) {
            toRet += property;
        }
        else {
            toRet += time;
        }
        return toRet;
    }
}
