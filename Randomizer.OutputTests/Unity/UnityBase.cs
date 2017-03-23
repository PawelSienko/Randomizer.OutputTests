using Common.Core.Validation;
using Microsoft.Practices.Unity;

namespace Randomizer.OutputTests.Unity
{
    public abstract class UnityBase
    {
        // ReSharper disable once InconsistentNaming
        protected readonly UnityContainer unityContainer;

        protected UnityBase(UnityContainer unityContainer)
        {
            Validator.ValidateNull(unityContainer);
            this.unityContainer = unityContainer;
        }

        public abstract void RegisterTypes();
    }
}
