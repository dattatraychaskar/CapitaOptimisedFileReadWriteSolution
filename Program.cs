using System;

namespace CapitaOptimisedFileReadWriteSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //calculate the code execution time
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            // Process files
            ReadWriteFile readWriteFile = new ReadWriteFile();
            readWriteFile.ManiculateFileData();

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            Console.ReadKey();
        }
    }
}
