package sample;
import javafx.scene.control.Slider;
import javafx.scene.layout.Priority;

public class Logic {
    public String priority = "none";        //приоритет
    private Thread threadFirst;             //1й поток
    private Thread threadSecond;            //2й поток
    private int firstCount = 0;
    private int secondCount = 0;
    private Slider slider;

    public Logic(Slider new_sl) {
        slider = new_sl;
    }

    public  void  Start() {
        threadFirst = new Thread(() -> {
            while (true) {
                synchronized (slider) { slider.setValue(10);}
                firstCount++;
                DrawTool();
            }
        });
        threadSecond = new Thread(() -> {
            while(true) {
                synchronized (slider) { slider.setValue(90);}
                secondCount++;
                DrawTool();
            }
        });

        threadFirst.setDaemon(true);
        threadSecond.setDaemon(true);

        threadFirst.start();
        threadSecond.start();

    }
    public void Stop() {
        System.out.println("Exit");
        System.exit(1);
    }

    public void SetPriority(String s) {
        priority = s;
        if (threadSecond != null && threadFirst != null)
            switch (priority) {
                case "none": {
                    threadFirst.setPriority(5);
                    threadSecond.setPriority(5);
                }
                break;
                case "first": {
                    threadFirst.setPriority(10);
                    threadSecond.setPriority(3);
                }
                break;
                case "second": {
                    threadFirst.setPriority(3);
                    threadSecond.setPriority(10);
                }
                break;
            }
    }
    private void DrawTool()
    {
        System.out.println("Priority : " + priority + "  |  " + "First :" + firstCount + "  |  " + "Second :" + secondCount + "           ||   real pr : " + threadFirst.getPriority() + " " + threadSecond.getPriority());
    }
}
