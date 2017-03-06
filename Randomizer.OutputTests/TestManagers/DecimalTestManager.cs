using System.Collections.Generic;
using System.Linq;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.TestManagers
{
    public class DecimalTestManager : TestManagerBase<decimal>
    {
        public DecimalTestManager(IEnumerable<OutputTestBase<decimal>> outputTests, int executionTimes = 0) 
            : base(executionTimes)
        {
            this.ExecutionTimes = executionTimes;
            base.AddExecutable(outputTests.ToList());
        }
    }
}