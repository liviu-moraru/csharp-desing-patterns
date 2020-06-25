using System;

namespace MediatorDemo.Structural
{
    public class Colleague2 : Colleague
    {
        public Colleague2(Mediator mediator) : base(mediator)
        {
        }

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Collegue2 received notification message: {message}");
        }
    }
}