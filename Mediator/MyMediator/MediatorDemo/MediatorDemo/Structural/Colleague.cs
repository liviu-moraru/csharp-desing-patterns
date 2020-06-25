namespace MediatorDemo.Structural
{
    public abstract class Colleague
    {
        protected Mediator mediator;
        
        /*public Colleague(Mediator mediator, string name)
        {
            this.mediator = mediator;
            this.Name = name;
            this.mediator.Register(this);
        }*/

        internal void SetMediator(Mediator mediator)
        {
            this.mediator = mediator;
        }
        public virtual void Send(string message)
        {
            this.mediator.Send(message, this);
        }

        public abstract void HandleNotification(string message);

    }
}