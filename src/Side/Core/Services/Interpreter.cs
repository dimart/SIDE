using Microsoft.Practices.Unity;
using Side.Interfaces.Services;

namespace Side.Core.Services
{
    public class Interpreter : IInterpreter
    {
        private IUnityContainer _container;

        public Interpreter(IUnityContainer container)
        {
            _container = container;
        }
        public string Interpret(string code)
        {
            return "Allright!";
        }
    }
}
