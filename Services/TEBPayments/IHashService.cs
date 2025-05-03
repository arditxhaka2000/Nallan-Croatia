using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TEBPayments
{
    public interface IHashService
    {
        string GenerateHashV3(string storeKey, Dictionary<string, string> parameters);
    }
}
