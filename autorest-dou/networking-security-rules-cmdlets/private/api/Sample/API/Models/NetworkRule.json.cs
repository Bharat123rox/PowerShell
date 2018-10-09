namespace Sample.API.Models
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>Network rule</summary>
    public partial class NetworkRule
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        partial void AfterFromJson(Carbon.Json.JsonObject json);
        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Carbon.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        partial void AfterToJson(ref Carbon.Json.JsonObject container);
        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>
        partial void BeforeFromJson(Carbon.Json.JsonObject json, ref bool returnNow);
        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>
        partial void BeforeToJson(ref Carbon.Json.JsonObject container, ref bool returnNow);
        /// <summary>
        /// Deserializes a <see cref="Carbon.Json.JsonNode"/> into an instance of Sample.API.Models.INetworkRule.
        /// </summary>
        /// <param name="node">a <see cref="Carbon.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>an instance of Sample.API.Models.INetworkRule.</returns>
        public static Sample.API.Models.INetworkRule FromJson(Carbon.Json.JsonNode node)
        {
            return node is Carbon.Json.JsonObject json ? new NetworkRule(json) : null;
        }
        /// <summary>
        /// Deserializes a Carbon.Json.JsonObject into a new instance of <see cref="NetworkRule" />.
        /// </summary>
        /// <param name="json">A Carbon.Json.JsonObject instance to deserialize from.</param>
        internal NetworkRule(Carbon.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            _expirationTime = If( json?.PropertyT<Carbon.Json.JsonString>("expiration_time"), out var __jsonExpirationTime) ? (string)__jsonExpirationTime : (string)ExpirationTime;
            _filter = If( json?.PropertyT<Carbon.Json.JsonObject>("filter"), out var __jsonFilter) ? Sample.API.Models.CategoryFilter.FromJson(__jsonFilter) : Filter;
            _icmpTypeCodeList = If( json?.PropertyT<Carbon.Json.JsonArray>("icmp_type_code_list"), out var __jsonIcmpTypeCodeList) ? If( __jsonIcmpTypeCodeList, out var __w) ? new System.Func<Sample.API.Models.INetworkRuleIcmpTypeCodeListItemType[]>(()=> System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select( __w, (__v)=> Sample.API.Models.NetworkRuleIcmpTypeCodeListItemType.FromJson(__v)  ) ) )() : null : IcmpTypeCodeList;
            _ipSubnet = If( json?.PropertyT<Carbon.Json.JsonObject>("ip_subnet"), out var __jsonIpSubnet) ? Sample.API.Models.IpSubnet.FromJson(__jsonIpSubnet) : IpSubnet;
            _networkFunctionChainReference = If( json?.PropertyT<Carbon.Json.JsonObject>("network_function_chain_reference"), out var __jsonNetworkFunctionChainReference) ? Sample.API.Models.NetworkFunctionChainReference.FromJson(__jsonNetworkFunctionChainReference) : NetworkFunctionChainReference;
            _peerSpecificationType = If( json?.PropertyT<Carbon.Json.JsonString>("peer_specification_type"), out var __jsonPeerSpecificationType) ? (string)__jsonPeerSpecificationType : (string)PeerSpecificationType;
            _protocol = If( json?.PropertyT<Carbon.Json.JsonString>("protocol"), out var __jsonProtocol) ? (string)__jsonProtocol : (string)Protocol;
            _tcpPortRangeList = If( json?.PropertyT<Carbon.Json.JsonArray>("tcp_port_range_list"), out var __jsonTcpPortRangeList) ? If( __jsonTcpPortRangeList, out var __r) ? new System.Func<Sample.API.Models.IPortRange[]>(()=> System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select( __r, (__q)=> Sample.API.Models.PortRange.FromJson(__q)  ) ) )() : null : TcpPortRangeList;
            _udpPortRangeList = If( json?.PropertyT<Carbon.Json.JsonArray>("udp_port_range_list"), out var __jsonUdpPortRangeList) ? If( __jsonUdpPortRangeList, out var __m) ? new System.Func<Sample.API.Models.IPortRange[]>(()=> System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select( __m, (__l)=> Sample.API.Models.PortRange.FromJson(__l)  ) ) )() : null : UdpPortRangeList;
            AfterFromJson(json);
        }
        /// <summary>
        /// Serializes this instance of <see cref="NetworkRule" /> into a <see cref="Carbon.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Carbon.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Rest.ClientRuntime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="NetworkRule" /> as a <see cref="Carbon.Json.JsonNode" />.
        /// </returns>
        public Carbon.Json.JsonNode ToJson(Carbon.Json.JsonObject container, Microsoft.Rest.ClientRuntime.SerializationMode serializationMode)
        {
            container = container ?? new Carbon.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != ExpirationTime ? (Carbon.Json.JsonNode) new Carbon.Json.JsonString(ExpirationTime) : null, "expiration_time" ,container.Add );
            AddIf( null != Filter ? (Carbon.Json.JsonNode) Filter.ToJson(null) : null, "filter" ,container.Add );
            if (null != IcmpTypeCodeList)
            {
                var __x = new Carbon.Json.XNodeArray();
                foreach( var __y in IcmpTypeCodeList )
                {
                    AddIf(__y?.ToJson(null) ,__x.Add);
                }
                container.Add("icmp_type_code_list",__x);
            }
            AddIf( null != IpSubnet ? (Carbon.Json.JsonNode) IpSubnet.ToJson(null) : null, "ip_subnet" ,container.Add );
            AddIf( null != NetworkFunctionChainReference ? (Carbon.Json.JsonNode) NetworkFunctionChainReference.ToJson(null) : null, "network_function_chain_reference" ,container.Add );
            AddIf( null != PeerSpecificationType ? (Carbon.Json.JsonNode) new Carbon.Json.JsonString(PeerSpecificationType) : null, "peer_specification_type" ,container.Add );
            AddIf( null != Protocol ? (Carbon.Json.JsonNode) new Carbon.Json.JsonString(Protocol) : null, "protocol" ,container.Add );
            if (null != TcpPortRangeList)
            {
                var __s = new Carbon.Json.XNodeArray();
                foreach( var __t in TcpPortRangeList )
                {
                    AddIf(__t?.ToJson(null) ,__s.Add);
                }
                container.Add("tcp_port_range_list",__s);
            }
            if (null != UdpPortRangeList)
            {
                var __n = new Carbon.Json.XNodeArray();
                foreach( var __o in UdpPortRangeList )
                {
                    AddIf(__o?.ToJson(null) ,__n.Add);
                }
                container.Add("udp_port_range_list",__n);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}