using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse
{
    public interface ITrade
    {
        //double getValue();
        //string getClientSector();
        double Value { get; }
        string ClientSector { get; }

    }
}
