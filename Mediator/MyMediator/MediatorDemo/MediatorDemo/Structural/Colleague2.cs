using System;

namespace MediatorDemo.Structural
{
    public class Colleague2 : Colleague
    {
        /*public Colleague2(Mediator mediator, string name) : base(mediator, name)
        {
        }*/
        

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague2 received notification message: {message}");
        }
    }
}