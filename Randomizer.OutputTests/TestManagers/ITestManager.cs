using System.Collections.Generic;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.TestManagers
{
    public interface ITestManager<TType>
    {
        void AddExecutable(IList<OutputTestBase<TType>> executable);

        void ExecuteAll(params TType[] inputParams);
    }
}