using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    public class ClassManager
    {
        public static Company GetCompany(ILoader loader)
        {
            return loader.Get();
        }
    }
}
