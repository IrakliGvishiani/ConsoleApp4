namespace Generics_Ienumarable_Delegats
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Queue<int> numbers = new Queue<int>(new[] { 1655, 2, 3 });

            List<string> names = new List<string> { "Apple", "Banana", "Apple", "Melon", "Melon" };

            List<string> names2 = new List<string> { "grape", "melon", "banana" };

            List<int> numbers2 = new List<int> { 4, 5, 6, 4, 4, 4, 4, 4, 4, 6,67 };

            Stack<double> doubleNumbers = new Stack<double>(new[] { 1.5, 2.5, 3.5 });

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

            //Console.WriteLine(CustomCheckAll(numbers, checkIfAdult));

            //Console.WriteLine(CustomFirstOrDefault(names, checkIfStartsWithUpper));

            //Console.WriteLine(CustomLastOrDefault(names, checkIfStartsWithUpper));

            //    foreach (var item in CustomUniqueElements(numbers2))
            //{
            //    Console.WriteLine($"{item}");
            //}

            //    foreach (var item in CustomUnion(numbers, numbers2))
            //    {
            //        Console.WriteLine($"{item}");
            //}

            //    foreach (var item in CustomReverse(numbers))
            //    {
            //        Console.WriteLine($"{item}");
            //}


            //Console.WriteLine(CustomSum(doubleNumbers, sumLogicDouble));


            //Console.WriteLine(CustomMax(doubleNumbers, maxLogicDouble));

            Console.WriteLine(CustomMin(numbers2, minLogicInt));

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



        /// <summary>
        /// სიმრავლის პირველივე ელემენტი კონკრეტული პირობით ან default
        /// </summary>
        /// 

        static T CustomFirstOrDefault<T>(IEnumerable<T> collection, Func<T, bool> check)
        {
            foreach (var item in collection)
            {
                if (check(item))
                {
                    return item;
                }
            }
            return default(T);
        }
        static bool checkIfStartsWithUpper(string input)
        {
            return char.IsUpper(input[0]);
        }



        /// <summary>
        /// სიმრავლის ბოლო ელემენტი კონრკეტული პირობით ან default
        /// </summary>
        static T CustomLastOrDefault<T>(IEnumerable<T> collection, Func<T, bool> check)
        {
            T lastMatch = default(T);
            foreach (var item in collection)
            {
                if (check(item))
                {
                    lastMatch = item;
                }
            }
            return lastMatch;
        }



        /// <summary>
        /// უნიკალური ელემენტები
        /// </summary>
        /// 

        static IEnumerable<T> CustomUniqueElements<T>(IEnumerable<T> collection)
        {


            HashSet<T> uniqueElements = new HashSet<T>();

            foreach (var item in collection)
            {
                uniqueElements.Add(item);
            }

            return uniqueElements;
        }


        /// <summary>
        /// ორი სიმრავლიდან ელემენტების გაერთიანება
        /// </summary>
        /// 

        static IEnumerable<T> CustomUnion<T>(IEnumerable<T> firstCollection, IEnumerable<T> secondCollection)
        {
            HashSet<T> uniqueElements = new HashSet<T>();
            foreach (var item in firstCollection)
            {
                uniqueElements.Add(item);
            }
            foreach (var item in secondCollection)
            {
                uniqueElements.Add(item);
            }
            return uniqueElements;


        }



        /// <summary>
        /// სიმრავლის დატრიალება
        /// </summary>
        static IEnumerable<T> CustomReverse<T>(IEnumerable<T> collection)
        {

            Stack<T> stack = new Stack<T>();

            foreach (var item in collection)
            {
                stack.Push(item);
            }

            return stack;

        }



        /// <summary>
        /// სიმრავლის ელემენტების შეჯამება
        /// </summary>

        static T CustomSum<T>(IEnumerable<T> collection, Func<T, T, T> logic)
        {

            T sum = default;

            foreach (var item in collection)
            {
                sum = logic(sum, item);
            }
            return sum;

        }
        static int sumLogicInt(int a, int b)
        {
            return a + b;
        }
        static double sumLogicDouble(double a, double b)
        {
            return a + b;
        }


        /// <summary>
        /// სიმრავლის მაქსიმალური ელემენტი
        /// </summary>
        /// 

        static T CustomMax<T>(IEnumerable<T> collection, Func<T, T, bool> logic)
        {
            T max = default(T);
            foreach (var item in collection)
            {
                if (logic(item, max))
                {
                    max = item;
                }
            }
            return max;
        }
        static bool maxLogicInt(int a, int b)
        {
            return a > b;
        }
        static bool maxLogicDouble(double a, double b)
        {
            return a > b;
        }



        /// <summary>
        /// სიმრავლის მინიმალური ელემენტი
        /// </summary>
        /// 

        static T CustomMin<T>(IEnumerable<T> collection, Func<T, T, bool> logic)
        {
            T min = default;
            bool first = true;

            foreach (var item in collection)
            {
                if (first)
                {
                    min = item;
                    first = false;
                    continue;
                }

                if (logic(item, min))
                {
                    min = item;
                }
            }
            return min;
        }
        static bool minLogicInt(int a, int b)
        {
            return a < b;
        }
        static bool minLogicDouble(double a, double b)
        {
            return a < b;
        }
    }
}
