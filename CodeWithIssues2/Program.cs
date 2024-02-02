
using AsyncIssues;

internal class Program
{
    private static void Main(string[] args)
    {
        var theSystem = new SomeOtherSytem();

        UseOfSomeOtherSystem1(theSystem);
        UseOfSomeOtherSystem2(theSystem);
        UseOfSomeOtherSystem3(theSystem);
        UseOfSomeOtherSystem4(theSystem);

        Thread.Sleep(3000);
    }

    private static void UseOfSomeOtherSystem1(SomeOtherSytem system)
    {
        var ctx = new DataContext();

        // Does the error of not awaiting BUT we get a warning!
        system.SaveStateAsync(ctx);
        ctx.Close();

        // This is a case developer gets a warning by the 'standard .net' code analyzers because he or she 
        // calls an async method like a void method AND not store the returned Task (which would indicate
        // some strategy to handle awaiting effectively)
        
        // Developer should ALSO known from the Async in the name...
    }

    private static void UseOfSomeOtherSystem2(SomeOtherSytem system)
    {
        var ctx = new DataContext();

        // Do the error of not awaiting AND NO warning
        var task = system.SaveStateAsync(ctx);
        ctx.Close();

        // Reason is code analyzer observe developer take care of return value of a not awaited
        // async method which is a Task so assumed she / he know what she / he is doing. 
        // In this case the analyzers think to highly of developer... 
    }

    private static void UseOfSomeOtherSystem3(SomeOtherSytem system)
    {
        var ctx = new DataContext();

        // Do the error of not awaiting AND NO warning
        _ = system.SaveStateAsync(ctx);
        ctx.Close();

        // Reason is code analyzer observe developer take care of return value of a not awaited
        // async method which is a Task so assumed she / he know what she / he is doing. 
        // In this case the analyzers think to highly of developer...
        //
        // Only difference between this case and UseOfSystem2 is that developer explicit ignore
        // the Task, still reason to think developer know what hen is doing... Sadely...
    }

    private static void UseOfSomeOtherSystem4(ISomeOtherSystem system)
    {
        var ctx = new DataContext();

        // Do the error of not awaiting AND NO warning!
        system.SaveStateAsync(ctx); 
        ctx.Close();

        // This may be bit surprising and understandable reason for missing await:
        // It is very similar to case 1 WHERE we get a warning.
        //
        // Difference is we here are referencing an interface not an instance.
        // Interface methods that return Task does not require the implementation to be
        // async but the client can't assume it is not so should always await.
        //
        // But CS4014 only report on calling implementation method with the async
        // keyword in signature and interfaces methods can not have that.
        //
        // However SomeOtherSystem developers try to communicate method probably
        // should be awaited by the Async the the name...
    }

}
