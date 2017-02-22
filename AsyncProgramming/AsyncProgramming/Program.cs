using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming
{

  public delegate int BinaryOp(int x, int y);

  class Program
  {
    static void Main(string[] args)
    {
      // Multithreaded, Parallel, and Async Programming

      //Invoking a Method Asynchronously by delegate

      Console.WriteLine("***** Async Delegate Invocation *****");
      // Print out the ID of the executing thread.
      Console.WriteLine("Main() invoked on thread {0}.",
      Thread.CurrentThread.ManagedThreadId);
      // Invoke Add() on a secondary thread.
      BinaryOp b = new BinaryOp(Add);
      IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);
      // Do other work on primary thread...
      Console.WriteLine("Doing more work in Main()!");
      // Obtain the result of the Add()
      // method when ready.
      int answer = b.EndInvoke(iftAR);
      Console.WriteLine("10 + 10 is {0}.", answer);

      Console.ReadKey();
    }

    public static int Add (int a, int b)
    {
      Console.WriteLine("Method invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
      return a + b;
    }
  }
}
