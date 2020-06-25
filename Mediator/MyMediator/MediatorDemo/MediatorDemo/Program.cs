using System;
using MediatorDemo.Structural;

namespace MediatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new ConcreteMediator();
            /*var c1 = new Colleague1();
            var c2 = new Colleague2();
            mediator.Register(c1);
            mediator.Register(c2);*/
          
            var c1 = mediator.CreateColleague<Colleague1>();
            var c2 = mediator.CreateColleague<Colleague2>();
            
            c1.Send("Hello, boys");
            c2.Send("Hello, girls");
            
            Console.ReadLine();
        }
    }
}