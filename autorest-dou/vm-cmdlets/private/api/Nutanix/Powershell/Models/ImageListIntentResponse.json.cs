namespace Nutanix.Powershell.Models
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>Response object for intentful operation of images</summary>
    public partial class ImageListIntentResponse
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
        /// Deserializes a <see cref="Carbon.Json.JsonNode"/> into an instance of Nutanix.Powershell.Models.IImageListIntentResponse.
        /// </summary>
        /// <param name="node">a <see cref="Carbon.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>an instance of Nutanix.Powershell.Models.IImageListIntentResponse.</returns>
        public static Nutanix.Powershell.Models.IImageListIntentResponse FromJson(Carbon.Json.JsonNode node)
        {
            return node is Carbon.Json.JsonObject json ? new ImageListIntentResponse(json) : null;
        }
        /// <summary>
        /// Deserializes a Carbon.Json.JsonObject into a new instance of <see cref="ImageListIntentResponse" />.
        /// </summary>
        /// <param name="json">A Carbon.Json.JsonObject instance to deserialize from.</param>
        internal ImageListIntentResponse(Carbon.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            _apiVersion = If( json?.PropertyT<Carbon.Json.JsonString>("api_version"), out var __jsonApiVersion) ? (string)__jsonApiVersion : (string)ApiVersion;
            _entities = If( json?.PropertyT<Carbon.Json.JsonArray>("entities"), out var __jsonEntities) ? If( __jsonEntities, out var __v) ? new System.Func<Nutanix.Powershell.Models.IImageIntentResource[]>(()=> System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select( __v, (__u)=> Nutanix.Powershell.Models.ImageIntentResource.FromJson(__u)  ) ) )() : null : Entities;
            _metadata = If( json?.PropertyT<Carbon.Json.JsonObject>("metadata"), out var __jsonMetadata) ? Nutanix.Powershell.Models.ImageListMetadataOutput.FromJson(__jsonMetadata) : Metadata;
            AfterFromJson(json);
        }
        /// <summary>
        /// Serializes this instance of <see cref="ImageListIntentResponse" /> into a <see cref="Carbon.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Carbon.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Rest.ClientRuntime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ImageListIntentResponse" /> as a <see cref="Carbon.Json.JsonNode" />.
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
            AddIf( null != ApiVersion ? (Carbon.Json.JsonNode) new Carbon.Json.JsonString(ApiVersion) : null, "api_version" ,container.Add );
            if (null != Entities)
            {
                var __w = new Carbon.Json.XNodeArray();
                foreach( var __x in Entities )
                {
                    AddIf(__x?.ToJson(null) ,__w.Add);
                }
                container.Add("entities",__w);
            }
            AddIf( null != Metadata ? (Carbon.Json.JsonNode) Metadata.ToJson(null) : null, "metadata" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}