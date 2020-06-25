using System.Collections.Generic;
using System.Linq;

namespace MediatorDemo.ChatApp
{
    public class TeamChatRoom : Chatroom
    {
        private List<TeamMember> _members = new List<TeamMember>();
        
        public override void Register(TeamMember member)
        {
            member.SetChatroom(this);
            _members.Add(member);
        }

        public override void Send(string from, string message)
        {
            this._members.ForEach(m => m.Receive(from, message));
        }

        public override void SendTo<T>(string from, string message)
        {
            //this._members.Where(m => m.GetType() == typeof(T)).ToList().ForEach(m => m.Receive(from, message));
            this._members.OfType<T>().ToList().ForEach(m => m.Receive(from, message));
        }

        public void RegisterMembers(params TeamMember[] members)
        {
            foreach (var teamMember in members)
            {
                this.Register(teamMember);
            }
        }
    }
}