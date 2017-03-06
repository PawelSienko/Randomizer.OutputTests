using System.Collections.Generic;
using System.Linq;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.TestManagers
{
    public class ShortTestManager : TestManagerBase<short>
    {
        public ShortTestManager(IEnumerable<OutputTestBase<short>> outputTests, int executionTimes = 0) 
            : base(executionTimes)
        {
            this.ExecutionTimes = executionTimes;
            base.AddExecutable(outputTests.ToList());
        }
    }
}