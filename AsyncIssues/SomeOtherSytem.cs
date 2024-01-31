namespace AsyncIssues
{
    //
    // "System" that try help developer spot methods that should be awaited.
    //

    public interface ISomeOtherSystem
    {
        Task SaveStateAsync(DataContext context);
    }
    

    public class SomeOtherSytem : ISomeOtherSystem
    {
        public async Task SaveStateAsync(DataContext context)
        {
            await Task.Delay(1000);
            context.Save(this);
        }
    }

}
