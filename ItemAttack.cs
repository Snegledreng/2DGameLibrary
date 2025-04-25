using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameLibrary
{
    public class ItemAttack : WorldObject
    {
        public int Damage { get; set; }
        public ItemAttack(string name, int damage)
        {
            Damage = damage;
            Name = name;
        }

        public ItemAttack()
        {
        }
    }
}
