using System;
using MediatorDemo.Structural;

namespace MediatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new ConcreteMediator();
            var c1 = new Colleague1(mediator);
            var c2 = new Colleague2(mediator);
            mediator.Colleague1 = c1;
            mediator.Colleague2 = c2;
            c1.Send("Message from Colleague1");
            c2.Send("Message from Colleague2");
            Console.ReadLine();
        }
    }
}