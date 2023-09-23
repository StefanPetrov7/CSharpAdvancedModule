namespace CarSalesman;
public class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        HashSet<Engine> engines = new HashSet<Engine>();
        HashSet<Car> cars = new HashSet<Car>();


        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string model = input[0];
            double power = double.Parse(input[1]);
            Engine engine = new Engine(model, power);

            if (input.Length == 3)
            {
                if (double.TryParse(input[2], out double displacement))
                {
                    engine.Displacement = displacement;
                }
                else
                {
                    engine.Efficiency = input[2];
                }
            }

            if (input.Length == 4)
            {
                engine.Displacement = double.Parse(input[2]);
                engine.Efficiency = input[3];
            }
            engines.Add(engine);
        }

        n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string model = input[0];
            string engineModel = input[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

            Car car = new Car(model, engine);

            if (input.Length == 3)
            {
                if (double.TryParse(input[2], out double weight))
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = input[2];
                }
            }
            if (input.Length == 4)
            {
                car.Weight = double.Parse(input[2]);
                car.Color = input[3];
            }

            cars.Add(car);
        }

        foreach (Car car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}