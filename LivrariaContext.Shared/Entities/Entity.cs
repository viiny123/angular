using Flunt.Notifications;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {

        }

        public Entity(string id)
        {
            this._id = id;
        }

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string _id { get; set; }
    }
}
