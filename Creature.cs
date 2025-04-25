using System.Diagnostics;

namespace _2DGameLibrary
{
    public class Creature: WorldObject
    {
        public int HitPoint { get; set; }
        public int BaseAttack { get; set; }
        public List<WorldObject> Inventory { get; set; }
        private IMovementStrategy _movementStrategy;

        /// <summary>
        /// Constructor for the Creature class.
        /// </summary>
        /// <param name="name">Name of creature</param>
        /// <param name="hitPoint">Hitpoints of creature</param>
        /// <param name="baseAttack">Attack value of creature</param>
        public Creature(string name, int hitPoint, int baseAttack)
        {
            Name = name;
            HitPoint = hitPoint;
            BaseAttack = baseAttack;
            Inventory = new List<WorldObject>();
            Lootable = false;
            Description = $"{name} is a creature with {hitPoint} hit points and {baseAttack} base attack.";
            if (World.Instance.Difficulty == "easy")
            {
                _movementStrategy = new EasyMovementStrategy();
            }
            else if (World.Instance.Difficulty == "hard")
            {
                _movementStrategy = new HardMovementStrategy();
            }
        }

        /// <summary>
        /// Moves the creature using the assigned movement strategy based on difficulty in log file.
        /// </summary>
        public void Move()
        {
            _movementStrategy.Move(this);
        }

        /// <summary>
        /// Calculates the total damage dealt by the creature, including base attack and inventory items.
        /// </summary>
        /// <returns>Sum of damage items in inventory, and creatures base attack</returns>
        public int DealDamage()
        {
            int inventoryDamage = Inventory
                .OfType<ItemAttack>()
                .Sum(attackItem => attackItem.Damage);
            return BaseAttack + inventoryDamage;
        }

        private int CalcDefense()
        {
            return Inventory.OfType<ItemDefense>().Sum(def => def.Defense);
        }

        /// <summary>
        /// Subtracts this creatures defense points from the damage dealt by the attacker, and subtracts the remaining damage from this creatures hit points.
        /// </summary>
        /// <param name="damage">Damage dealt by attacker</param>
        public void ReceiveHit(int damage)
        {
            int defense = CalcDefense();
            int realDamage = damage - defense;
            HitPoint -= realDamage;
            World.Instance.CreatureGetsSmacked(this, defense, realDamage);
            if (HitPoint <= 0)
            {
                World.Instance.RemoveDeadCreature(this);
            }
        }

        /// <summary>
        /// Loots a world object if it is within the same coordinates and is lootable.
        /// </summary>
        /// <param name="wo">Item to be looted</param>
        public void Loot(WorldObject wo)
        {
            if (this.coords == wo.coords)
            {
                Inventory.Add(wo);
                Trace.WriteLine($"{wo.Name} has been looted by {this.Name}.");
            }
            else
            {
                Trace.WriteLine($"{wo.Name} could not be looted.");
            }
        }
    }
}
