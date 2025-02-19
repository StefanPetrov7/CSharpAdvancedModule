namespace ExamJune22
{
    internal class RapidCourier
    {
        static void Main(string[] args)
        {
            var packages = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            var couriers = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            int totalDelivery = 0;

            while (packages.Count > 0 && couriers.Count > 0)
            {
                int deliveringCapacity = couriers.Dequeue();
                int curPackage = packages.Pop();

                if (deliveringCapacity >= curPackage) 
                {

                    if (deliveringCapacity > (curPackage * 2))
                    {
                        int remainingCapacity = deliveringCapacity - (curPackage * 2);
                        couriers.Enqueue(remainingCapacity);
                    }

                    totalDelivery += curPackage;
                }
                else
                {
                    packages.Push(curPackage - deliveringCapacity);
                    totalDelivery += deliveringCapacity;
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
