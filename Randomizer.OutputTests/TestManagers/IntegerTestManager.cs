using System.Collections.Generic;
using System.Linq;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.TestManagers
{
    public class IntegerTestManager : TestManagerBase<int>
    {
        public IntegerTestManager(IEnumerable<OutputTestBase<int>> outputTests, int executionTimes = 0)
        {

            this.ExecutionTimes = executionTimes;
            base.AddExecutable(outputTests.ToList());
        }
    }
}