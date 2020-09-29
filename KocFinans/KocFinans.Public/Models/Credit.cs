using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace KocFinans.Public.Models
{
    [ProtoContract]
    public class Credit
    {
        [ProtoMember(1)]
        [BsonId]
        public string Id { get; set; }
        [ProtoMember(2)]
        public int IdentityNo { get; set; }
        [ProtoMember(3)]
        public double CreditAmount { get; set; }
        [ProtoMember(4)]
        public string Name { get; set; }
        [ProtoMember(5)]
        public string Surname { get; set; }
        [ProtoMember(6)]
        public int PhoneNumber { get; set; }
    }
}
