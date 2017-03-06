using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.AlphanumericChar
{
    public class AlphanumericCharInRangeOutputTest : AlphanumericCharOutputTest
    {
        public AlphanumericCharInRangeOutputTest(IRandomCharacter randomCharacter, ILogger fileLogger)
            : base(randomCharacter, fileLogger)
        {
        }

        public override void PerformTest(params char[] parameters)
        {
            ValidateConfitions(parameters);
            
            char minValue = parameters[0];
            
            char maxValue = parameters[1];

            int minValueIndex = Consts.AlphanumericCharacters.IndexOf(minValue);
            int maxValueIndex = Consts.AlphanumericCharacters.IndexOf(maxValue);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                char randomValue = randomCharacter.GenerateValue(minValue, maxValue);
                int indexOfRandomValue = Consts.AlphanumericCharacters.IndexOf(randomValue);

                if (indexOfRandomValue < minValueIndex || indexOfRandomValue > maxValueIndex)
                {
                    WrongResults.Add(Consts.AlphanumericCharacters[indexOfRandomValue].ToString());
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}