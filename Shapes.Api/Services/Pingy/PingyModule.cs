using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Services.Pingy
{
    public class PingyModule : IPingy
    {
        public string Ping()
        {
            return "Pong!";
        }
    }
}
