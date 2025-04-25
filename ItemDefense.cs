using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameLibrary
{
    public class ItemDefense : WorldObject
    {
        public int Defense { get; set; }

        public ItemDefense(string name, int defense)
        {
            Defense = defense;
            Name = name;
        }
    }
}
