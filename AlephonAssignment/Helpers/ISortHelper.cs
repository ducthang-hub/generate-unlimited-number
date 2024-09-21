namespace AlephonAssignment.Helpers
{
    internal interface ISortHelper<T>
    {
        public void HeapSort(T[] arr);
        public void Heapify(T[] arr, int n, int i);
    }
}
