/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package club.paddle.experience;

import javafx.application.Application;
import static javafx.application.Application.launch;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import model.Member;

/**
 *
 * @author stefa
 */
public class CLUBPADDLEEXPERIENCE extends Application {
   
    
    @Override
    public void start(Stage stage) throws Exception {
      
        FXMLLoader loader = new FXMLLoader(getClass().getResource("PaginaInicio.fxml"));
        Parent root = (Parent) loader.load();
        Member member = null;
        //Le pasamos a la ventana del login la instancia de este Stage, así iremos usando el mismo.
        loader.<PaginaInicioController>getController().initStage(stage);
        
       
        Scene scene = new Scene(root);
        stage.setScene(scene);
        String css = this.getClass().getResource("cpe.css").toExternalForm();
        scene.getStylesheets().add(css);
        stage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
}
