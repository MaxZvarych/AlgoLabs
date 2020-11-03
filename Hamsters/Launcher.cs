using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hamsters
{
    class Launcher
    {
        static void Main(string[] args)
        {
            const string pathIn = @"D:\projects\Algo\Hamsters\hamstr_in.txt";
            const string pathOut = @"D:\projects\Algo\Hamsters\hamstr_out.txt";
            int hamsterCounter = 0;
            int quantityEat = 0;
            int quantityHamster = 0;
            List<Hamster> hamsterCharacteristic = new List<Hamster>();
            Console.WriteLine("Choice consle - positive number or file reading - less than zero: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Read(ref hamsterCharacteristic, ref quantityEat, ref quantityHamster, pathIn, ref choice);
            Algorithm(hamsterCharacteristic, ref hamsterCounter, quantityEat);
            Write(hamsterCounter, pathOut, ref choice);
        }
        public static void Algorithm(List<Hamster> list, ref int hamsterCounter, int quantityEat)
        {
            if(list.Count != 0) 
            {
                for (hamsterCounter = 0; hamsterCounter < list.Count; hamsterCounter++)
                {
                    int sumOfEat = 0;
                    Selecter.QuickSelect(list, hamsterCounter);
                    for (int i = 0; i <= hamsterCounter; i++)
                    {
                        sumOfEat += list[i].SumOfEat(hamsterCounter);
                    }
                    if (sumOfEat > quantityEat)
                    {
                        break;
                    }
                    if (hamsterCounter == list.Count - 1)
                    {
                        hamsterCounter++;
                        break;
                    }
                }
            }
        }
        public static void Read(ref List<Hamster> list, ref int quantityEat, ref int quantityHamster, string path, ref int choice)
        {
            if (choice <= 0)
            {
                ReadWithFile(list, ref quantityEat, ref quantityHamster, path);
            }
            else
            {
                ReadWithConsole(list, ref quantityEat, ref quantityHamster);
            }
        }
        public static void Write(int hamsterCounter, string path, ref int choice)
        {
            if (choice <= 0)
            {
                WriteInFile(ref hamsterCounter, path);
            }
            else
            {
                Console.WriteLine("Answer:");
                Console.WriteLine(hamsterCounter);
            }
        }
        public static void ReadWithConsole(List<Hamster> list, ref int quantityEat,  ref int quantityHamster)
        {
            Console.WriteLine("Input:");
            quantityEat = Convert.ToInt32(Console.ReadLine());
            quantityHamster = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < quantityHamster; i++)
            {
                var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (array[0] < quantityEat)
                {
                    list.Add(new Hamster() { Hunger = array[0], Greed = array[1] });
                }
            }
        }
        public static void ReadWithFile(List<Hamster> list, ref int quantityEat, ref int quantityHamster, string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                quantityEat = Convert.ToInt32(sr.ReadLine());
                quantityHamster = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < quantityHamster; i++)
                {
                    var array = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    if (array[0] < quantityEat)
                    {
                        list.Add(new Hamster() { Hunger = array[0], Greed = array[1] });
                    }
                }
                sr.Close();
            }
        }
        public static void WriteInFile(ref int hamsterCounter, string path)
        {
            using (StreamWriter sr = new StreamWriter(path, false))
            {
                sr.Write(hamsterCounter);
                sr.Close();
            }
            Console.WriteLine("Answer in hamstr out file");
        }
    }
}