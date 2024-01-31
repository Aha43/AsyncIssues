namespace AsyncIssues
{
    public interface ISomeSystem
    {
        Task SaveState(DataContext context);
    }
    

    public class SomeSytem : ISomeSystem
    {
        public async Task SaveState(DataContext context)
        {
            await Task.Delay(1000);
            context.Save(this);
        }

    }

}
