using System.Collections.Generic;
using System.Linq;

namespace MediatorDemo.Structural
{
    public class ConcreteMediator : Mediator
    {
        private List<Colleague> _colleagues = new List<Colleague>();

        public void Register(Colleague colleague)
        {
            colleague.SetMediator(this);
            _colleagues.Add(colleague);
        }

        public T CreateColleague<T>() where T : Colleague, new()
        {
            var c = new T();
            c.SetMediator(this);
            _colleagues.Add(c);
            return c;
        }
        /*public override void Send(string message, Colleague colleague)
        {
            foreach (var col in _colleagues)
            {
                if (col != colleague)
                {
                    col.HandleNotification($"{colleague.Name} sent the message: {message}");
                }
            }
        }*/
        
        
        public override void Send(string message, Colleague colleague)
        {
            this._colleagues.Where(col => col != colleague).ToList().ForEach(col => col.HandleNotification(message));
        }
    }
}