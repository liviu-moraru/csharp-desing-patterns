using System;

namespace MediatorDemo.ChatApp
{
    public abstract class TeamMember
    {
        private Chatroom _chatroom;
        public string Name { get;  }
        
        public TeamMember(string name)
        {
            this.Name = name;
        }

        internal void SetChatroom(Chatroom chatroom)
        {
            this._chatroom = chatroom;
        }

        public void Send(string message)
        {
            this._chatroom.Send(this.Name, message);
        }

        public void SendTo<T>(string message) where T: TeamMember
        {
            this._chatroom.SendTo<T>(this.Name, message);
        }
        
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"from {from}: {message}");
        }
        
    }
}