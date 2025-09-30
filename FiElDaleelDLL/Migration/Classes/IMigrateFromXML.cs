using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Migration.Classes
{
  public interface IMigrateFromXML
    {
      bool MigrateFromXML(string File);
      bool MigrateToBrokerDB(int SubscriperId,int No);
    }
}
