using System;
using System.Collections.Generic;

namespace Randomizer.OutputTests.Base
{
    public abstract class OutputTestBase<TType>
    {
        public List<string> WrongResults;
        protected ILogger fileLogger;
        
        protected OutputTestBase(ILogger logger)
        {
            this.fileLogger = logger;
            this.WrongResults = new List<string>();
        }

        public int ExecutionTimes { get; set; }

        public abstract void PerformTest(params TType[] parameters);

        protected virtual void ValidateConfitions(params TType[] parameters)
        {
            if (ExecutionTimes == 0)
            {
                throw new ArgumentException("Execution times should be greater than 0");
            }

            if (parameters == null)
            {
                throw new ArgumentException("Parametes provided to test method can not be null");
            }
        }
    }
}