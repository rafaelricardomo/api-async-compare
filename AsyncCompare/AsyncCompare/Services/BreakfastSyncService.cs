using AsyncCompare.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncCompare.Services
{
    public class BreakFastSyncService
    {
        public  List<string> Start()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();  

            var result = new List<string>();

            Coffee cup = PourCoffee(result);
            result.Add("coffee is ready");

            Egg eggs = FryEggs(2, result);
            result.Add("eggs are ready");

            Bacon bacon = FryBacon(3, result);
            result.Add("bacon is ready");

            Toast toast = ToastBread(2, result);
            ApplyButter(toast,result);
            ApplyJam(toast, result);
            result.Add("toast is ready");

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

        private  Juice PourOJ(List<string> result)
        {
            result.Add("Pouring orange juice");
            return new Juice();
        }

        private  void ApplyJam(Toast toast, List<string> result) =>
            result.Add("Putting jam on the toast");

        private  void ApplyButter(Toast toast, List<string> result) =>
            result.Add("Putting butter on the toast");

        private  Toast ToastBread(int slices, List<string> result)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                result.Add("Putting a slice of bread in the toaster");
            }
            result.Add("Start toasting...");
            Task.Delay(3000).Wait();
            result.Add("Remove toast from toaster");

            return new Toast();
        }

        private  Bacon FryBacon(int slices, List<string> result)
        {
            result.Add($"putting {slices} slices of bacon in the pan");
            result.Add("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                result.Add("flipping a slice of bacon");
            }
            result.Add("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            result.Add("Put bacon on plate");

            return new Bacon();
        }

        private  Egg FryEggs(int howMany , List<string> result)
        {
            result.Add("Warming the egg pan...");
            Task.Delay(3000).Wait();
            result.Add($"cracking {howMany} eggs");
            result.Add("cooking the eggs ...");
            Task.Delay(3000).Wait();
            result.Add("Put eggs on plate");

            return new Egg();
        }

        private  Coffee PourCoffee(List<string> result)
        {
            result.Add("Pouring coffee");
            return new Coffee();
        }
    }
}
