public class Set<T> {
    private SetImplementator<T> set;
    Set(SetImplementator<T> set){
        this.set = set;
    }
    public void insert(T elem){
        set.insert(elem);
    }
    public void delete(T elem){
        set.delete(elem);
    }
    public int getSize(){
        return set.size();
    }
    public void print(){
        set.print();
    }

    public T getElem(int idx){
        return set.getElem(idx);
    }

}
