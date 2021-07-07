/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package club.paddle.experience;

import DBAcess.ClubDBAccess;
import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.text.Text;
import javafx.stage.Stage;
import model.Booking;
import model.Member;

/**
 * FXML Controller class
 *
 * @author stefa
 */
public class PantallaprincipalController implements Initializable {

    @FXML
    private Button reservarpista;
    @FXML
    private Button vermisreservas;
    @FXML
    private Button eliminarunareserva;
    @FXML
    private Button cerrarsesion;
    
    private Stage primaryStage;
    
    private ClubDBAccess clubDB;
    
    private Member loggedMember;
    private boolean consulta;
    private ObservableList<Booking> observableBookingUsuario = FXCollections.observableArrayList();
  
    private Member memberLogged;
    @FXML
    private Text textbienvenida;
    @FXML
    private ImageView img2;
    @FXML
    private ImageView img1;

   public void initStage(Stage stage, Member member) {
        this.memberLogged = member;
        this.primaryStage = stage;
        this.clubDB = ClubDBAccess.getSingletonClubDBAccess();
        stage.setTitle("CLUB PADDLE EXPERIENCE");
        stage.setMaxHeight(500.0);
        stage.setMaxWidth(750.0);
        stage.setMinHeight(425.0);
        stage.setMinWidth(650.0);
        Image image = new Image("/imagenes/lol.png");
        img1.setImage(image);
        Image image2 = new Image("/imagenes/ola.png");
        img2.setImage(image2);
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
    
    @FXML
    private void cambioVentanaBotones(ActionEvent event) {
         try{
            if(event.getSource() == cerrarsesion){ FXMLLoader miCargador = new FXMLLoader(getClass().getResource("PaginaInicio.fxml"));
            Parent root = (Parent) miCargador.load();
            miCargador.<PaginaInicioController>getController().initStage(primaryStage);
            Scene scene = new Scene(root);
            String css = this.getClass().getResource("cpe.css").toExternalForm();
            scene.getStylesheets().add(css);
            primaryStage.setScene(scene);
            primaryStage.show();}
            
            if(event.getSource() == eliminarunareserva){ FXMLLoader miCargador = new FXMLLoader(getClass().getResource("MultipleVentana.fxml"));
            Parent root = (Parent) miCargador.load();
            miCargador.<MultipleVentanaController>getController().initStage(primaryStage, loggedMember);
            Scene scene = new Scene(root);
            String css = this.getClass().getResource("cpe.css").toExternalForm();
            scene.getStylesheets().add(css);
            primaryStage.setScene(scene);
            primaryStage.show();}
            
            if(event.getSource() == reservarpista){ FXMLLoader miCargador = new FXMLLoader(getClass().getResource("BotonReservas.fxml"));
            Parent root = (Parent) miCargador.load();
            miCargador.<BotonReservas2>getController().initStage(primaryStage, loggedMember, consulta);
            Scene scene = new Scene(root);
            String css = this.getClass().getResource("cpe.css").toExternalForm();
            scene.getStylesheets().add(css);
            primaryStage.setScene(scene);
            primaryStage.show();}
            
            /*if(event.getSource() == vermisreservas){ FXMLLoader miCargador = new FXMLLoader(getClass().getResource("VerMisReservas.fxml"));
            Parent root = (Parent) miCargador.load();
            miCargador.<VerMisReservasController>getController().initStage(primaryStage);
            Scene scene = new Scene(root);
            String css = this.getClass().getResource("cpe.css").toExternalForm();
            scene.getStylesheets().add(css);
            primaryStage.setScene(scene);
            primaryStage.show();}*/
            
             }catch(IOException e){
            
        } 
    }
      
}
