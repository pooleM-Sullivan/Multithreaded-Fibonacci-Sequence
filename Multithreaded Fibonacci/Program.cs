using System;
using System.Threading;
class Program
{
    // Calculating the actual numbers in the Fibonacci sequence.
    static long Fibonacci(int n)
    {
        if (n <= 1)
            return n;
        else
            return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
    static void FibonacciThread(object obj)
    {
        int n = (int)obj;
        Console.WriteLine($"Fibonacci({n}) = {Fibonacci(n)}");
    }
    // Now that we have functions for calculating, we need to add multi-threading.
    static void Main()
    {
        int numberOfThreads = 10; // The amount of numbers that are calculated.
        Thread[] threads = new Thread[numberOfThreads];
        // Creating and starting threads.
        for (int i = 0; i < numberOfThreads; i++)
        {
            int n = i;
            threads[i] = new Thread(new ParameterizedThreadStart(FibonacciThread));
            threads[i].Start(n);
        }
    }
}