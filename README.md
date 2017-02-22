# Async Programming
# C#6.0  .NET Framework 4.6

----

### Purpose

If you are new to the topic of multithreading, you might wonder what exactly an asynchronous method invocation is all about. As you are no doubt fully aware, some programming operations take time. Imagine that you built a singlethreaded application that is invoking a method on a remote web service operation, calling a method performing a long-running database query, downloading a large document, or writing 500 lines of text to an external file. While performing these operations, the application could appear to hang for some amount of time. Until the task at hand has been processed, all other aspects of this program (such as menu activation, toolbar clicking, or console output) are suspended (which can aggravate users). 

----

###  The Asynchronous Nature of Delegates
How can you tell a delegate to invoke a method on a separate thread of execution to simulate numerous tasks performing “at the same time”? The good news is that every .NET delegate type is automatically equipped with this capability. The even better news is that you are not required to directly dive into the details of the System.Threading namespace to do so (although these entities can quite naturally work hand in hand). When the C# compiler processes the delegate keyword, the dynamically generated class defines two methods named BeginInvoke() and EndInvoke(). The first set of parameters passed into BeginInvoke() will be based on the format of the C# delegate (two integers, in the case of BinaryOp). The final two arguments will always be System.AsyncCallback and System.Object. Also note that the return value of EndInvoke() is an integer, based on the return type of BinaryOp, while the single parameter of this method is always of type IAsyncResult.
