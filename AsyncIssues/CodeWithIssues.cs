using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncIssues
{
    public interface ICodeWithIssues
    {
        Task<string> DoSomethingThatGiveResultAsync();
        Task DoSomethingWithNoResultAsync();
    }

    public class CodeWithIssuesNoSyncImpl : ICodeWithIssues
    {
        public Task<string> DoSomethingThatGiveResultAsync()
        {
            throw new NotImplementedException();
        }

        public Task DoSomethingWithNoResultAsync()
        {
            throw new NotImplementedException();
        }

    }

}
