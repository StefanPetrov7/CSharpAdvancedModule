namespace RapidCourier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var packages = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            var couriers = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int totalDelivery = 0;


            while (packages.Count > 0 && couriers.Count > 0)
            {

                int deliveringCapacity = couriers.Peek();
                int curPackage = packages.Peek();

                if (deliveringCapacity >= curPackage)
                {
                    if (deliveringCapacity > curPackage)
                    {
                        int remainingCapacity = deliveringCapacity - (curPackage * 2);

                        if (remainingCapacity > 0)
                        {
                            couriers.Dequeue();
                            couriers.Enqueue(remainingCapacity);
                            packages.Pop();
                            totalDelivery += curPackage;
                            continue;
                        }
                    }

                    totalDelivery += curPackage;
                    couriers.Dequeue();
                    packages.Pop();

                }
                else
                {
                    packages.Pop();
                    packages.Push(curPackage - deliveringCapacity);
                    int deliveredPotion = couriers.Dequeue();
                    totalDelivery += deliveredPotion;
                }
            }

            Console.WriteLine($"Total weight: {totalDelivery} kg");

            if (packages.Count == 0 && couriers.Count == 0)
            {
                Console.WriteLine($"Congratulations, all packages were delivered successfully by the couriers today.");
            }
            else if (packages.Count > 0 && couriers.Count == 0)
            {
                Console.WriteLine($"Unfortunately, there are no more available couriers to deliver the following packages: {String.Join(", ", packages)}");
            }
            else
            {
                Console.WriteLine($"Couriers are still on duty: {String.Join(", ", couriers)} but there are no more packages to deliver.");
            }
        }
    }
}
