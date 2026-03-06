using System.Text;

namespace Garbage_Collection_IDisposable_using
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cars car = new Cars();

            //car.display();
            //car.FilterCar("Dodge");

            //string[] path = File.ReadAllLines("C:\\Users\\user\\source\\repos\\ConsoleApp2\\Cars\\vehicles.csv");

            string path = "C:\\Users\\user\\source\\repos\\ConsoleApp2\\Cars\\vehicles.csv";

            using (FileStream fs = new(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[fs.Length];
                fs.ReadExactly(buffer);

                string readedText = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(readedText);
            }


            var cars = Transfrom(path);

            var sortedCars = SortByDescending(cars);
            //var filtered = filterCarsByName(sortedCars);

            //var top10 = GetTop10EconomicCars(sortedCars);
            //var filtered = filterCarsByName(sortedCars);

            var fast = GetTop10Fastest(sortedCars);

            foreach (var item in fast)
            {
                Console.WriteLine(
                         $@"{item.Make} 
                            Model: {item.Model}
                            Cylinder: {item.Cylinder}
                            Engine : {item.Engine}
                            Drive : {item.Drive}
                            Transmission : {item.Transmission}
                            City : {item.City}
                            Combined : {item.Combined}
                            Highway : {item.Highway}
                           -----------------------------------");
            }

        }

        static List<Cars> GetTop10EconomicCars(List<Cars> allSortedCars)
        {
            List<Cars> result = new();

            for (int i = 0; i < 10; i++)
            {
                result.Add(allSortedCars[i]);
            }

            return result;
        }


        static List<Cars> SortByDescending(List<Cars> cars)
        {
            for (int i = 0; i < cars.Count - 1; i++)
            {
                for (int j = i + 1; j < cars.Count; j++)
                {
                    if (cars[j].Combined > cars[i].Combined)
                    {
                        var temp = cars[j];
                        cars[j] = cars[i];
                        cars[i] = temp;
                    }
                }
            }
            return cars;
        }

        static List<Cars> filterCarsByName(List<Cars> allCars)
        {
            List<Cars> filteredCar = new List<Cars>();

            for (int i = 0; i < allCars.Count; i++)
            {
                if (allCars[i].Make.ToLower().Trim().Contains("dodge"))
                {
                    filteredCar.Add(allCars[i]);
                }
            }
            return filteredCar;
        }


        static List<Cars> Transfrom(string rawData)
        {
            List<Cars> cars = new List<Cars>();
            for (int i = 1; i < rawData.Length; i++)
            {
                cars.Add(Cars.Parsee(rawData));
            }
            return cars;
        }

        static List<Cars> GetTop10Fastest(List<Cars> cars)
        {
            List<Cars> fastestCars = new List<Cars>();

            for (int i = cars.Count - 1; i >= 10; i--)
            {
                fastestCars.Add(cars[i]);
            }

            return fastestCars;

        }

    }

}

