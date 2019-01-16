using System;
using System.ComponentModel;

namespace eldotnet.Report
{
    public class Stream
    {
        string message;

        #region Singleton init
        public static Stream instance = null;

        private Stream() {}

        public static Stream Out
        {
            get{
                if(instance == null)
                    instance = new Stream();
                return instance;
            }
        }

        #endregion

        #region Stream events


        protected EventHandlerList listEventDelegates = new EventHandlerList();

        static readonly object OnDebugEventKey = new object();
        static readonly object OnRuntimeEventKey = new object();


        
        public event EventHandler<ReportStreamArgs> DebugLogged
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

        public event EventHandler<ReportStreamArgs> RuntimeLogged
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

        protected virtual void OnDebug(ReportStreamArgs e)
        {
            EventHandler<ReportStreamArgs> handler = (EventHandler<ReportStreamArgs>)listEventDelegates[OnDebugEventKey];

            if(handler != null)
            {
                handler(this, e);
            }
        }
        
        protected virtual void OnRuntime(ReportStreamArgs e)
        {
            EventHandler<ReportStreamArgs> handler = (EventHandler<ReportStreamArgs>) listEventDelegates[OnRuntimeEventKey];
            
            if(handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
    
        public void LogDebug(string message)
        {
            ReportStreamArgs args = new ReportStreamArgs();
            args.Message = message;
            OnDebug(args);
        }

        public void LogRuntime(string message)
        {
            ReportStreamArgs args = new ReportStreamArgs();
            args.Message = message;
            OnRuntime(args);
        }
    }
}