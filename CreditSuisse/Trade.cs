using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse
{
    public class Trade1 : ITrade
    {
        public string ClientSector { get { return "Privado"; } }

        public double Value { get { return 2000000; } }

    }
    public class Trade2 : ITrade
    {
        public string ClientSector { get { return "Público"; } }

        public double Value { get { return 400000; } }

    }
    public class Trade3 : ITrade
    {
        public string ClientSector { get { return "Público"; } }

        public double Value { get { return 500000;  } }

    }
    public class Trade4 : ITrade
    {
        public string ClientSector { get { return "Público"; } }

        public double Value { get { return 3000000; } }

    }

}

