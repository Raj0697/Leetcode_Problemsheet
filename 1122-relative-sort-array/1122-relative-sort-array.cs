public class Solution {
    public int[] RelativeSortArray(int[] arr1, int[] arr2) {
        var elementsInArr2 = new HashSet<int>();
        foreach (var element in arr2)
        {
            elementsInArr2.Add(element);
        }

        var arr1ElementsNotInArr2 = new PriorityQueue<int, int>();
        var elementCountOfArr1 = new Dictionary<int, int>();
        foreach (var element in arr1)
        {
            if (!elementsInArr2.Contains(element))
            {
                arr1ElementsNotInArr2.Enqueue(element, element);
            }
            elementCountOfArr1[element] = elementCountOfArr1.GetValueOrDefault(element, 0) + 1;
        }

        var currentIndexArr1 = 0;
        foreach (var element in arr2)
        {
            var elementCount = elementCountOfArr1[element];
            for (int j = 0; j < elementCount; j++)
            {
                arr1[currentIndexArr1] = element;
                currentIndexArr1 += 1;
            }
        }

        while (arr1ElementsNotInArr2.Count > 0)
        {
            arr1[currentIndexArr1] = arr1ElementsNotInArr2.Dequeue();
            currentIndexArr1 += 1;
        }

        return arr1;
    }
}