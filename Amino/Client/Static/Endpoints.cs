using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amino.Client.Static
{
    public class Endpoints
    {
        public static readonly string Prefix = "api";

        public static readonly string GamesEndPoint = $"{Prefix}/games";
        public static readonly string OrdersEndPoint = $"{Prefix}/orders";
        public static readonly string PaymentsEndPoint = $"{Prefix}/payments";
        public static readonly string PlatformsEndPoint = $"{Prefix}/platforms";
        public static readonly string CustomersEndPoint = $"{Prefix}/customers";
        public static readonly string PayTypesEndPoint = $"{Prefix}/paytypes";

    }
}
