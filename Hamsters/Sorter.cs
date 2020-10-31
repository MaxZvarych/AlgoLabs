using System.Collections.Generic;

namespace Hamsters
{
    class Sorter
    {
        public static int QuickSearch(List<dynamic> array, int quantity)
        {
            return QuickSearch(array, 0, array.Count - 1, quantity);
        }
        private static int QuickSearch(List<dynamic> array, int minIndex, int maxIndex, int quantity)
        {
            int partition = Partition(array, minIndex, maxIndex, quantity);
            if (partition == quantity)
            {
                return 0;
            }
            else if (partition < quantity)
            {
                return QuickSearch(array, partition + 1, maxIndex, quantity);
            }
            else
            {
                return QuickSearch(array, minIndex, partition - 1, quantity);
            }
        }
        private static int Partition(List<dynamic> array, int minIndex, int maxIndex, int quantity)
        {
            int pivot = minIndex;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (array[i].SumOfEat(quantity) < array[maxIndex].SumOfEat(quantity))
                {
                    Swap(array, ref pivot, ref i);
                    pivot++;
                }
            }
            Swap(array, ref pivot, ref maxIndex);
            return pivot;
        }
        private static void Swap(List<dynamic> array, ref int i, ref int j)
        {
            int temp = array[i].Hunger;
            array[i].Hunger = array[j].Hunger;
            array[j].Hunger = temp;

            temp = array[i].Greed;
            array[i].Greed = array[j].Greed;
            array[j].Greed = temp;
        }
    }
}