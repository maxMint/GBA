using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.DAL.Model
{
    public class LogEntry
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}