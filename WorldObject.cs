using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameLibrary
{
    public abstract class WorldObject
    {
        public string Name { get; set; }
        public bool Lootable { get; set; }
        public bool Removable { get; set; }
        public string Description { get; set; }
        public int[] coords { get; set; }
    }
}
