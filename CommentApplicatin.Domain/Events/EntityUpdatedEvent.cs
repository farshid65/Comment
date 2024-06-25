using CommentApplicatin.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplicatin.Domain.Events
{
    public static class EntityUpdatedEvent 
    {
        public static EntityUpdatedEvent<TEntity> WithEntity<TEntity>(TEntity entity)
        where TEntity : BaseEntity
            => new(entity);
    }
    
    public class EntityUpdatedEvent<TEntity>:BaseEvent
        where TEntity : BaseEntity
    {
        internal EntityUpdatedEvent(TEntity entity) => Entity = entity;
        public TEntity Entity { get;  }

    }

}
