using System.Text.Json.Serialization;
using HttpDriver.Controllers.Sockets.Extensions;

namespace HttpDriver.Controllers.Sockets.Packets
{
    public record EntityCreate
    {
        #region Constructors

        public static EntityCreate Create(BinaryReader stream)
        {
            var address = stream.ReadUInt64();
            var membersSize = (int)stream.ReadVariableLength();
            var members = Enumerable.Range(0, membersSize).Select(_ => EntityCreateMember.Create(stream)).ToList();
            return new EntityCreate { Address = address, Members = members };
        }

        #endregion

        #region Properties

        [JsonPropertyName("address")]
        public ulong Address { get; init; }

        [JsonPropertyName("members")]
        public IReadOnlyCollection<EntityCreateMember> Members { get; init; } = Array.Empty<EntityCreateMember>();

        #endregion
    }
}