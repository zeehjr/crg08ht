using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace CRG08.BO
{
    public class ErrorItem
    {
        public DateTime ThrowDate { get; set; }
        public int Identifier { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorItem(int identifier, string errorMessage)
        {
            ThrowDate = DateTime.Now;
            Identifier = identifier;
            ErrorMessage = errorMessage;
        }

    }

    public static class ListErrorExtension
    {
        
    }

    public static class ErrorHandler
    {
        private static List<ErrorItem> _messages = new List<ErrorItem>();
        public static List<ErrorItem> GetAllErrors => _messages;
        private static DateTime _lastStartError = DateTime.MinValue;

        public static void Handled(this ErrorItem item)
        {
            if (_messages.Any(x => x == item))
            {
                _messages.Remove(item);
            }
        }

        public static ErrorItem GetLastError
        {
            get
            {
                if (_messages == null)
                {
                    _messages = new List<ErrorItem>();
                    return null;
                }
                if (_messages.Count == 0)
                {
                    return null;
                }
                return _messages.LastOrDefault(x => x.ThrowDate >= _lastStartError);
            }
        }

        public static void InitializeHandler()
        {
            _lastStartError = DateTime.Now;
        }

        public static void ThrowNew(ErrorItem error)
        {
            if (_messages == null) _messages = new List<ErrorItem>();

            _messages.Add(error);
        }

        public static void ThrowNew(int identifier, string errorMessage)
        {
            if (_messages == null) _messages = new List<ErrorItem>();

            _messages.Add(new ErrorItem(identifier, errorMessage));
        }

        public static void ClearErrors()
        {
            if (_messages == null) _messages = new List<ErrorItem>();

            _lastStartError = DateTime.MinValue;
            _messages.Clear();
        }

        public static void RemoveLastError()
        {
            if (_messages == null)
            {
                _messages = new List<ErrorItem>();
                return;
            }
            if (_messages.Count >= 1)
            {
                _messages.Remove(_messages.Last());
            }
        }
    }
}
