using System.Collections.Generic;

namespace Side.Interfaces.Interpreter
{
    public enum State
    {
        Calculating,
        Interpreted,
        Warning,
        Error
    }

    public interface IInterpreter
    {
        //event EventHandler OnCalculating;
        //event EventHandler OnInterpreted;
        //event EventHandler OnWarning;
        //event EventHandler OnError;

        void Interpret();

        State GetState();
        Dictionary<int, string> GetErrorsList();
        //??? Result
    }
}
