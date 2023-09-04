namespace Practice_2023;

class Key_Revolver
{
    static void Main(string[] args)
    {

        int bulletPrice = int.Parse(Console.ReadLine());
        int gunBarrelSize = int.Parse(Console.ReadLine());
        int curGunBarelSize = gunBarrelSize;
        Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Queue<int> locks = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        int price = int.Parse(Console.ReadLine());

        while (bullets.Count > 0 && locks.Count > 0)
        {
            curGunBarelSize--;
            int curBullet = bullets.Pop();
            price -= bulletPrice;

            if (curBullet <= locks.Peek())
            {
                locks.Dequeue();
                Console.WriteLine("Bang!");
            }
            else
            {
                Console.WriteLine("Ping!");
            }

            if (bullets.Any() && curGunBarelSize == 0)
            {
                curGunBarelSize = gunBarrelSize;
                Console.WriteLine("Reloading!");
            }
        }

        string result;

        if (locks.Count == 0)
        {
            result = $"{bullets.Count} bullets left. Earned ${price}";
        }
        else
        {
            result = $"Couldn't get through. Locks left: {locks.Count}";
        }

        Console.WriteLine(result);
    }
}
