using System;
using System.ComponentModel;

namespace eldotnet.Report
{
    public class Log
    {
        #region Singleton init
        private static Log instance = null;

        private Log() {}

        public static Log Out => instance ?? (instance = new Log());

        #endregion

        #region Log events


        protected EventHandlerList listEventDelegates = new EventHandlerList();

        private static readonly object OnDebugEventKey = new object();
        private static readonly object OnRuntimeEventKey = new object();


        
        public event EventHandler<ReportLogArgs> DebugLogged
        {
            add => listEventDelegates.AddHandler(OnDebugEventKey, value);
            remove => listEventDelegates.RemoveHandler(OnDebugEventKey, value);
        }

        public event EventHandler<ReportLogArgs> RuntimeLogged
        {
            add => listEventDelegates.AddHandler(OnRuntimeEventKey, value);
            remove => listEventDelegates.AddHandler(OnRuntimeEventKey, value);
        }

        protected virtual void OnDebug(ReportLogArgs e)
        {
            var handler = (EventHandler<ReportLogArgs>)listEventDelegates[OnDebugEventKey];

            handler?.Invoke(this, e);
        }
        
        protected virtual void OnRuntime(ReportLogArgs e)
        {
            var handler = (EventHandler<ReportLogArgs>) listEventDelegates[OnRuntimeEventKey];

            handler?.Invoke(this, e);
        }
        #endregion
    
        public void LogDebug(string message)
        {
            var args = new ReportLogArgs {Message = message};
            OnDebug(args);
        }

        public void LogRuntime(string message)
        {
            var args = new ReportLogArgs {Message = message};
            OnRuntime(args);
        }
    }
}