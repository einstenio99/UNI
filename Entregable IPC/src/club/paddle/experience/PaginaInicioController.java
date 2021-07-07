/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package club.paddle.experience;

import DBAcess.ClubDBAccess;
import java.awt.event.ActionEvent;
import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;
import java.util.stream.Collectors;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.stage.Stage;
import model.Booking;
import model.Member;


/**
 * FXML Controller class
 *
 * @author stefa
 */
public class PaginaInicioController implements Initializable {
    
    public Stage primaryStage;
    

    @FXML
    private Button btniniciosesion;
    @FXML
    private Button btnregistro;
    @FXML
    private Button btndisponibilidad;
    @FXML
    private Button btninfo;
    @FXML
    private Button btnsalir;
    
    
     /*@Params : El stage recibido por la ventana anterior, en este caso, el inicilizador de la Aplicación*/
    private ClubDBAccess clubDB;
    
    private Member loggedMember;
    private boolean consulta;
    private ObservableList<Booking> observableBookingUsuario = FXCollections.observableArrayList();
  
    private Member memberLogged;
    @FXML
    private ImageView img;

   public void initStage(Stage stage) {
      
        this.primaryStage = stage;
        stage.setTitle("CLUB PADDLE EXPERIENCE");
        stage.setMaxHeight(500.0);
        stage.setMaxWidth(700.0);
        stage.setMinHeight(400.0);
        stage.setMinWidth(640.0);
        Image image = new Image("/imagenes/jajaj.png");
        img.setImage(image);
    }
   
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    

   
        

    @FXML
    private void accesoPagInicio(javafx.event.ActionEvent event) {
        try{
            if(event.getSource() == btnregistro){ FXMLLoader miCargador = new FXMLLoader(getClass().getResource("register.fxml"));
            Parent root = (Parent) miCargador.load();
            miCargador.<RegisterController>getController().initStage(primaryStage, loggedMember);
            Scene scene = new Scene(root); 
            String css = this.getClass().getResource("cpe.css").toExternalForm();
            scene.getStylesheets().add(css);
            primaryStage.setScene(scene);
            primaryStage.show();}
            
           /* if(event.getSource() == btndisponibilidad){ FXMLLoader miCargador = new FXMLLoader(getClass().getResource(".fxml"));
            Parent root = (Parent) miCargador.load();
            miCargador.<RegisterController>getController().initStage(primaryStage);
            Scene scene = new Scene(root);
            primaryStage.setScene(scene);
            primaryStage.show();}*/
           
            
            if(event.getSource() == btniniciosesion){ FXMLLoader miCargador = new FXMLLoader(getClass().getResource("InicioSesion.fxml"));
            Parent root = (Parent) miCargador.load();
            miCargador.<InicioSesionController>getController().initStage(primaryStage, loggedMember);
            Scene scene = new Scene(root);
            String css = this.getClass().getResource("cpe.css").toExternalForm();
            scene.getStylesheets().add(css);
            primaryStage.setScene(scene);
            primaryStage.show();}
             
            if(event.getSource() == btninfo){ FXMLLoader miCargador = new FXMLLoader(getClass().getResource("quienessomos.fxml"));
            Parent root = (Parent) miCargador.load();
            miCargador.<QuienessomosController>getController().initStage(primaryStage, loggedMember);
            Scene scene = new Scene(root);
            String css = this.getClass().getResource("cpe.css").toExternalForm();
            scene.getStylesheets().add(css);
            primaryStage.setScene(scene);
            primaryStage.show();}
            if(event.getSource() == btnsalir) { primaryStage.close();}
           
        }catch(IOException e){
            
        } 
    }
    }
   




    

   

    

    
    


   
     

