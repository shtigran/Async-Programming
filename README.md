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

----

### Parallel Programming Using the Task Parallel Library

At this point in the chapter, you have examined two programming techniques (using asynchronous delegates and via the members of System.Threading) that allow you to build multithreaded software. Recall that both of these approaches will work under any version of the .NET platform. Beginning with the release of .NET 4.0, Microsoft introduced a new approach to multithreaded application development using a parallel programming library termed the Task Parallel Library (TPL). Using the types of System.Threading.Tasks, you can build fine-grained, scalable parallel code without having to work directly with threads or the thread pool. This is not to say, however, that you will not use the types of System.Threading when you use the TPL. In reality, these two threading toolkits can work together quite naturally. This is especially true in that the System.Threading namespace still provides a majority of the synchronization primitives you examined previously (Monitor, Interlocked, and so forth). This being said, you will quite likely find that you will favor working with the TPL rather than the original System.Threading namespace, given that the same set of tasks can be performed in a more
straightforward manner.

----

### The System.Threading.Tasks Namespace

Collectively speaking, the types of System.Threading.Tasks are referred to as the Task Parallel Library. The TPL will automatically distribute your application’s workload across available CPUs dynamically, using the CLR thread pool. The TPL handles the partitioning of the work, thread scheduling, state management, and other low-level details. The end result is that you can maximize the performance of your .NET applications, while being shielded from many of complexities of directly working with threads.

----

### Parallel LINQ Queries (PLINQ)

To wrap up your look at the TPL, be aware that there is another way you can incorporate parallel tasks into your .NET applications. If you choose, you can use a set of extension methods, which allow you to construct a LINQ query that will perform its workload in parallel (if possible). Fittingly, LINQ queries that are designed to run in parallel are termed PLINQ queries. Like parallel code authored using the Parallel class, PLINQ has the option of ignoring your request to process the collection in parallel if need be. The PLINQ framework has been optimized in numerous ways, which includes determining whether a query would, in fact, perform faster in a synchronous manner.
At runtime, PLINQ analyzes the overall structure of the query, and if the query is likely to benefit from parallelization, it will run concurrently. However, if parallelizing a query would hurt performance, PLINQ just runs the query sequentially. If PLINQ has a choice between a potentially expensive parallel algorithm or an inexpensive sequential algorithm, it chooses the sequential algorithm by default.

----

### Asynchronous Calls with the async Keyword
To be sure, building, debugging,and understanding complex multithreaded applications is a challenge in any framework. While the TPL, PLINQ, and the delegate type can simplify matters to some extent (especially when compared toother platforms and languages), developers are still required to be fairly savvy with the ins and outs of various advanced techniques.
Since the release of .NET 4.5, the C# programming language (and for that matter, the VB programming language) has been updated with two new keywords that further simplify the process of authoring asynchronous code. In contrast to all the examples in here, when you use the new async and await keywords, the compiler will generate a good deal of threading code on your behalf, using numerous members of the System.Threading and System.Threading.Tasks namespaces.

----

### A First Look at the C# async and await Keywords

The async keyword of C# is used to qualify that a method, lambda expression, or anonymous method should be called in an asynchronous manner automatically. Yes, it’s true. Simply by marking a method with the async modifier, the CLR will create a new thread of execution to handle the task at hand. Furthermore, when you are calling an async method, the await keyword will automatically pause the current thread from any further activity until the task is complete, leaving the calling thread free to continue on its merry way.

