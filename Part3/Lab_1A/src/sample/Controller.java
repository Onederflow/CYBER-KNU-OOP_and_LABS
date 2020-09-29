package sample;

import javafx.fxml.FXML;
import javafx.scene.control.RadioButton;
import javafx.scene.control.Slider;
import javafx.scene.control.ToggleGroup;
import javafx.scene.input.MouseEvent;

public class Controller {
    public Logic L;
    @FXML
    private Slider slider_x;
    @FXML
    private RadioButton RB0;
    @FXML
    private RadioButton RB1;
    @FXML
    private RadioButton RB2;


    public void initialize(){
        L = new Logic(slider_x);
        ToggleGroup group = new ToggleGroup();
        RB0.setToggleGroup(group);
        RB1.setToggleGroup(group);
        RB2.setToggleGroup(group);
    }

    @FXML public void handleMouseClick(MouseEvent arg0) {
        L.Start();
    }
    @FXML public void handleExit(MouseEvent arg0) {
        L.Stop();
    }

    @FXML public void SetPriorityNone(MouseEvent arg0) {
        L.SetPriority("none");
    }
    @FXML public void SetPriorityFirst(MouseEvent arg0) {
        L.SetPriority("first");
    }
    @FXML public void SetPrioritySecond(MouseEvent arg0) {
        L.SetPriority("second");
    }
}


