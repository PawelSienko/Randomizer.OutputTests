using System.Collections.Generic;
using Common.Core.Validation;
using Microsoft.Practices.ObjectBuilder2;
using Randomizer.OutputTests.TestManagers;

namespace Randomizer.OutputTests.Base
{
    public class TestManagerBase<TType> : ITestManager<TType>
    {
        // ReSharper disable once InconsistentNaming
        private readonly List<OutputTestBase<TType>> executables;

        protected int ExecutionTimes;

        public TestManagerBase(int executionTimes = 0)
        {
            if (executionTimes != 0)
            {
                ExecutionTimes = executionTimes;
            }

            executables = new List<OutputTestBase<TType>>();
        }

        public void SetExecutionTimes(int executionTimes)
        {
            if (executables != null)
            {
                executables.ForEach(item =>
                {
                    item.ExecutionTimes = executionTimes;
                });
            }
        }

        public void AddExecutable(IList<OutputTestBase<TType>> executable)
        {
            Validator.ValidateNull(executable);
            if (ExecutionTimes != 0)
            {
                executable.ForEach(ex =>
                {
                    ex.ExecutionTimes = ExecutionTimes;
                });
            }
            executables.AddRange(executable);
        }

        public void ExecuteAll(params TType[] inputParams)
        {
            executables.ForEach(ex =>
            {
                ex.PerformTest(inputParams);
            });
        }
    }
}
