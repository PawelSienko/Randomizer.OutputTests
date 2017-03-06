using System;
using System.Collections.Generic;
using System.Linq;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.TestManagers
{
    public class DateTimeTestManager : TestManagerBase<DateTime>
    {
        public DateTimeTestManager(IEnumerable<OutputTestBase<DateTime>> outputTests, int executionTimes = 0) 
            : base(executionTimes)
        {
            this.ExecutionTimes = executionTimes;
            base.AddExecutable(outputTests.ToList());
        }
    }
}