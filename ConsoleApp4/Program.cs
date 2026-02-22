namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = { 1, 2, 3, 4, 5, 6 };
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            //var lastEven = FindLast(numbers, isEven);
            //Console.WriteLine($"The last even number is: {lastEven}");


        }


        public static T FindFirstElement<T>(Stack<T> stack, T elementToFind)
        {
        
            foreach (var item in stack)
                {
                    if (item.Equals(elementToFind))
                        return item;
            }

            return default;
        }

        public static Stack<T> Take<T>(Stack<T> stack, int max)
        {
            Stack<T> result = new();
            Stack<T> temp = new();

            int count = 0;

            foreach (var item in stack)
            {
                if (count >= max)
                    break;

                temp.Push(item);
                count++;
            }

            foreach (var item in temp)
            {
                result.Push(item);
            }

            return result;
        }


        public static bool FindAnyNumberExist<T>(Queue<T> intList, T elementToFind)
        {
    
            foreach (var item in intList)
            {
                if (item.Equals(elementToFind))
                    return true;
            }

            return false;
        }

        public static HashSet<T> FindAllMatchingElements<T>(HashSet<T> intList, T elementToFind)
        {
            HashSet<T> result = new();

                foreach (var item in intList)
                {
                    if (item.Equals(elementToFind))
                        result.Add(item);
            }

            return result;
        }

        public static T FindFirstIndex<T>(LinkedList<T> intList, T elementToFind)
        {

            var currentNode = intList.First;

            while (currentNode != null) { 
                if(currentNode.Value.Equals(elementToFind))
                    return currentNode.Value;

                currentNode = currentNode.Next;
            }


            return default;
        }

        public static T FindLastElement<T>(IEnumerable<T> intList, T elementToFind)
        {
            T lastElement = default;

            foreach (var item in intList)
                {
                if (item.Equals(elementToFind))
                    lastElement = item;
            }


            //for (int i = intList.Count - 1; i >= 0; i--)
            //{
            //    if (intList[i].Equals(elementToFind))
            //        return intList[i];
            //}

            return lastElement;
        }

        public static bool FindAllNumberExist<T>(Queue<T> intList, T elementToFind)
        {
            //for (int i = 0; i < intList.Count; i++)
            //{
            //    if (!intList[i].Equals(elementToFind))
            //        return false;
            //}

            foreach (var item in intList)
            {
                if (!item.Equals(elementToFind))
                    return false;
            }

            return true;
        }






    }
}
