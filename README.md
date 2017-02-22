# Async Programming
# C#6.0  .NET Framework 4.6

----

### Purpose

If you are new to the topic of multithreading, you might wonder what exactly an asynchronous method invocation is all about. As you are no doubt fully aware, some programming operations take time. Imagine that you built a singlethreaded application that is invoking a method on a remote web service operation, calling a method performing a long-running database query, downloading a large document, or writing 500 lines of text to an external file. While performing these operations, the application could appear to hang for some amount of time. Until the task at hand has been processed, all other aspects of this program (such as menu activation, toolbar clicking, or console output) are suspended (which can aggravate users). 

----

###  The Asynchronous Nature of Delegates
How can you tell a delegate to invoke a method on a separate thread of execution to simulate numerous tasks performing “at the same time”? The good news is that every .NET delegate type is automatically equipped with this capability. The even better news is that you are not required to directly dive into the details of the System.Threading namespace to do so (although these entities can quite naturally work hand in hand). When the C# compiler processes the delegate keyword, the dynamically generated class defines two methods named BeginInvoke() and EndInvoke(). The first set of parameters passed into BeginInvoke() will be based on the format of the C# delegate (two integers, in the case of BinaryOp). The final two arguments will always be System.AsyncCallback and System.Object. Also note that the return value of EndInvoke() is an integer, based on the return type of BinaryOp, while the single parameter of this method is always of type IAsyncResult.

----

### The System.Threading Namespace

Under the .NET platform, the System.Threading namespace provides a number of types that enable the direct construction of multithreaded applications. In addition to providing types that allow you to interact with a particular CLR thread, this namespace defines types that allow access to the CLR- maintained thread pool, a simple (non-GUI-based) Timer class, and numerous types used to provide synchronized access to shared resources. The most primitive of all types in the System.Threading namespace is Thread. This class
represents an object-oriented wrapper around a given path of execution within a particular AppDomain. This type also defines a number of methods (both static and instance level) that allow you to create new threads within the current AppDomain, as well as to suspend, stop, and destroy a particular thread. 


----

### Foreground Threads and Background Threads

Now that you have seen how to programmatically create new threads of execution using the System.Threading namespace, let’s formalize the distinction between foreground threads and background threads.
Foreground threads have the ability to prevent the current application from terminating. The CLR will not shut down an application (which is to say, unload the hosting AppDomain) until all foreground threads have ended. 
Background threads (sometimes called daemon threads) are viewed by the CLR as expendable paths of execution that can be ignored at any point in time (even if they are currently laboring over some unit of work). Thus, if all foreground threads have terminated, any and all background threads are automatically killed when the application domain unloads.

