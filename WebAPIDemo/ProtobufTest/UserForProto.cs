using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtobufTest
{
    [ProtoContract]
    public class UserForProto
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public int Age { get; set; }
    }
}
