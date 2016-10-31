using System;
using System.Collections.Immutable;
using System.Threading;

namespace TEST
{
    public class Fluent_Interfaces
    {
        public static void Main()
        {
            var spectacle = new Spectacle()
                .Say("Привет мир!")
                .Delay(TimeSpan.FromSeconds(1))
                .UntilKeyPressed(s =>
                    s.TypeText("тра-ля-ля")
                    .TypeText("тру-лю-лю")
                )
                .Say("Пока-пока!");

            spectacle.Play();
        }
    }

    public class Spectacle
    {
        private readonly ImmutableList<Action> actions;

        public Spectacle()
        {
            actions = ImmutableList<Action>.Empty;
        }

        public Spectacle(ImmutableList<Action> actions)
        {
            this.actions = actions;
        }

        public Spectacle UntilKeyPressed(Func<Spectacle, Spectacle> inner)
        {
            var innerSpectacle = inner(new Spectacle());
            return Schedule(() =>
            {
                while (!Console.KeyAvailable)
                {
                    innerSpectacle.Play();
                }
                Console.ReadKey(true);
            });
        }

        public Spectacle Schedule(Action action)
        {
            return new Spectacle(actions.Add(action));
        }

        public Spectacle Say(string message)
        {
            return Schedule(() => Console.WriteLine(message));
        }

        public Spectacle Delay(TimeSpan delay)
        {
            return Schedule(() => Thread.Sleep(delay));
        }

        public void Play()
        {
            foreach (var action in actions)
            {
                action();
            }
        }
    }

    public static class SpectacleExtensions
    {
        public static Spectacle TypeText(this Spectacle spectacle, string message)
        {
            return spectacle.Schedule(() =>
            {
                foreach (var ch in message)
                {
                    Console.Write(ch);
                    Thread.Sleep(100);
                }
                Console.WriteLine();
            });
        }
    }
}