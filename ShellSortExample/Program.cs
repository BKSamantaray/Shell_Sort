using System;

namespace ShellSortExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 70, 30, 40, 10, 80, 20, 90, 110, 75, 60, 45, 199, 35, 2, 31, 22, 1, 11, 211, 100, 23, 55, 50 };
            WriteList("Unsorted List", num);
            int distance = 0;
            // Generate the distance as per the length of the list
            //It will consider maximum 3 list should generate
            for (int i = 1; i < num.Length; i++)
            {
                var div = num.Length / i;
                // Maximum 3 list should be generate
                if (div <= 3)
                {
                    distance = i;
                    break;
                }
            }
            // Do the grouping and Apply insertion sort
            for (int i = distance; i > 0; i--)
            {
                int tmpListVal = 0;
                for (int j = i; j < num.Length;)
                {
                    int tmpVal = num[j];
                    //Applying insertion sort with each shell/group element
                    for (int k = j - i; k >= 0; k -= i)
                    {
                        if (k <= num.Length - 1 && tmpVal < num[k])
                        {
                            num[k + i] = num[k];
                            num[k] = tmpVal;
                        }
                    }
                    if (j + i >= num.Length)
                    {
                        j = tmpListVal + 1;
                        tmpListVal = j;
                        if (j == i)
                        {
                            break;
                        }
                    }
                    else
                    {
                        j += i;
                    }
                }
            }
            WriteList("After applied shell sort",num);
        }
        static void WriteList(string msg, int[] list)
        {
            Console.WriteLine($"{msg} : ");
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write($" {list[i]}");
            }
            Console.Write("\r\n");
        }
    }
}
