using Microsoft.Practices.Unity;
using Microsoft.SqlServer.Server;
using Suffle.Interpreter;
using Parser;
using Specification;

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
            var inter = new Suffle.Interpreter.Expression.Interpreter();
            return inter.EvaluateProgram(Suffle.Parser.parse(code));
        }
    }
}
