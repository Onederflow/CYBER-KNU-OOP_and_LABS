package sample;

import java.util.LinkedHashSet;
import java.util.Random;

public class Logic {
    private LinkedHashSet<Integer> list;
    private int nBees = 3;
    private int nForest = 44;
    private Thread[] realBee;
    private Thread realWinnie;
    private boolean listControl = true;
    Random rand;

    Logic() {
        list = new LinkedHashSet<>();
        rand = new Random();
    }

    void Start()
    {
        System.out.println("Start");
        realBee = new Thread[nBees];
        realWinnie = new Thread(() -> {
            while (!Thread.currentThread().isInterrupted()) {
                list.add(Integer.valueOf(NewPosOfWinnie()));
                System.out.println(list);
                int timeout = rand.nextInt(2000) + 1000;
                try {
                    Thread.sleep(timeout);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        });
        realWinnie.setDaemon(true);
        realWinnie.start();

        for(int i = 0; i < nBees; i++) {
            realBee[i] = new Thread(() -> {
                while (!Thread.currentThread().isInterrupted()) {
                    if(listControl) {
                        listControl = false;
                        int part = getNewTask();
                        listControl = true;
                        if(part != -1) {
                            int timeout = (int) (2000 + 600 * Math.sqrt(Math.pow(part / (Math.sqrt(Math.abs(part))), 2) + Math.pow(part % (Math.sqrt(Math.abs(part))), 2)));
                            try {
                                Thread.sleep(timeout);
                            } catch (InterruptedException e) {
                                e.printStackTrace();
                            }
                            boolean whereTheMonster = rand.nextBoolean();
                            System.out.println("Swarm near " + part  + "     Result : "+  (whereTheMonster? ("success"):("nobody")) + "  | timeout" + timeout);
                            try {
                                Thread.sleep(timeout);
                            } catch (InterruptedException e) {
                                e.printStackTrace();
                            }
                        }
                    }
                }
            });

            realBee[i].setDaemon(true);
            realBee[i].start();
        }
    }
    int NewPosOfWinnie() {
        return rand.nextInt(nForest);
    }

    int getNewTask(){
        if(list.size() != 0 && list.iterator() != null) {
            int temp = list.iterator().next();
            list.remove(temp);
            return temp;
        }
        return -1;
    }

}
