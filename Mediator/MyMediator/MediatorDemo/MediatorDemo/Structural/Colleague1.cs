using System;

namespace MediatorDemo.Structural
{
    public class Colleague1 : Colleague
    {
        /*public Colleague1(Mediator mediator, string name) : base(mediator, name)
        {
        }*/

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague1 received notification message: {message}");
        }
    }
}