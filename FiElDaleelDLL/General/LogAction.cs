using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.General
{
    public static class LogAction
    {
        public static void Log(Modules module, subscriberActions action, int objectID,string objectName)
        {
            SubscriberLog Logger;
            if (action != subscriberActions.AddNew)
            {
                Logger = Commons.Context.SubscriberLogs.FirstOrDefault(SL => SL.ObjectTypeID == (int)module && SL.ObjectID == objectID);
                if (Logger != null)
                {
                    if (Logger.ActionID == (int)subscriberActions.AddNew)
                    {
                        return;
                    }
                    if (action == subscriberActions.Updated && Logger.ActionID == (int)subscriberActions.Updated)
                    {
                        return;
                    }
                }
            }
            Logger = new SubscriberLog();
            Logger.ActionID = (int)action;
            Logger.Date = DateTime.Now;
            Logger.ObjectID = objectID;
            Logger.ObjectTypeID = (int)module;
            Logger.ObjectName = objectName;
            Commons.Context.SubscriberLogs.AddObject(Logger);
            Commons.Context.SaveChanges();
        }
    }
}
