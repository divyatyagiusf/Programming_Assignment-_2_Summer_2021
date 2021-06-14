using System;
using System.Collections.Generic;
using System.Linq;

namespace Programming_Assignment_2_Summer_2021
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Question1
              Console.WriteLine("Question 1");
              int[] nums1 = { 2, 5, 1, 3, 4, 7 };
              int[] nums2 = { 2, 1, 4, 7 };
              Intersection(nums1, nums2);
              Console.WriteLine("\n");


              //Question2 
              Console.WriteLine("Question 2");
              int[] nums = { 0, 1, 0, 3, 12 };
              Console.WriteLine("Enter the target number:");
              int target = Int32.Parse(Console.ReadLine());
              int pos = SearchInsert(nums, target);
              Console.WriteLine("Insert Position of the target is : {0}", pos);
              Console.WriteLine("");  

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            int Lnum = LuckyNumber(ar3);
            if (Lnum == -1)
                Console.WriteLine("Given Array doesn't have any lucky Integer");
            else
                Console.WriteLine("Lucky Integer for given array {0}", Lnum);

            Console.WriteLine();
        

            //Question 4
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter the value for n:");
            int n = Int32.Parse(Console.ReadLine());
            int Ma = GenerateNums(n);
            Console.WriteLine("Maximun Element in the Generated Array is {0}", Ma);
            Console.WriteLine();

            //Question 5

            Console.WriteLine("Question 5");
            List<List<string>> cities = new List<List<string>>();
            cities.Add(new List<string>() { "London", "New York" });
            cities.Add(new List<string>() { "New York", "Tampa" });
            cities.Add(new List<string>() { "Delhi", "London" });
            string Dcity = DestCity(cities);
            Console.WriteLine("Destination City for Given Route is : {0}", Dcity);

            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int K = 3;
            RotateArray(arr, K);
            Console.WriteLine("\n");

            //Question 9
            Console.WriteLine("Question 9");
            int[] arr9 = { 7, 1, 5, 3, 6, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int[] costs = { 10, 15, 20 };
            int minCost = MinCostToClimb(costs);
            Console.WriteLine("Minium cost to climb the top stair {0}", minCost);
            Console.WriteLine();
        }

        //Question 1



        public static void Intersection(int[] nums1, int[] nums2)
        {
            try
            {
                var comman_elements = nums1.Intersect(nums2);
                foreach (int elements in comman_elements)
                {
                    Console.Write(elements + " ");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /* Que 1 Self-reflection
         * Learned the use of Enumerable.Intersect Method from system.Linq
         * Complexity is O(M+N) since Intersect will build hashset for second sequence and use 
         * every value against it. */

        //Question 2
        public static int SearchInsert(int[] nums, int target)
        {
            try
            {

                int low = 0;
                int high = nums.Length - 1;
                int mid = high / 2;
                while (high != low)
                {
                    if (target == nums[mid]) return mid;
                    else if (target < nums[mid])
                    {
                        high = mid;
                        mid = (high - low) / 2 + low;
                    }
                    else
                    {
                        low = mid + 1;
                        mid = (high - low) / 2 + low;
                    }
                }
                return target > nums[high] ? high + 1 : high;
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }   

        /* Que 2 Self-reflection
        * Implemented binary search
        * Time Complexity is O(logn)
        * Space Complexity is O(1) */



        //Question 3

        private static int LuckyNumber(int[] ar3)
        {
            try
            {
                Array.Sort(ar3);
                int count = 1;

                for (int i = ar3.Length - 2; i > -1; i--)
                {
                    if (ar3[i] == ar3[i + 1]) count++;
                    else
                    {
                        if (ar3[i + 1] == count) return count;
                        count = 1;
                    }
                }

                if (count == ar3[0]) return count;

                return -1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 4

        private static int GenerateNums(int n)
        {
            try
            {
                {
                    int[] result = new int[n + 1];

                    if (n < 2)
                    {
                        return n;
                    }

                    result[1] = 1;

                    for (int i = 1; 2 * i <= n; i++)
                    {
                        int next = 2 * i;
                        result[next] = result[i];

                        if (next + 1 <= n)
                        {
                            result[next + 1] = result[i] + result[i + 1];
                        }
                    }

                    return result.Max();
                    return -1;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /* Que 4 Self-reflection
        * Time Complexity is O(N)
        * Space Complexity is O(1) */

        //Question 5

        public static string DestCity(List<List<string>> paths)
        {
            try
            {
                var start = new HashSet<string>();
                var end = new HashSet<string>();
                foreach (var path in paths)
                {
                    if (end.Contains(path[0]))
                        end.Remove(path[0]);
                    else
                        start.Add(path[0]);

                    if (start.Contains(path[1]))
                        start.Remove(path[1]);
                    else
                        end.Add(path[1]);
                }

                return end.First();

            }
            catch (Exception)
            {

                throw;
            }
        }

        /* Que 4 Self-reflection
         * Implemented 2 hashsets 
         * Time Complexity is O(N)
         * Space Complexity is O(1) */


        //Question 6

        private static void targetSum(int[] nums, int target)
        {
            try
            {

                int i = 0;
                int j = 1;
                while (j < nums.Length)
                {
                    if (nums[i] + nums[j] == target)
                        break;
                    else if (nums[i] + nums[j] < target)
                    {
                        i++;
                        j++;
                    }
                    else if (nums[i] + nums[j] > target)
                        i--;
                }
                Console.WriteLine("[" + (i + 1) + "," + (j + 1) + "]");
                return;


            }

            catch (Exception)
            {

                throw;
            }
        }


        /* Que 6 Self-reflection
         * Time Complexity is O(N)
         * Space Complexity is O(1) */

        //Question 7
        private static void HighFive(int[,] items)
        {
            try
            {
                Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
                var marks = new List<int>();
                for (int i = 0; i < items.Length / 2; i++)
                {
                    if (!map.ContainsKey(items[i, 0]))
                    {
                      
                        marks = new List<int>();
                        map.Add(items[i, 0], marks);
                    }
                    else
                    {
                        marks = map[items[i, 0]];
                    }
                    marks.Add(items[i, 1]);
                    map[items[i, 0]] = marks;
                }
                foreach (var pair in map)
                {
                    int key = pair.Key;
                    List<int> value = pair.Value;
                    value.Sort();
                    value.Reverse();
                    int sum = 0;
                    for (int i = 0; i < 5; i++)
                    {

                        sum = sum + value[i];
                    }

                    Console.WriteLine("[" + key + "," + sum / 5 + "]");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        /* Que 7 Self-reflection
         * Implemented Dictionary 
         * Time Complexity is O(N)
         * Space Complexity is O(1) */

        //Question 8

        public static void RotateArray(int[] arr, int n)
        {
            try
            {

                int length = arr.Length;
                n = n % length;

                for (int i = 0; i < length; i++)
                {
                   
                    if (i < n)
                    {
                        Console.Write(arr[length + i - n] + " ");
                    }
                    else
                    {
                        Console.Write(arr[i - n] + " ");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /* Que 8 Self-reflection
        * Time Complexity is O(N)
        * Space Complexity is O(1) */

        //Question 9
        private static int MaximumSum(int[] arr)
        {
            try
            {
                int max = arr[0];
                int currentMax = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    currentMax = System.Math.Max((currentMax + arr[i]), arr[i]);
                    max = System.Math.Max(max, currentMax);
                }

                return max;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /* Que 9 Self-reflection
         * Learned and implemented built in Math method
         * Time Complexity is O(N)
         * Space Complexity is O(1) */


        //Question 10


       public static int MinCostToClimb(int[] costs)
        {
            try
            {
                if (costs.Length > 1)
                {
                    int result = costs[0];
                    if (costs.Length > 2)
                    {
                        for (int i = 2; i < costs.Length; i++)
                        {
                            costs[i] = costs[i] + (costs[i - 1] < costs[i - 2] ? costs[i - 1] : costs[i - 2]);
                        }
                        result = costs[costs.Length - 1] < costs[costs.Length - 2] ? costs[costs.Length - 1] : costs[costs.Length - 2];
                    }
                    return result;
                }
                return 0;



            }
            catch (Exception)
            {

                throw;
            }
        }

        /* Que 10 Self-reflection
        * Learned and implemented the concept of dynamic programming
        * Time Complexity is O(N)
        * Space Complexity is O(1) */

    }

}
