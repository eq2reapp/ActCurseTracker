using System;
using System.Collections.Generic;

namespace ActCurseTracker
{
    public class Logger
    {
        public static event Action<string> LogAdded;
        private static void OnLogAdded(string line) { if (LogAdded != null) LogAdded(line); }

        public const int MAX_MESSAGES = 1000;

        private static Logger _instance = new Logger();

        private List<string> _messages = new List<string>();

        private Logger() { }

        public static void Log(string message)
        {
            _instance._messages.Add(message);
            if (_instance._messages.Count > MAX_MESSAGES) {
                _instance._messages.RemoveAt(0);
            }

            OnLogAdded(message);
        }

        public static string[] Lines()
        {
            return _instance._messages.ToArray();
        }
    }
}
