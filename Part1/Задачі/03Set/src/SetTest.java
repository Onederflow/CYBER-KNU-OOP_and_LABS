import org.junit.Assert;
import org.junit.jupiter.api.Test;

public class SetTest {
    @Test
    public void checkSetArr(){
        Set<Integer> set = new Set<>(new ArraySet<>());
        set.insert(1);
        set.insert(2);
        set.insert(4);
        set.insert(3);
        set.insert(5);
        set.delete(4);
        set.print();
        Assert.assertEquals(new Integer(1), set.getElem(0));
        Assert.assertEquals(new Integer(2), set.getElem(1));
        Assert.assertEquals(new Integer(3), set.getElem(2));
        Assert.assertEquals(new Integer(5), set.getElem(3));
    }
    @Test
    public void checkList(){
        Set<Integer> set = new Set<>(new ListSet<>());
        set.insert(1);
        set.insert(2);
        set.insert(4);
        set.insert(3);
        set.insert(5);
        set.delete(4);
        set.print();
        Assert.assertEquals(new Integer(1), set.getElem(0));
        Assert.assertEquals(new Integer(2), set.getElem(1));
        Assert.assertEquals(new Integer(3), set.getElem(2));
        Assert.assertEquals(new Integer(5), set.getElem(3));
    }
}