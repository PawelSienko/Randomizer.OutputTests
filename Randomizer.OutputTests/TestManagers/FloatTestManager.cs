using System.Collections.Generic;
using System.Linq;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.TestManagers
{
    public class FloatTestManager : TestManagerBase<float>
    {
        public FloatTestManager(IEnumerable<OutputTestBase<float>> outputTests, int executionTimes = 0) 
            : base(executionTimes)
        {
            this.ExecutionTimes = executionTimes;
            base.AddExecutable(outputTests.ToList());
        }
    }
}