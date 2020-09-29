package sample;
import javafx.scene.control.Button;
import javafx.scene.control.Slider;

import javax.swing.*;
import java.util.Random;

public class Logic {
    public String priority = "none";        //приоритет
    private Thread threadFirst;             //1й поток
    private Thread threadSecond;            //2й поток
    private int firstCount = 0;
    private int secondCount = 0;

    private Slider slider;
    private Button bStop1;
    private Button bStop2;

    public  int semaphore = 0;

    public Logic(Slider new_sl, Button b1, Button b2) {
        slider = new_sl;
        bStop1 = b1;
        bStop2 = b2;
    }

    public  void  StartFirstThread() {
        threadFirst = new Thread(() -> {
            while (!threadFirst.isInterrupted()) {
                synchronized (slider) { slider.setValue(10);}
                firstCount++;
                System.out.println("1");
            }
        });
        threadFirst.setDaemon(true);
        threadFirst.setPriority(1);
        bStop2.setDisable(true);
        threadFirst.start();
    }
    public  void  StartSecondThread() {
        threadSecond = new Thread(() -> {
            while (!threadSecond.isInterrupted()) {
                synchronized (slider) { slider.setValue(90);}
                secondCount++;
                System.out.println("2");
            }
        });
        threadSecond.setDaemon(true);
        threadSecond.setPriority(10);
        bStop1.setDisable(true);
        threadSecond.start();
    }
    public  void StopFirst()
    {
        if(threadFirst != null) {
            threadFirst.interrupt();
            bStop2.setDisable(false);
        }
    }
    public  void StopSecond()
    {
        if(threadSecond != null) {
            threadSecond.interrupt();
            bStop1.setDisable(false);
        }
    }


    public void Stop() {
        if(threadFirst != null) {
                threadFirst.interrupt();
                semaphore = 0;
                bStop2.setDisable(false);
        }
        if(threadSecond != null) {
            threadSecond.interrupt();
            semaphore = 0;
            bStop1.setDisable(false);
        }
    }

    public void StartMain() {
        semaphore = 1;
        Random rand = new Random();
        if(rand.nextBoolean() == true) {
            StartFirstThread();
        }
        else {
            StartSecondThread();
        }
    }

    public void MessageTool()
    {
        JOptionPane.showMessageDialog(null, "Упс, занято другим потоком!");
    }
}
