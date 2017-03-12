using System.Collections.Generic;

namespace Randomizer.OutputTests
{
    public interface ILogger
    {
        void LogResult(IEnumerable<string> item, string minValue = null, string maxValue = null);

        void LogResult(string item);
    }
}