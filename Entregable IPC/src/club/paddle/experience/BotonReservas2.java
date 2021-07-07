
package club.paddle.experience;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import DBAcess.ClubDBAccess;
import java.io.IOException;
import java.net.URL;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.ResourceBundle;
import javafx.beans.binding.Bindings;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.DateCell;
import javafx.scene.control.DatePicker;
import javafx.scene.control.ListCell;
import javafx.scene.control.ListView;
import javafx.scene.layout.GridPane;
import javafx.scene.text.Text;
import javafx.stage.Stage;
import model.Booking;
import model.Member;
/**
 * FXML Controller class
 *
 * @author stefa
 */
public class BotonReservas2 implements Initializable {
    @FXML
    private DatePicker datePickerObj;
    @FXML
    private ListView<LocalTime> ListViewPista1;
    private ObservableList<LocalTime> pista1Datos = null;
    @FXML
    private ListView<LocalTime> ListViewPista2;
    private ObservableList<LocalTime> pista2Datos = null;
    @FXML
    private ListView<LocalTime> ListViewPista3;
    private ObservableList<LocalTime> pista3Datos = null;
    @FXML
    private ListView<LocalTime> ListViewPista4;
    private ObservableList<LocalTime> pista4Datos = null;
    
    @FXML
    private Text textoReserva;
    private ClubDBAccess clubDB;
    private Member loggedMember;
    private boolean consulta;
    private List<LocalTime> lista;
    private LocalDate dateSelected;

    private Stage primaryStage;
    @FXML
    private Button botonCancelar;
    @FXML
    private Button reservarPista;
    @FXML
    private GridPane gridPane;
    
    public void initStage(Stage stage, Member miembro, boolean estaConsultando) {
        stage.setTitle("CLUB PADDLE EXPERIENCE");
        stage.setMaxHeight(540.0);
        stage.setMaxWidth(785.0);
        stage.setMinHeight(540.0);
        stage.setMinWidth(785.0);
        this.primaryStage = stage;
        this.loggedMember = miembro;
        this.consulta = estaConsultando;
        clubDB = ClubDBAccess.getSingletonClubDBAccess();
        this.dateSelected = LocalDate.now();}
    
    /**
     * Initializes the controller class.
     * @param url
     * @param rb
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
   
        this.textoReserva.visibleProperty().setValue(false);
        
        //Este array representa todas las horas disponibles para cada pista!
        lista =  new ArrayList<>( 
        Arrays.asList(LocalTime.of(9,0) , LocalTime.of(10,30), LocalTime.of(12,0), LocalTime.of(13,30), LocalTime.of(15,0),
                LocalTime.of(16,30), LocalTime.of(18,0), LocalTime.of(19,30) ));
        
        //Cada ListView tendrá su própia observable list, las horas son las mismas
        pista1Datos = FXCollections.observableArrayList(lista);
        pista2Datos = FXCollections.observableArrayList(lista);
        pista3Datos = FXCollections.observableArrayList(lista);
        pista4Datos = FXCollections.observableArrayList(lista);
        
        //Colocamos datos
        ListViewPista1.setItems(pista1Datos);
        ListViewPista2.setItems(pista2Datos);
        ListViewPista3.setItems(pista3Datos);
        ListViewPista4.setItems(pista4Datos);
        
        //Formateamos los datos , en este caso el método que he utilizado es el siguiente:
         //1.- Se extraen las horas ocupadas de una pista en un día en concreto
         //2.- Se recorre cada Cell de la lista , si El LocalTime está usado, aparecerá como Reservada y se deshabilita
         //3.- Para los demás casos, se mostrará un simple "Disponible"
                   // Todo esto corresponde a la clase interna : BookingListCell
        
        ListViewPista1.setCellFactory(c -> new BookingListCell("Pista 1"));
        ListViewPista2.setCellFactory(c -> new BookingListCell("Pista 2"));
        ListViewPista3.setCellFactory(c -> new BookingListCell("Pista 3"));
        ListViewPista4.setCellFactory(c -> new BookingListCell("Pista 4"));
        
        //No se pueden hacer reservas en un día que ya ha pasado!
        datePickerObj.setDayCellFactory((DatePicker picker) -> {
            return new DateCell() {
                @Override
                public void updateItem(LocalDate date, boolean empty) {
                    super.updateItem(date, empty);
                    LocalDate today = LocalDate.now();
                    setDisable(empty || date.compareTo(today) < 0 );
                }
            };
        });
        
        
        //En este caso he optado con 1 solo botón de reservar, por lo tanto
        //está bindeado a las 4 listas (4 pistas)
       
        reservarPista.disableProperty().bind(Bindings.equal(-1, ListViewPista1.getSelectionModel().selectedIndexProperty())
                .and(Bindings.equal(-1, ListViewPista2.getSelectionModel().selectedIndexProperty()))
                .and(Bindings.equal(-1, ListViewPista3.getSelectionModel().selectedIndexProperty()))
                .and(Bindings.equal(-1, ListViewPista4.getSelectionModel().selectedIndexProperty())));
        
        //Cada vez que el usuario modifique el DatePicker, su valor cambiará
         // este listener refresca los datos y actualiza la fecha 
        datePickerObj.valueProperty().addListener((ov, oldValue, newValue) -> {
            System.out.println("listener fired!");
            dateSelected = newValue;
            refreshHorario();
        });
        
        //Simplemente por un uso más estético y en relación de 1 solo botón
          //solo se puede seleccionar una hora de una lista.
        ListViewPista1.setOnMouseClicked(c -> {
            reservarPista.textProperty().setValue("Reservar Pista 1");
            ListViewPista2.getSelectionModel().clearSelection();
            ListViewPista3.getSelectionModel().clearSelection();
            ListViewPista4.getSelectionModel().clearSelection();
        });
        
        ListViewPista2.setOnMouseClicked(c -> {
            reservarPista.textProperty().setValue("Reservar Pista 2");
            ListViewPista1.getSelectionModel().clearSelection();
            ListViewPista3.getSelectionModel().clearSelection();
            ListViewPista4.getSelectionModel().clearSelection();
        });
        
        ListViewPista3.setOnMouseClicked(c -> {
            reservarPista.textProperty().setValue("Reservar Pista 3");
            ListViewPista1.getSelectionModel().clearSelection();
            ListViewPista2.getSelectionModel().clearSelection();
            ListViewPista4.getSelectionModel().clearSelection();
        });
        
        ListViewPista4.setOnMouseClicked(c -> {
            reservarPista.textProperty().setValue("Reservar Pista 4");
            ListViewPista1.getSelectionModel().clearSelection();
            ListViewPista2.getSelectionModel().clearSelection();
            ListViewPista3.getSelectionModel().clearSelection();
        });   
    }    


   
    //Método privado para comprobar si dicho hueco horario se encuentra ocupado
    
    private Booking isReserved(LocalTime time, String court) {
        for(Booking book : this.clubDB.getCourtBookings(court,dateSelected)){
            if(book.getFromTime().equals(time) && book.getCourt().getName().equals(court)) {
                return book;
            }
        }
        return null;
    }
    
    //Clase interna para mostrar los datos
    
    class BookingListCell extends ListCell<LocalTime>{
        String court;
        public BookingListCell(String court) {
            this.court = court;
        }
        @Override
        protected void updateItem(LocalTime item, boolean empty) { 
            super.updateItem(item, empty);
            if (item ==  null || empty) {
                setText(null);
            }else if(isReserved(item, court) != null){
                setText("Reservada por \n " + isReserved(item, court) .getMember().getLogin());
                disableProperty().setValue(true);
                //Cuando hacemos un refresh, por error se podría duplicar la clase
                //por este motivo me aseguro de que no sea así
                
                if(!getStyleClass().contains("red-reserved-cell")){
                getStyleClass().add("red-reserved-cell");}
            }else{
                //Si el refresh viene dado por el datePicker, seguramente la posición
                //de una reserva no coincida con lo nuevo mostrado, por eso, si contiene 
                //red-reserved-cell, eliminamos dicha clase, no quiero el backgroun rojo!*
                if(getStyleClass().contains("red-reserved-cell")){
                    getStyleClass().remove("red-reserved-cell");
                }
                
                setText("Disponible");
                disableProperty().setValue(consulta);
                
            }
       }   
      
    }   
    
  
    @FXML
    private void cambioVentanaBotones(ActionEvent event) {
         try{
            if(event.getSource() == botonCancelar){ FXMLLoader miCargador = new FXMLLoader(getClass().getResource("pantallaprincipal.fxml"));
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

    @FXML
    private void reservarSelected(ActionEvent event) {
        int pistaNumer = Integer.parseInt(this.reservarPista.textProperty().getValue().split(" ")[2]);
        LocalTime selectedTime = null;
        switch(pistaNumer){
            case 1:
               selectedTime = ListViewPista1.getSelectionModel().getSelectedItem();
               break;
            case 2:
               selectedTime = ListViewPista2.getSelectionModel().getSelectedItem();
               break;
            case 3:
               selectedTime = ListViewPista3.getSelectionModel().getSelectedItem();
               break;
             case 4:
               selectedTime = ListViewPista4.getSelectionModel().getSelectedItem();
               break;
        }
        LocalDate madeForDay = (datePickerObj.getValue() == null) ? LocalDate.now() : datePickerObj.getValue();
     /**/  Booking toAdd = new Booking(LocalDateTime.now(), madeForDay, selectedTime, clubDB.hasCreditCard(loggedMember.getLogin()), clubDB.getCourt("Pista " + pistaNumer), this.loggedMember);
        clubDB.getBookings().add(toAdd);
        
        this.gridPane.visibleProperty().setValue(false);
        this.textoReserva.visibleProperty().setValue(true);
        refreshHorario();
    }
     //Refresca las list views y quita las selecciones para evitar problemas
    private void refreshHorario(){
        
        ListViewPista1.refresh(); ListViewPista2.refresh(); ListViewPista3.refresh(); ListViewPista4.refresh();
        ListViewPista1.getSelectionModel().clearSelection(); ListViewPista2.getSelectionModel().clearSelection();
        ListViewPista3.getSelectionModel().clearSelection(); ListViewPista4.getSelectionModel().clearSelection();
    }
}
