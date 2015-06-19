/**
 * Created by Michael on 6/17/2015.
 *
 * This class represents an individual cell.
 */
public class Cell {
    int time;
    char property;
    int rowIndex;
    int colIndex;

    public Cell(int rowIndex, int colIndex) {
        time = 1;
        this.property = 0;
        this.rowIndex = rowIndex;
        this.colIndex = colIndex;
    }

    public Cell(int time, int rowIndex, int colIndex) {
        this.time = time;
        this.property = 0;
        this.rowIndex = rowIndex;
        this.colIndex = colIndex;
    }

    public Cell(char property, int rowIndex, int colIndex) {
        this.property = property;
        this.rowIndex = rowIndex;
        this.colIndex = colIndex;
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
