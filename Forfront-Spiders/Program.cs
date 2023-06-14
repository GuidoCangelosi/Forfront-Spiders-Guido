
using System;

namespace Forfront.Spiders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunProcess();
        }
        static void RunProcess()
        {
            using (SpidersUtility spiders = new SpidersUtility())
            {
                string input = string.Empty;
                string result = string.Empty;
                bool isValidInput = false;
                Console.WriteLine("Forfront Spiders");
                Console.WriteLine("Please enter 3 lines of input");

                SpiderContainer spiderContainer = new SpiderContainer();

                Console.WriteLine("1. size of the wall");
                isValidInput = false;
                input = string.Empty;
                while (!isValidInput)
                {
                    Console.WriteLine("   height width (example: 7 14) (minimum 5 / maximum 20)");
                    input = Console.ReadLine();
                    isValidInput = spiders.ValidateWallSize(input);
                }
                spiders.GetWallSize(input, spiderContainer);

                Console.WriteLine("2. initial location and direction of spider");
                isValidInput = false;
                input = string.Empty;
                while (!isValidInput)
                {
                    Console.WriteLine("   X Y DIR (example: 4 11 Right) (minimum 5 / maximum 20) (directions can be: Left Right Up Down)");
                    input = Console.ReadLine();
                    isValidInput = spiders.ValidateSpiderInitialLocation(input);
                }
                spiders.GetInitialLocation(input, spiderContainer);

                Console.WriteLine("3. Path followed by spider");
                isValidInput = false;
                input = string.Empty;
                while (!isValidInput)
                {
                    Console.WriteLine("   any number of directions (example: FLLRFFLFLFR) (directions can be: L=Left R=Right Forward=F)");
                    input = Console.ReadLine();
                    isValidInput = spiders.ValidateSpiderWaypoints(input);
                }
                spiders.GetWaypoints(input, spiderContainer);

                result = spiders.ComputeResult(spiderContainer);

                Console.WriteLine("Result for spider location/orientation");
                Console.WriteLine(result);

                Console.ReadKey();
            }
        }
    }
}
