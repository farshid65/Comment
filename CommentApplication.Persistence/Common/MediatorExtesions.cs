using CommentApplicatin.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.Persistence.Common
{
    public static class MediatorExtesions
    {
        public static async Task DispatchDomainEvents(this IMediator mediator, DbContext context)
        {
            var entities = context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.Entity.DomainEvents.Any())
                .Select(e => e.Entity);

            var domainEvents = entities
                .SelectMany(e => e.DomainEvents)
                .ToList();
            entities.ToList().ForEach(e =>e.ClearDomainEvents());
            foreach (var domainEvent in domainEvents) 
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}
