/**
 *
 * Created by Michael on 6/13/2015.
 *
 * This project implements several path-finding algorithms and an interface to use them.
 *
 * Algorithms:
 * A*
 * Dijkstra's
 * Breadth First Search
 * Depth First Search
 * Bellman-Ford
 * Floyd-Warshall
 * Johnson's
 *
 */

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.HBox;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;
import javafx.scene.text.Text;
import javafx.stage.Stage;



public class Main extends Application
{
    Display display;
    @Override
    public void start(Stage primaryStage) {
        primaryStage.setTitle("Pathfinding");

        // Set the layout of the window
        GridPane grid = new GridPane();
        grid.setHgap(10);
        grid.setVgap(10);
        grid.setPadding(new Insets(25, 25, 25, 25));
        grid.requestFocus();

        // Add text and algorithm buttons
        addTextAndButtons(grid);

        // Create grid map and add custom canvas
        GridMap map = new GridMap("DefaultMap.txt");
        System.out.println(map);
        display = new Display(map);
        grid.add(display, 0, 2, 4, 1);

        Scene scene = new Scene(grid, 680, 630);
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    private void addTextAndButtons(GridPane grid) {
        Text title = new Text("Pathfinders: ");
        title.setFont(Font.font("Tahoma", FontWeight.NORMAL, 20));
        HBox hbTitle = new HBox(10);
        hbTitle.setAlignment(Pos.CENTER);
        hbTitle.getChildren().add(title);
        grid.add(hbTitle, 0, 0, 1, 1);

        Button btnA = new Button("A*");
        btnA.setMinWidth(150.0);
        btnA.setMinHeight(50.0);
        btnA.setOnAction((ActionEvent e) -> {
            display.paintPath(Algorithms.aStar(display.map));
        });
        grid.add(btnA, 1, 0, 1, 1);

        Button btnDijkstra = new Button("Dijkstra's");
        btnDijkstra.setMinWidth(150.0);
        btnDijkstra.setMinHeight(50.0);
        btnDijkstra.setOnAction((ActionEvent e) -> {
            display.paintPath(Algorithms.dijkstra(display.map));
        });
        grid.add(btnDijkstra, 2, 0, 1, 1);

        Button btnBFS = new Button("Breadth First Search");
        btnBFS.setMinWidth(150.0);
        btnBFS.setMinHeight(50.0);
        btnBFS.setOnAction((ActionEvent e) -> {
            display.paintPath(Algorithms.breadthFirstSearch(display.map));
        });
        grid.add(btnBFS, 3, 0, 1, 1);

        Button btnDFS = new Button("Depth First Search");
        btnDFS.setMinWidth(150.0);
        btnDFS.setMinHeight(50.0);
        btnDFS.setOnAction((ActionEvent e) -> {
            display.paintPath(Algorithms.depthFirstSearch(display.map));
        });
        grid.add(btnDFS, 0, 1, 1, 1);

        Button btnBellmanFord = new Button("Bellman-Ford");
        btnBellmanFord.setMinWidth(150.0);
        btnBellmanFord.setMinHeight(50.0);
        btnBellmanFord.setOnAction((ActionEvent e) -> {
            display.paintPath(Algorithms.bellmanFord(display.map));
        });
        grid.add(btnBellmanFord, 1, 1, 1, 1);

        Button btnFloydWarshall = new Button("Floyd-Warshall");
        btnFloydWarshall.setMinWidth(150.0);
        btnFloydWarshall.setMinHeight(50.0);
        btnFloydWarshall.setOnAction((ActionEvent e) -> {
            display.paintPath(Algorithms.floydWarshall(display.map));
        });
        grid.add(btnFloydWarshall, 2, 1, 1, 1);

        Button btnJohnson = new Button("Johnson's");
        btnJohnson.setMinWidth(150.0);
        btnJohnson.setMinHeight(50.0);
        btnJohnson.setOnAction((ActionEvent e) -> {
            display.paintPath(Algorithms.johnson(display.map));
        });
        grid.add(btnJohnson, 3, 1, 1, 1);

        // Add loading and generating buttons
        Button btnLoadMap = new Button("Load Map");
        btnLoadMap.setMinWidth(150.0);
        btnLoadMap.setMinHeight(50.0);
        grid.add(btnLoadMap, 1, 3, 1, 1);

        Button btnGenerateMap = new Button("Generate Map");
        btnGenerateMap.setMinWidth(150.0);
        btnGenerateMap.setMinHeight(50.0);
        grid.add(btnGenerateMap, 2, 3, 1, 1);

    }

    public static void main(String[] args) {
        launch(args);
    }
}
