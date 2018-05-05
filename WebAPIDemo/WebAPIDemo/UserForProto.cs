/*
 * protobuf在序列化时必须指定顺序
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtoBuf;

namespace WebAPIDemo
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
