using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediatRDemo.Controllers
{
    public class ContactsController : ControllerBase
    {
        private IMediator _mediator;

        public ContactsController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<Contact> GetContact([FromRoute] Query query)
        {
            return await this._mediator.Send(query);
        }
        #region Nested Classes

        public class Query : IRequest<Contact>
        {
            public int Id { get; set; }
        }

        public class ContactHandler : IRequestHandler<Query, Contact>
        {
            private ContactsContext db;

            public ContactHandler(ContactsContext db) => this.db = db;
            
            public Task<Contact> Handle(Query request, CancellationToken cancellationToken)
            {
                return this.db.Contacts.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
            }
        }

        

        #endregion
    }
}