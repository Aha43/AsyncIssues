
using AsyncIssues;

internal class Program
{
    private static void Main(string[] args)
    {
        var theSystem = new SomeSytem();

        UseOfSomeSystem1(theSystem);
        UseOfSomeSystem2(theSystem);
        UseOfSomeSystem3(theSystem);
        UseOfSomeSystem4(theSystem);

        Thread.Sleep(3000);
    }

    private static void UseOfSomeSystem1(SomeSytem system)
    {
        var ctx = new DataContext();

        // Do the error of not awaiting BUT we get a warning!
        system.SaveState(ctx);
        ctx.Close();

        // This is a case .... Todo
    }

    private static void UseOfSomeSystem2(SomeSytem system)
    {
        var ctx = new DataContext();

        // Do the error of not awaiting AND NO warning
        var task = system.SaveState(ctx);
        ctx.Close();

        // Reason is code analyzer observe developer take care of return value of a not awaited
        // async method which is a Task so assumed she / he know what she / he is doing. 
        // In this case the analyzers think to highly of developer... 
    }

    private static void UseOfSomeSystem3(SomeSytem system)
    {
        var ctx = new DataContext();

        // Do the error of not awaiting AND NO warning
        _ = system.SaveState(ctx);
        ctx.Close();

        // Reason is code analyzer observe developer take care of return value of a not awaited
        // async method which is a Task so assumed she / he know what she / he is doing. 
        // In this case the analyzers think to highly of developer...
        //
        // Only difference between this case and UseOfSystem2 is that developer explicit ignore
        // the Task, still reason to think developer know what hen is doing... Sadely...
    }

    private static void UseOfSomeSystem4(ISomeSystem system)
    {
        var ctx = new DataContext();

        // Do the error of not awaiting AND NO warning!
        system.SaveState(ctx); 
        ctx.Close();
    }

}
