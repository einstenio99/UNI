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
import java.util.stream.Collectors;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.text.Text;
import javafx.stage.Stage;
import model.Booking;
import model.Member;

/**
 * FXML Controller class
 *
 * @author stefa
 */
public class InicioSesionController implements Initializable {
    
    public Stage primaryStage;

    @FXML
    private Button BotonVolver;
    @FXML
    private Button BotonAcceder;
    @FXML
    private TextField CampoUserName;
    @FXML
    private PasswordField CampoPass;
    
    ClubDBAccess clubDBAccess = ClubDBAccess.getSingletonClubDBAccess();
    @FXML
    private Text errorContraseña;
    
    private ClubDBAccess clubDB;
    private Member loggedMember;
    private boolean consulta;
    private ObservableList<Booking> observableBookingUsuario = FXCollections.observableArrayList();
  
    private Member memberLogged;

    public void initStage(Stage stage, Member member) {
        this.primaryStage = stage;
        stage.setTitle("CLUB PADDLE EXPERIENCE");
        stage.setMaxHeight(500.0);
        stage.setMaxWidth(620.0);
        stage.setMinHeight(420.0);
        stage.setMinWidth(565.0);
        this.memberLogged = member;
        this.primaryStage = stage;
        this.clubDB = ClubDBAccess.getSingletonClubDBAccess();
        //this.Login_name.textProperty().setValue(this.memberLogged.getLogin());
        //this.pic_login.setFill((member.getImage() == null) ? new ImagePattern(new Image("/ipc_entregable/imgs/userIcon.png")) : new ImagePattern(memberLogged.getImage()));
         
        //observableBookingUsuario.addAll(clubDB.getUserBookings(member.getLogin()).stream().limit(10).collect(Collectors.toList()));
         
        //Tooltip.install(close_session_svg, new Tooltip("Cerrar Sesión!"));
        //ParentContent.prefHeightProperty().bind(primaryStage.heightProperty());
        //close_misReservas.tooltipProperty().setValue(new Tooltip("Volver al menú"));
            
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
    private void completarInicioSesion(ActionEvent event) {
         try{
            if(event.getSource() == BotonAcceder && clubDBAccess.getMemberByCredentials(CampoUserName.getText(), CampoPass.getText()) == null ){
            CampoUserName.setText("");
            CampoPass.setText("");
            errorContraseña.setText("Error en el inicio de sesión, vuelva a introducir los datos");}
             
            if(event.getSource() == BotonAcceder && clubDBAccess.getMemberByCredentials(CampoUserName.getText(), CampoPass.getText()) != null ){ FXMLLoader miCargador = new FXMLLoader(getClass().getResource("pantallaprincipal.fxml"));
            Parent root = (Parent) miCargador.load();
            miCargador.<PantallaprincipalController>getController().initStage(primaryStage, loggedMember);
            Scene scene = new Scene(root);
            String css = this.getClass().getResource("cpe.css").toExternalForm();
            scene.getStylesheets().add(css);
            primaryStage.setScene(scene);
            primaryStage.show();}
  
     
            if(event.getSource() == BotonVolver){ FXMLLoader miCargador = new FXMLLoader(getClass().getResource("PaginaInicio.fxml"));
            Parent root = (Parent) miCargador.load();
            miCargador.<PaginaInicioController>getController().initStage(primaryStage);
            Scene scene = new Scene(root);
            String css = this.getClass().getResource("cpe.css").toExternalForm();
            scene.getStylesheets().add(css);
            primaryStage.setScene(scene);
            primaryStage.show();}
            
             }catch(IOException e){
            
        } 
         
         
    }
    
}

