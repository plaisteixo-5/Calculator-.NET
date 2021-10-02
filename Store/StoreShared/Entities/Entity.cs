using System;
using FluentValidator;

namespace StoreShared.Entities{
    public abstract class Entity : Notifiable{
        public Entity(){
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set };
    }
}