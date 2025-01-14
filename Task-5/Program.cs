﻿using System;
using System.Diagnostics;

namespace Task_5
{
    internal class Program
    {
		static string FileName = "Test-5.txt";

		static void Main(string[] args)
        {
			try
			{
				Vector vector = new Vector(FileName); // reading from the file "FileName"
				if (vector.GetLength() == 0) // reading error
                {
					return;
                }
				Console.WriteLine("The vector read from "+ FileName+" (size = "+vector.GetLength()+ "):");
				Console.WriteLine(vector);
				Console.WriteLine();
				Console.WriteLine("Merge Sort:");

				Stopwatch timewatch = new Stopwatch(); // for time counting
				timewatch.Start();
				vector.SplitMergeSort();
				timewatch.Stop();
				TimeSpan mergetime = timewatch.Elapsed;
				Console.WriteLine(vector);
				Console.WriteLine("Time passed: {0} seconds", mergetime.Seconds + mergetime.Milliseconds / 1000m);
				Console.WriteLine();
				
				Console.WriteLine("Random vector from 1 to {0} without repeats:", vector.GetLength());
				vector.InitShuffle();
				Console.WriteLine(vector);
				Console.WriteLine();
				Console.WriteLine("Merge Sort:");
				timewatch.Restart();
				vector.SplitMergeSort();
				timewatch.Stop();
				mergetime = timewatch.Elapsed;
				Console.WriteLine(vector);
				Console.WriteLine("Time passed: {0} seconds", mergetime.Seconds + mergetime.Milliseconds / 1000m);
				Console.WriteLine();

				Console.WriteLine("Another random vector from 1 to {0} without repeats:", vector.GetLength());
				vector.InitShuffle();
				Console.WriteLine(vector);
				Console.WriteLine();
				Console.WriteLine("Heap Sort:");
				timewatch.Restart();
				vector.HeapSort();
				timewatch.Stop();
				mergetime = timewatch.Elapsed;
				Console.WriteLine(vector);
				Console.WriteLine("Time passed: {0} seconds", mergetime.Seconds + mergetime.Milliseconds / 1000m);
				Console.WriteLine();

				int[] sizes = { 1000, 10000, 100000, 1000000, 10000000 };

				Console.WriteLine("Testing HeapSort times for random vectors of sizes from 1,000 to 10,000,000:");
				foreach (int size in sizes)
                {
					Vector largeVector = new Vector(size);
					largeVector.RandomInitialization(0, size-1);
					timewatch.Restart();
					largeVector.HeapSort();
					timewatch.Stop();
					mergetime = timewatch.Elapsed;
					Console.WriteLine("Size {0,8}: {1} seconds", size, mergetime.Seconds + mergetime.Milliseconds / 1000m);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
    }
}
