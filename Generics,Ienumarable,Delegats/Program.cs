namespace Generics_Ienumarable_Delegats
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Queue<int> numbers = new Queue<int>(new[] { 19, 55, 35 });

            List<string> names = new List<string> { "Apple", "Banana", "Apple" };

            List<string> names2 = new List<string> { "grape", "melon", "banana" };

            List<int> numbers2 = new List<int> { 4, 5, 6 };

            //foreach (var item in CustomFilter(numbers, isEven))
            //{
            //    Console.WriteLine(item);
            //}


            //foreach (var item in CustomTransfrom(numbers, transformLogic)) 
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in CustomRange(1, 20, NextInt))
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(CustomFindAllElement(names, "banana", existsString));


            //foreach (var item in CustomMerge(names2, names))
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(CustomCheckIfEmpty(numbers));

            //Console.WriteLine(CustomCheck(numbers, checkIfEven));

                Console.WriteLine(CustomCheckAll(numbers, checkIfAdult));

        }

        /// <summary>
        /// სიმრავლის ფილტრაცია და ახალი სიმრავლის დაბრუნება
        /// </summary>
        static IEnumerable<T> CustomFilter<T>(IEnumerable<T> collection, Func<T, bool> logic)
        {

            List<T> result = new List<T>();

            foreach (var item in collection)
            {
                if (logic(item))
                {
                    result.Add(item);

                }

            }
            return result;
        }
        static bool isEven(int number)
        {

            //if ( number % 2 == 0)
            //{
            //    return true;
            //}
            //return default;

            return number % 2 == 0;

        }





        /// <summary>
        /// სიმრავლის გარდაქმნა და ახალი სიმრავლის დაბრუნება
        /// </summary>
        static string transformLogic(int input)
        {
            return input.ToString();
        }
        static IEnumerable<Tresult> CustomTransfrom<Tsource, Tresult>(IEnumerable<Tsource> collection, Func<Tsource, Tresult> logic)
        {
            List<Tresult> result = new();

            foreach (var item in collection)
            {
                result.Add(logic(item));
            }
            return result;
        }






        /// <summary>
        /// აბრუნებს დიაპაზონს დაწყებული start მნიშვნელობიდან გადაითვლის start - ის შემდგომ count რაოდენობას
        /// მაგალითად Enumerable.Range(5,3) => [5,6,7]
        /// </summary>
        static IEnumerable<T> CustomRange<T>(T start, T end, Func<T, T> nextLogic) where T : IComparable<T>
        {
            List<T> result = new List<T>();
            T current = start;
            while (current.CompareTo(end) < 0)
            {
                result.Add(current);
                current = nextLogic(current);
            }
            return result;
        }
        static int NextInt(int current)
        {
            return current + 1;
        }





        /// <summary>
        /// ითვლის სიმრავლეში კონკრეტული ელემენტების რაოდენობას რაიმე პირობის მიხედვით ან მის გარეშე.
        /// აბრუნებს int
        /// </summary>
        static int CustomFindAllElement<T>(IEnumerable<T> collection, T userElement, Func<T, T, bool> logic)
        {
            int elementsCount = 0;

            foreach (var item in collection)
            {
                if (logic(item, userElement))
                {
                    elementsCount++;
                }
            }

            return elementsCount;
        }
        static bool existsString(string number, string userElement)
        {
            var normalizedNumber = number.Trim().ToLower();
            var normalizedUserElement = userElement.Trim().ToLower();

            return normalizedNumber == normalizedUserElement;
        }
        static bool existsInt(int number, int userElement)
        {
            return number == userElement;
        }




        /// <summary>
        /// აერთიაებს და აბრუნებს ორ IEnumerable - ს
        /// </summary>
        /// 
        static IEnumerable<T> CustomMerge<T>(IEnumerable<T> firstCollection, IEnumerable<T> secondCollection)
        {
            List<T> result = new List<T>();
            foreach (var item in firstCollection)
            {
                result.Add(item);
            }
            foreach (var item in secondCollection)
            {
                result.Add(item);
            }
            return result;

        }



        /// <summary>
        /// ამოწმებს სიმრავლე შეიცავს თუ არა ელემენტებს
        /// </summary>
        /// 

        static bool CustomCheckIfEmpty<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                return true;
            }
            return false;
        }




        /// <summary>
        /// ამოწმებს სიმრავლე შეიცავს თუ არა ელემენტებს კონკრეტული პირობით
        /// </summary>
        static bool CustomCheck<T>(IEnumerable<T> collection, Func<T, bool> check)
        {

            foreach (var item in collection)
            {
                if (check(item))
                {
                    return true;
                }
            }
            return false;
        }
        static bool checkIfAdult(int number)
        {
            return number >= 18;

        }


        /// <summary>
        /// ამოწმებს სიმრავლის ყველა ელემენტი აკმაყოფილებს თუ არა კონკრეტულ პირობას
        /// </summary>
        /// 
        static bool CustomCheckAll<T>(IEnumerable<T> collection, Func<T, bool> check)
        {
            foreach (var item in collection)
            {
                if (!check(item))
                {
                    return false;
                }
            }
            return true;


        }
        static bool startsWithUpper(string input)
        {
            return char.IsUpper(input[0]);
        }
    }
}
