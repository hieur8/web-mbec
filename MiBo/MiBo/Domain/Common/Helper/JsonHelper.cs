using System.Web.Script.Serialization;

namespace MiBo.Domain.Common.Helper
{
    public static class JsonHelper
    {
        /// <summary>
        /// Converts an object to a JSON string.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>The serialized JSON string.</returns>
        public static string Serialize(object obj)
        {
            // Local variable declaration
            var json = new JavaScriptSerializer();
            // Return value
            return json.Serialize(obj);
        }

        /// <summary>
        ///  Converts the specified JSON string to an object graph.
        /// </summary>
        /// <param name="str">The JSON string to be deserialized.</param>
        /// <returns>The deserialized object.</returns>
        public static object Deserializer(string str)
        {
            // Local variable declaration
            var json = new JavaScriptSerializer();
            // Return value
            return json.DeserializeObject(str);
        }

        /// <summary>
        ///  Converts the specified JSON string to an object of type T.
        /// </summary>
        /// <param name="str">The JSON string to be deserialized.</param>
        /// <returns>The deserialized object.</returns>
        public static T Deserializer<T>(string str)
        {
            // Local variable declaration
            var json = new JavaScriptSerializer();
            // Return value
            return json.Deserialize<T>(str);
        }
    }
}