using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace MeanMode
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        public static bool MeanMode(int[] array)
        {
            
            return computeMode(array) == computeAverage(array);
        }

        // TODO
        private static double computeAverage(int[] array)
        {
            int sum = 0;

            foreach(int item in array)
            {
                sum = sum + item;
            }

            int average = sum / array.Length;
            return average;
        }

        // TODO
        private static double? computeMode(int[] array)
        {
            // Dictionary Idea and main function idea used from old coding assignment for finding Mode
            Dictionary<int, int> modes = new Dictionary<int, int>();

            // following code partially used from www.geeksforgeeks.org/mode/
            foreach (var item in array)
            {
                if (modes.ContainsKey(item))
                {
                    modes[item]++;
                }
                modes[item] = 1;
            }

            int mode = 0;
            int max = 0;
            foreach (int key in modes.Keys)
            {
                if (modes[key] > max)
                {
                    max = modes[key];
                    mode = key;
                }
            }

            return mode;
        }
    }
}
