using System;
using System.Globalization;
using System.Linq;
using Common.Core.Validation;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Float
{
    public class FloatApartFromOutputTest : OutputTestBase<float>
    {
        private readonly float tolerance;
        // ReSharper disable once InconsistentNaming
        private readonly IRandomFloat randomFloat;

        public FloatApartFromOutputTest(IRandomFloat randomFloat, ILogger logger) : base(logger)
        {
            Validator.ValidateNull(randomFloat);
            this.randomFloat = randomFloat;
            this.tolerance = (float)Math.Pow(0.1, 7);
        }

        public override void PerformTest(params float[] parameters)
        {
            ValidateConfitions(parameters);

            for (int i = 0; i < ExecutionTimes; i++)
            {
                double randomValue = randomFloat.GenerateValueApartFrom(parameters);
                if (parameters.Any(item => Math.Abs(item - randomValue) < this.tolerance))
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}
