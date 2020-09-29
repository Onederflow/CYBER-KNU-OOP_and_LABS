import java.util.ArrayList;
import java.util.List;

public class ListSet<T> implements SetImplementator<T> {
    private List<T> set = new ArrayList<>();
    @Override
    public void insert(T elem) {
        set.add(elem);
    }

    @Override
    public void delete(T elem) {
        set.remove(elem);
    }

    @Override
    public int size() {
        return set.size();
    }

    @Override
    public void print() {
        for(T elem : set){
            System.out.print(elem + " ");
        }
    }

    @Override
    public T getElem(int idx) {
        return set.get(idx);
    }
}
