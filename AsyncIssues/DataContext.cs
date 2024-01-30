namespace AsyncIssues
{
    public interface IDataContext
    {
        Task AddAsync(object data);
        void Close();
    }

    public class DataContext : IDataContext
    {
        private bool _disposed = false;

        public async Task AddAsync(object data)
        {
            await Task.Delay(1000);

            if (_disposed)
            {
                throw new Exception("Can not save: Data context closed");
            }
        }

        public void Close() =>  _disposed = true;

    }

}
