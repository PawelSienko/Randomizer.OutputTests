using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.AlphanumericString
{
    public class AlphanumericStringExcludedOutputTest : AlphanumericStringOutputTest
    {
        public AlphanumericStringExcludedOutputTest(IRandomAlphanumericString randomAlphanumericString, ILogger logger)
            : base(randomAlphanumericString,logger)
        {
        }
        
        public override void PerformTest(params string[] parameters)
        {
            var excludedCharacters = new[] { 'f', 'G', '1', 'h' };
            for (int i = 0; i < ExecutionTimes; i++)
            {
                string randomValue = RandomAlphanumericString.GenerateValueWithout(40, excludedCharacters);

                if (string.IsNullOrEmpty(randomValue))
                {
                    WrongResults.Add("NULL");
                }
                else if (ContainsAnyExcludedCharacter(randomValue, excludedCharacters))
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }

            fileLogger.LogResult(WrongResults);
        }

        private static bool ContainsAnyExcludedCharacter(string randomValue, IList<char> excludedCharacters)
        {
            var randomValueArray = randomValue.ToCharArray();
            return randomValueArray.Intersect(excludedCharacters).Any();
        }

    }
}
