using System;

namespace TEST
{
    public interface Thing
    { }

    internal class Starship:Thing
    { }

    internal class Asteroid:Thing
    { }

    class Program
    {

        private static void CollideImpl(Starship first, Starship second)
        {
            Console.WriteLine("Starship collides with starship");    
        }

        private static void CollideImpl(Starship first, Asteroid second)
        {
            Console.WriteLine("Starship collides with asteroid");    
        }

        private static void CollideImpl(Asteroid first, Starship second)
        {
            Console.WriteLine("Asteroid collides with starship");    
        }

        private static void CollideImpl(Asteroid first, Asteroid second)
        {
            Console.WriteLine("Asteroid collides with asteroid");    
        }

        private static void Collide(Thing x, Thing y)
        {
            dynamic first = x;
            dynamic second = y;
            CollideImpl(first, second);
        }

        static void Main(string[] args)
        {
            Collide(new Asteroid(), new Starship());
        }
    }
}