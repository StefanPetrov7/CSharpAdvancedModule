namespace BoxOfT;

class StartUp
{
    static void Main(string[] args)
    {

        Box<int> box = new Box<int>();
        box.Add(1);
        box.Add(2);
        box.Add(3);
        Console.WriteLine(box.Remove());
        Console.WriteLine(box.Count);

    }

    public class Box<T>
    {
        private Stack<T> internalStack;

        public Box()
        {
            this.internalStack = new Stack<T>();
        }

        public void Add(T element)
        {
            this.internalStack.Push(element);
        }

        public T Remove()
        {
            T element = this.internalStack.Pop();
            return element;
        }

        public int Count => this.internalStack.Count;

    }
}