using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface ICurrency : IView
    {
        int CurrencyID { get; set; }
        void BindCurrencyList(List<Currency> Currencies);
        Currency FillCurrencyObject();
        void FillCurrencyControls(Currency currency);
    }
}
