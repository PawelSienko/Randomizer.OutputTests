using Common.Core.Validation;
using Randomizer.Interfaces.ReferenceTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.AlphanumericChar
{
    public abstract class AlphanumericCharOutputTest : OutputTestBase<char>
    {
        // ReSharper disable once InconsistentNaming
        protected IRandomCharacter randomCharacter;

        protected AlphanumericCharOutputTest(IRandomCharacter randomCharacter, ILogger fileLogger)
            : base(fileLogger)
        {
            Validator.ValidateNull(randomCharacter);
            Validator.ValidateNull(fileLogger);
            this.randomCharacter = randomCharacter;
        }

        // ReSharper disable once FunctionRecursiveOnAllPaths
        protected override void ValidateConfitions(params char[] parameters)
        {
            base.ValidateConfitions(parameters);
            char min = parameters[0];
            char max = parameters[1];

            Validator.ValidateNull(min);
            Validator.ValidateNull(max);
        }
    }
}
