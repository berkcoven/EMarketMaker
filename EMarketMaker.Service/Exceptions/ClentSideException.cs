using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Service.Exceptions
{
    public class ClentSideException:Exception
    {
        public ClentSideException(string message):base(message)
        {

        }
    }
}
