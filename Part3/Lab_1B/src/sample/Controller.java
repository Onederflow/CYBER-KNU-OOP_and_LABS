package sample;

import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Slider;
import javafx.scene.input.MouseEvent;

public class Controller {
    public Logic logic;
    @FXML
    private Slider slider_x;
    @FXML
    private Button btnStop1;
    @FXML
    private Button btnStop2;


    public void initialize() {
        logic = new Logic(slider_x, btnStop1, btnStop2);
    }

    @FXML
    public void StartMainClick(MouseEvent arg0){
        logic.StartMain();
    }
    @FXML
    public void StopMainClick(MouseEvent arg0){
        logic.Stop();
    }
    @FXML
    public void StartFirstClick(MouseEvent arg0){
        if(logic.semaphore == 0) {
            logic.semaphore = 1;
            logic.StartFirstThread();
        }
        else{
            logic.MessageTool();
        }

    }
    @FXML
    public void StopFirstClick(MouseEvent arg0){
        logic.semaphore = 0;
        logic.StopFirst();
    }
    @FXML
    public void StartSecondClick(MouseEvent arg0){
        if(logic.semaphore == 0) {
            logic.semaphore = 1;
            logic.StartSecondThread();
        }
        else {
            logic.MessageTool();
        }
    }
    @FXML
    public void StopSecondClick(MouseEvent arg0){
        logic.semaphore = 0;
        logic.StopSecond();
    }
}


