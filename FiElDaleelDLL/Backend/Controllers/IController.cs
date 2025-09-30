using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;

namespace BrokerDLL.Backend.Controllers
{
  public interface IController
    {
      void OnViewInitialize();
      void OnSave();
      void OnEdit(int ID);
      void OnDelete(int ID);
    }
}
