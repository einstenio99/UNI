/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package club.paddle.experience;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.stage.Stage;
import model.Member;

/**
 * FXML Controller class
 *
 * @author stefa
 */
public class VentanaconfirmacionController implements Initializable {

    @FXML
    private Button botonno;
    @FXML
    private Button botonsi;
    
     public void initStage(Stage stage, Member member) {
        stage.setTitle("CLUB PADDLE EXPERIENCE");
        stage.setMaxHeight(170.0);
        stage.setMaxWidth(300.0);
        stage.setMinHeight(170.0);
        stage.setMinWidth(300.0);
     }

    /**
     * Initializes the controller class.
     * @param url
     * @param rb
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    
    
}
