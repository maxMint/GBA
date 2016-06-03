using System;
using LeagueOfLegends.DAL.Model;

namespace LeagueOfLegends.BLL.Helpers
{
    public class ExceptionHelper
    {
        private static volatile ExceptionHelper _instance;

        private static object syncRoot = new object();

        private ApplicationDbContext Context { get; } = new ApplicationDbContext();

        private ExceptionHelper()
        {
        }

        public static ExceptionHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new ExceptionHelper();
                        }
                    }
                }
                return _instance;
            }
        }


        public void LogError(Exception exception)
        {
            Context.LogEntries.Add(GetNote(exception));
            Context.SaveChanges();
        }

        private LogEntry GetNote(Exception ex)
        {
            var now = DateTime.Now;
            var exception = GetInnerException(ex);
            return new LogEntry
            {
                Date = now,
                Message = exception.Message,
                StackTrace = exception.StackTrace
            };
        }

        private Exception GetInnerException(Exception ex)
        {
            return ex != null && ex.InnerException != null ? GetInnerException(ex.InnerException) : ex;
        }
    }
}