using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace Game_Life
{
    class Program
    {
        public static void Main()
        {
            var spectacle = ImmutableSpectacle.CreateNewSpectacle()
                .Say("Привет мир!")
                .Delay(TimeSpan.FromSeconds(1))
                .UntilKeyPressed(s =>
                    s.TypeText("тра-ля-ля")
                    .TypeText("тру-лю-лю")
                )
                .Say("Пока-пока!"); ;

            spectacle.Play();

            var greet = ImmutableSpectacle.CreateNewSpectacle().Say("Hello!");
            var greetAndAsk = greet.Say("How are you?");
            var greetAndBye = greet.Say("Bye!");

            greetAndAsk.Play(); // ?!
        }
    }

    public sealed class ImmutableSpectacle
    {
        private readonly ImmutableList<Action> commands;

        private ImmutableSpectacle()
        {
            commands = ImmutableList<Action>.Empty;
        }

        private ImmutableSpectacle(ImmutableList<Action> commands)
        {
            this.commands = commands;
        }

        private ImmutableSpectacle(ImmutableSpectacle spectacle)
            : this(spectacle.commands)
        { }

        public static ImmutableSpectacle CreateNewSpectacle() => new ImmutableSpectacle();

        public ImmutableSpectacle Say(string phrase)
        {
            return AddCommand(() => Console.WriteLine(phrase));
        }

        public ImmutableSpectacle Delay(TimeSpan delayTime)
        {
            return AddCommand(() => Thread.Sleep(delayTime));
        }

        public ImmutableSpectacle UntilKeyPressed(Func<ImmutableSpectacle, ImmutableSpectacle> constructSpectacle)
        {
            var inner = constructSpectacle(new ImmutableSpectacle());
            return AddCommand(() =>
            {
                while (!Console.KeyAvailable) inner.Play();
                Console.ReadKey(true);
            });
        }

        public void Play()
        {
            Array.ForEach(commands.ToArray(), x => x());
        }

        public ImmutableSpectacle AddCommand(Action command)
        {
            return new ImmutableSpectacle(commands.Add(command));
        }
    }

    public static class SpectacleExtensions
    {
        public static ImmutableSpectacle TypeText(this ImmutableSpectacle spectacle, string text)
        {
            return spectacle.AddCommand(() =>
            {
                foreach (var c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(100);
                }
                Console.WriteLine();
            });
        }
    }
}
