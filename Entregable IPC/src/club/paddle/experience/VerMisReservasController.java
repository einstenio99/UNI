/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package club.paddle.experience;

import DBAcess.ClubDBAccess;
import java.util.ResourceBundle;
import java.net.URL;
import javafx.fxml.Initializable;
import javafx.stage.Stage;

/*import com.sun.javaws.Main;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Locale;
import javafx.beans.property.ReadOnlyStringWrapper;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.TableColumn;
import model.Booking;*/

/**
 * FXML Controller class
 *
 * @author Victor
 */
public class VerMisReservasController implements Initializable {
    
     ClubDBAccess clubDBAccess = ClubDBAccess.getSingletonClubDBAccess();

    /**
     * Initializes the controller class.
     * @param url
     * @param rb
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }  
    
   /* @FXML
    public void setTableData(){
        ArrayList<Booking> userBookings = clubDBAccess.getUserBookings(loggedUser.getLogin());
        userBookings.removeIf(booking -> booking.getMadeForDay().compareTo(LocalDate.now()) < 0);
        ObservableList<Booking> userObservableBookings;
        if(userBooking.size() > 10){
            userObservableBookings = FXCollections.observableArrayList(userBookings.subList)0,10));}
        else { userObservableBookings = FXCollections.observableArrayList(userBookings);}
        
        my_res_table.setItems(userObservableBookings);
        my_res_table.setFixedCellSize(25);
        my_res_table.prefHeightProperty().setValue(280);
        
        court_column.setCellValueFactory(cellData -> new ReadOnlyStringWrapper(cellData.getValue().getCourt().getName()));
        //time_column.setCellValueFactory(cellData -> new ReadOnlyStringWrapper(cellData.getValue().getFromTime() + " - " + cellData.getValue().getFromTime().pl???));
        date_column.setCellValueFactory(cellData -> new ReadOnlyStringWrapper(cellData.getValue().getMadeForDay().format(DateTimeFormatter.ofPattern("d/MM/uuuu"))));
        made_in_column.setCellValueFactory(cellData -> new ReadOnlyStringWrapper(cellData.getValue().getBookingDate().format(DateTimeFormatter.ofPattern("d/MM/uuuu"))));
        paid_column.setCellValueFactory(cellData -> new ReadOnlyStringWrapper(paidForTable(cellData.getValue().getPaid())));
    }*/

    void initStage(Stage primaryStage) {
        /*this.primaryStage = stage;
        stage.setTitle("CLUB PADDLE EXPERIENCE");
        stage.setMaxHeight(el pref height que ponga en scenebuilder);
        stage.setMaxWidth(*** width *******************************);
        stage.setMinHeight(*****************************************);
        stage.setMinWidth(*******************************************);*/
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
}
