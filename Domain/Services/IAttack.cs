using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IAttack
    {
        public void AttackEntity(Hero attacker);
        public void AttackHero(Hero attacker, Hero defender);
    }
}
