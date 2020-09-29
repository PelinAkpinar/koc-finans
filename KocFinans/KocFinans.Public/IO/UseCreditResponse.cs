using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace KocFinans.Public.IO
{
    [ProtoContract]
    public class UseCreditResponse  
    {
        [ProtoMember(1)]
        public bool Success { get; set; }
        [ProtoMember(2)]
        public string ApplicationId { get; set; }
        [ProtoMember(3)]
        public double Amount { get; set; }
        [ProtoMember(4)]
        public string ErrorMessage { get; set; }     
    }
}
