using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.AlphanumericString
{
    public class AlphanumericStringApartFromOutputTest : AlphanumericStringOutputTest
    {
        public AlphanumericStringApartFromOutputTest(IRandomAlphanumericString randomAlphanumericString, ILogger logger)
            : base(randomAlphanumericString, logger)
        {
        }

        public override void PerformTest(params object[] parameters)
        {
            var length = int.Parse(parameters[0].ToString());
            var excludedCharacters = new List<char>();

            for (int i = 1; i < parameters.Length; i++)
            {
                excludedCharacters.Add((char)parameters[i]);
            }

            var excludedCharactersArray = excludedCharacters.ToArray();

            for (int i = 0; i < ExecutionTimes; i++)
            {
                string randomValue = RandomAlphanumericString.GenerateApartFrom(length, excludedCharactersArray);

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
            var intersect = randomValueArray.Intersect(excludedCharacters);
            return intersect.Any();
        }

    }
}
