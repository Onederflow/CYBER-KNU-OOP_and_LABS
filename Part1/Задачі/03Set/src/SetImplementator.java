public interface SetImplementator<T> {
    void insert(T elem);
    void  delete(T elem);
    int size();
    void print();
    T getElem(int idx);
}
