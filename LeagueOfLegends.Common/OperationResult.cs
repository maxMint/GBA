using System;
using System.Collections.Generic;

namespace LeagueOfLegends.Common
{
    public class OperationResult
    {
        public OperationResult()
        {
            
        }

        public OperationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public object Object { get; set; }

        public bool Success { get; set; }

        public String Message { get; set; }

        public String Url { get; set; }

        public List<String> Errors { get; set; }
    }
}