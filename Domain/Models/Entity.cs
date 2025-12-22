using Domain.Helpers.EntityValueGeneratorHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Entity
    {
        public int Value { get; set; }

        public Entity()
        {
            Value = EntityValueGenerator.GenerateValue();
        }
    }
}
