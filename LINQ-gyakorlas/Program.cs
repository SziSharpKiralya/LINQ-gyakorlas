using System.Net.Http.Headers;

namespace LINQ_gyakorlas
{
    internal class Program
    {
        static void Normal()
        {
            List<int> nums = new List<int>
            {
                4, 12, 7, 25, 10, 18, 3
            };

            List<int> results = new List<int>();

            foreach (var item in nums)
            {
                if (item > 10)
                {
                    results.Add(item);
                }
            }

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        static void LINQ()
        {
            List<int> nums = new List<int>
            {
                4, 12, 7, 25, 10, 18, 3
            };

            List<int> results = nums.Where(item => item > 10).ToList();

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        static void LINQ_MethodSyntax()
        {
            int[] nums = { 8, 3, 12, 5, 20, 7 };

            var result = nums.Where(item => item > 6).ToList().OrderBy(item => item);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void LINQ_OtherSyntax()
        {
            int[] nums = { 8, 3, 12, 5, 20, 7 };

            var result =
                from item in nums
                where item > 6
                orderby item
                select item;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            //LINQ_MethodSyntax(); // Lambda-kifejezések
            //LINQ_OtherSyntax(); // Ritkán használt kifejezés

        }
    }
}
