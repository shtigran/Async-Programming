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

      # region ByDelegates
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
      #endregion

      #region BySystemThreadingInfo
    
        // Be sure to import the System.Threading namespace.
        Console.WriteLine("***** Primary Thread stats *****\n");
        // Obtain and name the current thread.
        Thread primaryThread = Thread.CurrentThread;
        primaryThread.Name = "ThePrimaryThread";
        // Show details of hosting AppDomain/Context.
        Console.WriteLine("Name of current AppDomain: {0}",Thread.GetDomain().FriendlyName);
        Console.WriteLine("ID of current Context: {0}",Thread.CurrentContext.ContextID);
        // Print out some stats about this thread.
        Console.WriteLine("Thread Name: {0}", primaryThread.Name);
        Console.WriteLine("Has thread started?: {0}",primaryThread.IsAlive);
        Console.WriteLine("Priority Level: {0}", primaryThread.Priority);
        Console.WriteLine("Thread State: {0}",primaryThread.ThreadState);


      #endregion

      #region ManuallyCreatingSecondThread


      #endregion
      Console.ReadKey();
    }

    public static int Add (int a, int b)
    {
      Console.WriteLine("Method invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
      return a + b;
    }
  }
}
