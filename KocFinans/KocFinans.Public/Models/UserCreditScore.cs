using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace KocFinans.Public.Models
{
    [ProtoContract]
    public class UserCreditScore
    {
        [ProtoMember(1)]
        [BsonId]
        public string Id { get; set; }
        [ProtoMember(2)]
        public int IdentityNo { get; set; }
        [ProtoMember(3)]
        public int CreditScore { get; set; }
    }
}
