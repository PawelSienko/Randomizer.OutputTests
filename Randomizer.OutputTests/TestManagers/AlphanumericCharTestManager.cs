using System.Collections.Generic;
using System.Linq;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.TestManagers
{
    public class AlphanumericCharTestManager : TestManagerBase<char>
    {
        public AlphanumericCharTestManager(IEnumerable<OutputTestBase<char>> outputTests, int executionTimes = 0) 
            : base(executionTimes)
        {
            this.ExecutionTimes = executionTimes;
            base.AddExecutable(outputTests.ToList());
        }
    }
}