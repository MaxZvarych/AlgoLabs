using System;
using System.Collections.Generic;
using System.Linq;

namespace Hamsters
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input:");
            int hamsterCounter = 0;
            int minEatSum = Int32.MaxValue;
            int quantityEat = Convert.ToInt32(Console.ReadLine());
            int quantityHamster = Convert.ToInt32(Console.ReadLine());
            var hamsterCharacteristic = new List<dynamic>();
            for (int i = 0; i < quantityHamster; i++)
            {
                var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (array[0] < quantityEat)
                {
                    hamsterCharacteristic.Add(new Hamster() { Hunger = array[0], Greed = array[1] });
                    minEatSum = hamsterCharacteristic[i].Hunger < minEatSum ? hamsterCharacteristic[i].Hunger : minEatSum;
                }
            }
            if(hamsterCharacteristic.Count != 0) 
            {
                for (hamsterCounter = 0; hamsterCounter < hamsterCharacteristic.Count; hamsterCounter++)
                {
                    int sumOfEat = 0;
                    Sorter.QuickSearch(hamsterCharacteristic, hamsterCounter);
                    for (int j = 0; j <= hamsterCounter; j++)
                    {
                        sumOfEat += hamsterCharacteristic[j].SumOfEat(hamsterCounter);
                    }
                    if (sumOfEat > quantityEat)
                    {
                        break;
                    }
                    if (hamsterCounter == hamsterCharacteristic.Count - 1)
                    {
                        hamsterCounter++;
                        break;
                    }
                }
            }
            Console.WriteLine("Answer:");
            Console.WriteLine(hamsterCounter);
        }
    }
}