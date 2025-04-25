using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DGameLibrary;

namespace _2DGameLibrary
{
    public class ItemAttackEnchant : ItemAttack
    {
        public ItemAttack itemAttack;

        public ItemAttackEnchant(ItemAttack itemAttack, int enchDmg)
        {
            this.itemAttack = itemAttack;
            Enchant(enchDmg);
        }

        public void Enchant(int enchDmg)
        {
            itemAttack.Damage += enchDmg;
        }
    }
}