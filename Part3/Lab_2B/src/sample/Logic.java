package sample;

import java.util.LinkedHashSet;
import java.util.List;
import java.util.ArrayList;
import java.util.Random;
import java.util.zip.CheckedOutputStream;

public class Logic {
    private List<Integer> listIvn;
    private List<Integer> listPtr;
    private List<Integer> listNch;

    private Thread ivanov;
    private Thread petrow;
    private Thread necheporchuk;

    private int countInv = 0;
    private int countPtr = 0;
    private int countNch = 0;

    boolean block = false;

    private Random rand;

    Logic() {
        listIvn = new ArrayList<>();
        listPtr = new ArrayList<>();
        listNch = new ArrayList<>();
        rand = new Random();
    }

    void Start()
    {
        System.out.println("Start");
        ivanov = new Thread(() -> {
            while (!Thread.currentThread().isInterrupted()) {
                listIvn.add(countInv);
                countInv++;
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                System.out.println(listIvn + "   " + listPtr + "   " + listNch);
            }
        });
        petrow = new Thread(() -> {
            while (!Thread.currentThread().isInterrupted()) {
                int elemPtr = (listPtr.size() == 0)?(0):(listPtr.size() - 1);
                if((listIvn.size() != 0) && (listPtr.size() == 0 || (listIvn.get(listIvn.size() - 1) != listPtr.get(elemPtr)))){
                    listPtr.add(countInv);
                    countPtr++;
                    try {
                        Thread.sleep(400);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                }
            }
        });
        necheporchuk = new      Thread(() -> {
            while (!Thread.currentThread().isInterrupted()) {
                if((listPtr.size() != 0) && (listPtr.get(listPtr.size() - 1) != listNch.get(listNch.size() - 1))) {
                    listNch.add(listIvn.get(countNch));
                    countNch++;

                    try {
                        Thread.sleep(700);
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                }
            }
        });

        ivanov.setDaemon(true);
        petrow.setDaemon(true);
        necheporchuk.setDaemon(true);
        ivanov.start();
        petrow.start();
      //  necheporchuk.start();
    }


}
