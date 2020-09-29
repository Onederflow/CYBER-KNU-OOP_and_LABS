public class ArraySet<T> implements SetImplementator<T> {
    private Object[] set;
    int size;
    ArraySet(){
        set = new Object[0];
    }
    @Override
    public void insert(T elem) {
        Object[] tempSet = new Object[++size];
        for(int i = 0; i < size - 1; i++){
            tempSet[i] = set[i];
        }
        tempSet[size - 1] = elem;
        set = tempSet;
    }

    @Override
    public void delete(T elem) {
        Object[] tempSet = new Object[--size];
        for(int i = 0, j = 0; i < size + 1; i++){
            if(set[i] != elem){
                tempSet[j] = set[i];
                j++;
            }
        }
        set = tempSet;
    }

    @Override
    public int size() {
        return size;
    }
    @Override
    public void print() {
        for(Object elem : set){
            System.out.print(elem + " ");
        }
    }

    @Override
    public T getElem(int idx) {
        return (T)set[idx];
    }
}
