namespace AsyncIssues
{
    public class DataContext
    {
        private bool _disposed = false;

        public object? SavedData { get; private set; }

        public void Save(object data) 
        {
            if (_disposed)
            {
                throw new DataContextClosedException();
            }

            // Real code would save somehow data external...
            SavedData = data;
        }
       

        public void Close() =>  _disposed = true;

    }

}
