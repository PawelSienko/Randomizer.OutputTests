using System.Globalization;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.AlphanumericString
{
    public class AlphanumericStringUppercaseOutputTest : AlphanumericStringOutputTest
    {
        public AlphanumericStringUppercaseOutputTest(IRandomAlphanumericString randomAlphanumericString, ILogger logger)
            : base(randomAlphanumericString,logger)
        {
        }
        
        public override void PerformTest(params object[] parameters)
        {

            for (int i = 0; i < ExecutionTimes; i++)
            {
                string randomValue = RandomAlphanumericString.GenerateUpperCaseValue(100);
                if (string.IsNullOrEmpty(randomValue))
                {
                    WrongResults.Add("NULL");
                }
                else if (randomValue.Any(char.IsLower) || IsLetterOrDigit(randomValue) == false)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}
