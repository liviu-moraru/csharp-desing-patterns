using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices.ComTypes;
using MediatorDemo.ChatApp;
using MediatorDemo.Structural;

namespace MediatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //StructuralExample();
            var teamChat = new TeamChatRoom();
            
            var steve = new Developer("Steve");
            var justin = new Developer("Justin");
            var jenna = new Developer("Jenna");
            var kim = new Tester("Kim");
            var julia = new Tester("julia");
            
            teamChat.RegisterMembers(steve, justin, jenna, kim, julia);
            
            steve.Send("Hey, everyone, we're going to be deploying at 2pm today.");
            kim.Send("Ok, thanks for letting us know");
            
            kim.SendTo<Developer>("Hello, Developers !");
            
        }

        private static void StructuralExample()
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