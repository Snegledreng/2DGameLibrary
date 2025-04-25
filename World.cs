using System.Diagnostics;
using System.Text.Json;
using System.Xml.Linq;

namespace _2DGameLibrary
{
    public class World
    {
        private static World _instance;

        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public string Difficulty { get; set; }
        public List<WorldObject> WorldObjects { get; set; } = new List<WorldObject>();

        /// <summary>
        /// Singleton instance of the World class. Loads variables from a the config.json file.
        /// </summary>
        private World()
        {
            Trace.WriteLine("Initializing World...");
            //World config = LoadConfig("config.json");
            //MaxX = config.MaxX;
            //MaxY = config.MaxY;
            //Difficulty = config.Difficulty;
            MaxX = 8;
            MaxY = 8;
            Difficulty = "hard";
            Trace.WriteLine($"World initialized with MaxX: {MaxX}, MaxY: {MaxY}, Difficulty: {Difficulty}");
        }

        public static World Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new World();
                }
                return _instance;
            }
        }
        
        //private static World LoadConfig(string filePath)
        //{
        //    Trace.WriteLine($"Loading configuration from {filePath}");
        //    if (!File.Exists(filePath))
        //    {
        //        Trace.TraceError($"Configuration file not found: {filePath}");
        //        throw new FileNotFoundException($"Configuration file not found: {filePath}");
        //    }

        //    string json = File.ReadAllText(filePath);
        //    return JsonSerializer.Deserialize<World>(json);
        //}

        /// <summary>
        /// This method is called when a creature is attacked and takes damage.
        /// It logs the details of the attack, including the creature's name, its defense rating, and remaining health.
        /// </summary>
        /// <param name="c">The creature getting smacked</param>
        /// <param name="defense">the defense rating of the creature</param>
        /// <param name="realDamage">The incoming damage</param>
        public void CreatureGetsSmacked(Creature c, int defense, int realDamage)
        {
            Trace.WriteLine($"{c.Name} has {defense} defense. It takes {realDamage} damage, and has {c.HitPoint}HP remaining.");
        }

        public void Combat(Creature combatant1, Creature combatant2)
        {
            
            while (World.Instance.WorldObjects.Contains(combatant2) && World.Instance.WorldObjects.Contains(combatant1))
            {
                combatant2.ReceiveHit(combatant1.DealDamage());
                if (World.Instance.WorldObjects.Contains(combatant2))
                    combatant1.ReceiveHit(combatant2.DealDamage());
            }
        }

        /// <summary>
        /// Removes a creature from the list of WorldObjects when it dies.
        /// </summary>
        /// <param name="creature">Creature being removed from WorldObjects</param>
        public void RemoveDeadCreature(WorldObject creature)
        {
            if (WorldObjects.Remove(creature))
            {
                Trace.WriteLine($"{creature.Name} has died and has been removed from the world.");
            }
            else
            {
                Trace.TraceWarning($"Attempted to remove a creature that does not exist: {creature.Name}");
            }
        }
    }
}
