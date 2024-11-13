using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MaxHeap
{
    private List<ServiceRequest> heap = new List<ServiceRequest>();

    public void Insert(ServiceRequest request)
    {
        heap.Add(request);
        HeapifyUp(heap.Count - 1);
    }

    private void HeapifyUp(int index)
    {
        while (index > 0 && heap[index].RequestId > heap[(index - 1) / 2].RequestId)
        {
            var temp = heap[index];
            heap[index] = heap[(index - 1) / 2];
            heap[(index - 1) / 2] = temp;
            index = (index - 1) / 2;
        }
    }

    public ServiceRequest ExtractMax()
    {
        if (heap.Count == 0)
            return null;

        var max = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        HeapifyDown(0);
        return max;
    }

    private void HeapifyDown(int index)
    {
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;
        int largest = index;

        if (leftChild < heap.Count && heap[leftChild].RequestId > heap[largest].RequestId)
            largest = leftChild;

        if (rightChild < heap.Count && heap[rightChild].RequestId > heap[largest].RequestId)
            largest = rightChild;

        if (largest != index)
        {
            var temp = heap[index];
            heap[index] = heap[largest];
            heap[largest] = temp;
            HeapifyDown(largest);
        }
    }
}

