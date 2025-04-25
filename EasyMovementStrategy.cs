using System.Diagnostics;

namespace _2DGameLibrary
{
    public class EasyMovementStrategy : IMovementStrategy
    {
        public void Move(Creature creature)
        {
            Random rand = new Random();
            creature.coords[0] += rand.Next(-1, 2);
            creature.coords[1] += rand.Next(-1, 2);
            Trace.WriteLine(
                $"{creature.Name} moves slowly to ({creature.coords[0]}, {creature.coords[1]}) on Easy difficulty.");
        }
    }
}