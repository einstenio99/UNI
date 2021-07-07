/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package club.paddle.experience;

import DBAcess.ClubDBAccess;
import ipc_entregable.Utils.UtilsPaddle;
import java.io.IOException;
import java.net.URL;
import java.time.LocalDateTime;
import java.util.ResourceBundle;
import javafx.beans.property.SimpleStringProperty;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableRow;
import javafx.scene.control.TableView;
import javafx.stage.Stage;
import model.Booking;
import model.Member;

/**
 * FXML Controller class
 *
 * @author stefa
 */
public class MultipleVentanaController implements Initializable {

    private Stage primaryStage;

    @FXML
    private TableView<Booking> misReservasView;
    @FXML
    private TableColumn<Booking, String> numeroPistaColumn;
    @FXML
    private TableColumn<Booking, String> diaPistaColumn;
    @FXML
    private TableColumn<Booking, String> horaInicioColumn;
    @FXML
    private TableColumn<Booking, String> finReservaColumn;
    @FXML
    private TableColumn<Booking, String> pagadaColumn;
    
    private ClubDBAccess clubDB;
    
    
    @FXML
    private Button botonvolver;
    
    /*Atributos que no son FXML*/
    private ObservableList<Booking> observableBookingUsuario = FXCollections.observableArrayList();
   
    @FXML
    private Button botonEliminar;
    
    private Member loggedMember;
  
    private Member memberLogged;

   public void initStage(Stage stage, Member member) {
        this.primaryStage = stage;
        stage.setTitle("CLUB PADDLE EXPERIENCE");
        stage.setMaxHeight(400.0);
        stage.setMaxWidth(600.0);
        stage.setMinHeight(400.0);
        stage.setMinWidth(600.0);
        this.memberLogged = member;
        this.primaryStage = stage;
        this.clubDB = ClubDBAccess.getSingletonClubDBAccess();
            
    }
    
    /**
     * Initializes the controller class.
     * @param url
     * @param rb
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO

        /*Inicio de la table View*/
        
        numeroPistaColumn.setCellValueFactory(c ->  new SimpleStringProperty(UtilsPaddle.getPistaNumber(c.getValue().getCourt().getName())));
        diaPistaColumn.setCellValueFactory(c -> new SimpleStringProperty(c.getValue().getMadeForDay().toString()));
        horaInicioColumn.setCellValueFactory(c -> new SimpleStringProperty(c.getValue().getFromTime().toString()));
        finReservaColumn.setCellValueFactory(c -> new SimpleStringProperty(UtilsPaddle.getFinReserva(c.getValue().getFromTime())));
        pagadaColumn.setCellValueFactory(c -> new SimpleStringProperty( (c.getValue().getPaid()) ? "Sí" : "No" ));
        
        misReservasView.setRowFactory(row -> new TableRow<Booking>(){
            @Override
            public void updateItem(Booking item, boolean empty){
                super.updateItem(item, empty);
                if(!empty){
                    disableProperty().setValue( UtilsPaddle.superaEldia(item.getBookingDate(), LocalDateTime.now()) ||
                            UtilsPaddle.yaHanJugado(item.getMadeForDay(), LocalDateTime.now()));
                }
            }
        });
        
        misReservasView.setItems(observableBookingUsuario);
        misReservasView.getSortOrder().clear();
        misReservasView.getSortOrder().add(diaPistaColumn);
    } 
    @FXML
    private void eliminarReserva(ActionEvent event) {
        Booking toDelete = misReservasView.getFocusModel().getFocusedItem();
        observableBookingUsuario.remove(toDelete);
        clubDB.getBookings().remove(toDelete);
        misReservasView.getSelectionModel().clearSelection();
        //reserva_canceled_label.visibleProperty().setValue(Boolean.TRUE);
        
    }
    
     @FXML
    private void cambioVentanaBotones(ActionEvent event) {
         try{
            if(event.getSource() == botonvolver){ FXMLLoader miCargador = new FXMLLoader(getClass().getResource("pantallaprincipal.fxml"));
            Parent root = (Parent) miCargador.load();
            miCargador.<PantallaprincipalController>getController().initStage(primaryStage, loggedMember);
            Scene scene = new Scene(root);
            String css = this.getClass().getResource("cpe.css").toExternalForm();
            scene.getStylesheets().add(css);
            primaryStage.setScene(scene);
            primaryStage.show();}
            
            /*if(event.getSource() == ){ FXMLLoader miCargador = new FXMLLoader(getClass().getResource(""));
            Parent root = (Parent) miCargador.load();
            miCargador.<>getController().initStage(primaryStage);
            Scene scene = new Scene(root);
            primaryStage.setScene(scene);
            primaryStage.show();}*/
            
             }catch(IOException e){
            
        } 
    }
    
}
