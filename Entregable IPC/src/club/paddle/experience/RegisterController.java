/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package club.paddle.experience;

import DBAcess.ClubDBAccess;
import java.io.File;
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
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.text.Text;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import model.Booking;
import model.Member;

/**
 * FXML Controller class
 *
 * @author stefa
 */
public class RegisterController implements Initializable {

    @FXML
    private TextField CampoNombre;
    @FXML
    private TextField CampoApellidos;
    @FXML
    private TextField CampoTelefono;
    @FXML
    private PasswordField campoPass;
    @FXML
    private PasswordField campoRepPass;
    @FXML
    private TextField CampoTarjeta;
    @FXML
    private TextField CampoCVV;
    @FXML
    private Button BotonVolver;
    @FXML
    private Button BotonContinuar;
    @FXML
    private TextField CampoUserName;
    
    ClubDBAccess clubDBAccess = ClubDBAccess.getSingletonClubDBAccess();

    private Stage primaryStage;
    @FXML
    private Button botonImagen;
    @FXML
    private ImageView imagen;
    @FXML
    private Text nomerror;
    @FXML
    private Text apellidoerror;
    @FXML
    private Text teleferror;
    @FXML
    private Text usererror;
    @FXML
    private Text pswwderror;
    @FXML
    private Text pswwdconferror;
    @FXML
    private Text tarjerror;
    @FXML
    private Text cvverror;
    @FXML
    private Text camposVacios;
  
    private ClubDBAccess clubDB;
    
    private Member loggedMember;
    private boolean consulta;
    private ObservableList<Booking> observableBookingUsuario = FXCollections.observableArrayList();
  
    private Member memberLogged;

   public void initStage(Stage stage, Member member) {
       stage.setTitle("CLUB PADDLE EXPERIENCE");
        stage.setMaxHeight(700.0);
        stage.setMaxWidth(1000.0);
        stage.setMinHeight(550.0);
        stage.setMinWidth(850.0);
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
        usererror.setText("");
        teleferror.setText("");
        pswwderror.setText("");
        tarjerror.setText("");
        cvverror.setText("");
        
        botonImagen.setOnAction(event -> {
        FileChooser fileChooser = new FileChooser();
        fileChooser.setTitle("Buscar Imagen");
        fileChooser.getExtensionFilters().addAll(
                new FileChooser.ExtensionFilter("All Images", "*.*"),
                new FileChooser.ExtensionFilter("JPG", "*.jpg"),
                new FileChooser.ExtensionFilter("PNG", "*.png")
                );
        File imgFile = fileChooser.showOpenDialog(primaryStage);
        
        if(imgFile != null){
            Image image = new Image("file:" + imgFile.getAbsolutePath());
            imagen.setImage(image);
        }
        });
    }     

    @FXML
    private void completarRegistro(ActionEvent event) {
        usererror.setText("");
        teleferror.setText("");
        pswwderror.setText("");
        tarjerror.setText("");
        cvverror.setText("");
         try{
            if(event.getSource() == BotonContinuar && clubDBAccess.existsLogin(CampoUserName.getText()) == false && CampoTelefono.getText().length() == 9 && campoPass.getText().length() > 6
            && campoPass.getText().equals(campoRepPass.getText())){ //&&(CampoTarjeta.getText().length() == 16 ||CampoTarjeta.getText().length() == 0) && (CampoCVV.getText().length() == 3 ||CampoCVV.getText().length() == 0)){ 
                if((CampoTarjeta.getText().length() == 16 && CampoCVV.getText().length() == 3) || (CampoCVV.getText().length() == 0 && CampoTarjeta.getText().length() == 0)){
                
            clubDBAccess.getMembers().add(new Member(CampoNombre.getText(), CampoApellidos.getText(), 
            CampoTelefono.getText(), CampoUserName.getText(), campoPass.getText(), CampoTarjeta.getText(), CampoCVV.getText(), imagen.getImage()));
            //clubDBAccess.saveDB();
            
            FXMLLoader miCargador = new FXMLLoader(getClass().getResource("pantallaprincipal.fxml"));
            Parent root = (Parent) miCargador.load();
            miCargador.<PantallaprincipalController>getController().initStage(primaryStage, loggedMember);
            Scene scene = new Scene(root);
            String css = this.getClass().getResource("cpe.css").toExternalForm();
            scene.getStylesheets().add(css);
            primaryStage.setScene(scene);
            primaryStage.show();
                }else{cvverror.setText("Número de tarjeta(16 dígitos necesarios) y/o CVV incorrectos(3 dígitos)");}
                
            }
  
            //algo raro pasa con estos ifs, cambiar por listeners (Vicente)
            else if(!CampoUserName.getText().split(" ")[0].equals(CampoUserName.getText())){usererror.setText("El nombre de usuario no puede contener espacios");CampoUserName.setText("");}
            else if(CampoNombre.getText().equals("") || CampoApellidos.getText().equals("") || CampoTelefono.getText().equals("") || campoPass.getText().equals("") || campoRepPass.getText().equals("") || CampoUserName.getText().equals("")){camposVacios.setText("No se pueden dejar los campos indicados con '*' en blanco");}
            else if(campoPass.getText().length() < 6){pswwderror.setText("La contraseña ha de tener más de 6 caracteres");}
            else if(clubDBAccess.existsLogin(CampoUserName.getText()) == true){usererror.setText("Este nombre de usuario ya existe.");}
            else if(CampoTelefono.getText().length() != 9){teleferror.setText("Número de teléfono incorrecto.");}
            else if(!campoPass.getText().equals(campoRepPass.getText())){pswwderror.setText("Los campos 'Contraseña' y 'Repita la Contraseña' no coinciden.");}
            //else if(CampoTarjeta.getText().length() != 16){tarjerror.setText("Número de tarjeta incorrecto (16 dígitos necesarios)");}
            //else if(CampoCVV.getText().length() != 3){cvverror.setText("Número de Seguridad incorrecto(3 dígitos)");}
          
            if(event.getSource() == BotonVolver){ 
            FXMLLoader miCargador = new FXMLLoader(getClass().getResource("PaginaInicio.fxml"));
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

 

   
    

