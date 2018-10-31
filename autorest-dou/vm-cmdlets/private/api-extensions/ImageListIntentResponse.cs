namespace Nutanix.Powershell.Models
{

    /// <summary>Response object for intentful operation of images</summary>
    [System.ComponentModel.TypeConverter(typeof(ImageListIntentResponseTypeConverter))]
    public partial class ImageListIntentResponse
    {

        /// <summary>
        /// Creates a new instance of <see cref="ImageListIntentResponse" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Nutanix.Powershell.Models.IImageListIntentResponse FromJsonString(string jsonText) => FromJson(Carbon.Json.JsonNode.Parse(jsonText));
        /// <summary>Serializes this instance to a json string.</summary>
        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Rest.ClientRuntime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Response object for intentful operation of images
    [System.ComponentModel.TypeConverter(typeof(ImageListIntentResponseTypeConverter))]
    public partial interface IImageListIntentResponse {

    }
}