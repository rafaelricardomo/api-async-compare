using AsyncCompare.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncCompare.Services
{
    public class BreakfastAsyncService
    {
        public async Task<List<string>> Start()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var result = new List<string>();

            Coffee cup = PourCoffee(result);
            result.Add("coffee is ready");

            var eggsTask = FryEggsAsync(2,result);
            var baconTask = FryBaconAsync(3,result);
            var toastTask = MakeToastWithButterAndJamAsync(2,result);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    result.Add("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    result.Add("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    result.Add("toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ(result);
            result.Add("oj is ready");
            result.Add("Breakfast is ready!");

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            result.Add("RunTime " + elapsedTime);

            return result;
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number, List<string> result)
        {
            var toast = await ToastBreadAsync(number,result);
            ApplyButter(toast,result);
            ApplyJam(toast,result);

            return toast;
        }

        private static Juice PourOJ(List<string> result)
        {
            result.Add("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast, List<string> result) =>
            result.Add("Putting jam on the toast");

        private static void ApplyButter(Toast toast, List<string> result) =>
            result.Add("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices, List<string> result)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                result.Add("Putting a slice of bread in the toaster");
            }
            result.Add("Start toasting...");
            await Task.Delay(3000);
            result.Add("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices, List<string> result)
        {
            result.Add($"putting {slices} slices of bacon in the pan");
            result.Add("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                result.Add("flipping a slice of bacon");
            }
            result.Add("cooking the second side of bacon...");
            await Task.Delay(3000);
            result.Add("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany, List<string> result)
        {
            result.Add("Warming the egg pan...");
            await Task.Delay(3000);
            result.Add($"cracking {howMany} eggs");
            result.Add("cooking the eggs ...");
            await Task.Delay(3000);
            result.Add("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee(List<string> result)
        {
            result.Add("Pouring coffee");
            return new Coffee();
        }
    }
}
