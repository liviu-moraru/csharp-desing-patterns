using System.Collections.Generic;

namespace MediatorDemo.Structural
{
    public abstract class Mediator
    {
        protected  readonly List<Colleague> _colleagues = new List<Colleague>();
        public abstract void Send(string message, Colleague colleague);

        public void Register(Colleague colleague)
        {
            _colleagues.Add(colleague);
        }
    }

}