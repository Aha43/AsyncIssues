namespace AsyncIssues
{
    public interface ISomeSystem
    {
        Task SaveStateAsync(DataContext context);
    }
    

    public class SomeSytem : ISomeSystem
    {
        public async Task SaveStateAsync(DataContext context)
        {
            await Task.Delay(1000);
            context.Save(this);
        }

    }

}
