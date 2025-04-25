using System.Diagnostics;

namespace _2DGameLibrary
{
    public class HardMovementStrategy : IMovementStrategy
    {
        public void Move(Creature creature)
        {
            Random rand = new Random();
            creature.coords[0] += rand.Next(-3,4);
            creature.coords[1] += rand.Next(-3,4);
            Trace.WriteLine(
                $"{creature.Name} moves fast to ({creature.coords[0]}, {creature.coords[1]}) on Hard difficulty.");
        }
    }
}