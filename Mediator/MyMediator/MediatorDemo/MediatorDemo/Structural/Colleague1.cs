using System;

namespace MediatorDemo.Structural
{
    public class Colleague1 : Colleague
    {
        public Colleague1(Mediator mediator) : base(mediator)
        {
        }

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Collegue1 received notification message: {message}");
        }
    }
}