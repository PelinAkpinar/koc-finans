using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace KocFinans.Public.IO
{
    [ProtoContract]
    public class UseCreditRequest
    {
        [ProtoMember(1)]
        [Required]
        public int IdentityNo { get; set; }
        [ProtoMember(2)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [ProtoMember(3)]
        [Required(AllowEmptyStrings = false)]
        public string SurName { get; set; }
        [ProtoMember(4)]
        [Required]
        public int PhoneNumber { get; set; }
        [ProtoMember(5)]
        [Required]
        public double Salary { get; set;}
    }
}
