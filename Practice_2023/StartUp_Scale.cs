namespace GenericScale;

public class StartUp
{
    static void Main(string[] args)
    {

        EqualityScale<int> scale = new EqualityScale<int>(2, 2);
        Console.WriteLine(scale.AreEqual());

    }

    public class EqualityScale<T>
    {
        private T element1;

        private T element2;

        public EqualityScale(T element1, T element2)
        {
            this.element1 = element1;
            this.element2 = element2;
        }

        public bool AreEqual()
        {
            return this.element1.Equals(this.element2);

        }
    }
}