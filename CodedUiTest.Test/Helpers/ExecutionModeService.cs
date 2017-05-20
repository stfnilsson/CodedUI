using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace IKEA.SalesCoworker.CodedUI.Tests.Helpers
{
    public class ExecutionModeService
    {
        private const string DesignModeCommand = "designmode";
        private const string EnvironmentCommand = "env";
        private const string StoreCommand = "store";
        private const string UserIdCommand = "userid";

        public bool ProtocolActivated { get; private set; }

        public bool DesignMode { get; private set; }

        public string Environment { get; private set; }

        public string UserId { get; private set; }

        public string Store { get; private set; }

        public void Setup(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return;
            }
            var parameters = ParseQueryString(query);

            ProtocolActivated = true;

            DesignMode = GetBoolean(DesignModeCommand, false, parameters);
            Environment = GetString(EnvironmentCommand, string.Empty, parameters);
            UserId = GetString(UserIdCommand, string.Empty, parameters);
            Store = GetString(StoreCommand, string.Empty, parameters);
        }

        private Dictionary<string, string> ParseQueryString(string query)
        {
            var list = Regex.Matches(query, "([^?=&]+)(=([^&]*))?")
                .Cast<Match>()
                .ToDictionary(x => x.Groups[1].Value, x => x.Groups[3].Value);

            return list;
        }

        private bool GetBoolean(string key, bool defaultValue, IReadOnlyDictionary<string, string> list)
        {
            if (!list.ContainsKey(key))
            {
                return defaultValue;
            }
            try
            {
                return bool.Parse(list[key]);
            }
            catch
            {
                return defaultValue;
            }
        }

        private string GetString(string key, string defaultValue, IReadOnlyDictionary<string, string> list)
        {
            if (!list.ContainsKey(key))
            {
                return defaultValue;
            }
            try
            {
                return list[key];
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}