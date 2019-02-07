using System;
using System.ComponentModel;

namespace eldotnet.Report
{
    public class Log
    {
        #region Singleton init
        public static Log instance = null;

        private Log() {}

        public static Log Out
        {
            get{
                if(instance == null)
                    instance = new Log();
                return instance;
            }
        }

        #endregion

        #region Log events


        protected EventHandlerList listEventDelegates = new EventHandlerList();

        static readonly object OnDebugEventKey = new object();
        static readonly object OnRuntimeEventKey = new object();


        
        public event EventHandler<ReportLogArgs> DebugLogged
        {
            add
            {
                listEventDelegates.AddHandler(OnDebugEventKey, value);
            }
            remove
            {
                listEventDelegates.RemoveHandler(OnDebugEventKey, value);
            }
        }

        public event EventHandler<ReportLogArgs> RuntimeLogged
        {
            add
            {
                listEventDelegates.AddHandler(OnRuntimeEventKey, value);
            }
            remove
            {
                listEventDelegates.AddHandler(OnRuntimeEventKey, value);
            }
        }

        protected virtual void OnDebug(ReportLogArgs e)
        {
            EventHandler<ReportLogArgs> handler = (EventHandler<ReportLogArgs>)listEventDelegates[OnDebugEventKey];

            if(handler != null)
            {
                handler(this, e);
            }
        }
        
        protected virtual void OnRuntime(ReportLogArgs e)
        {
            EventHandler<ReportLogArgs> handler = (EventHandler<ReportLogArgs>) listEventDelegates[OnRuntimeEventKey];
            
            if(handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
    
        public void LogDebug(string message)
        {
            ReportLogArgs args = new ReportLogArgs();
            args.Message = message;
            OnDebug(args);
        }

        public void LogRuntime(string message)
        {
            ReportLogArgs args = new ReportLogArgs();
            args.Message = message;
            OnRuntime(args);
        }
    }
}