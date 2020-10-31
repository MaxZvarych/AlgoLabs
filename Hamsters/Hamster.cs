namespace Hamsters
{
    class Hamster
    {
        public int Hunger { get; set; }
        public int Greed { get; set; }
        public int SumOfEat(int n)
        {
            return this.Hunger + n * this.Greed;
        }
    }
}