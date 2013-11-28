using System;

namespace GitHubClientWinForm
{
    public class DataLoadErrorEvenArgs : EventArgs
    {
        public DataLoadErrorEvenArgs(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}