using Domain.Common;
using NHibernate.Event;
using System;

namespace Infrastructure.Data
{
    public class EventListener :
        IPostInsertEventListener,
        IPostDeleteEventListener,
        IPostUpdateEventListener,
        IPostCollectionUpdateEventListener
    {
        private void DispatchEvents(AggregateRoot aggregateRoot)
        {
            foreach (IDomainEvent domainEvent in aggregateRoot.DomainEvents)
            {
                DomainEvents.Dispatch(domainEvent);
            }
            aggregateRoot.ClearEvents();
        }

        public void OnPostDelete(PostDeleteEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public void OnPostInsert(PostInsertEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public void OnPostUpdate(PostUpdateEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public void OnPostUpdateCollection(PostCollectionUpdateEvent @event)
        {
            DispatchEvents(@event.AffectedOwnerOrNull as AggregateRoot);
        }
    }
}