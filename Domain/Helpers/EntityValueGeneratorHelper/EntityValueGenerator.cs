using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers.EntityValueGeneratorHelper
{
    public class EntityValueGenerator
    {
        public static int GenerateValue()
        {
            Random rnd = new Random();
            int value = rnd.Next(20, 91);
            return value;
        }
    }
}
