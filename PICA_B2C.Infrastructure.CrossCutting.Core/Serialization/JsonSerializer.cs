using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PICA_B2C.Infrastructure.CrossCutting.Core.Serialization
{
    /// <summary>
    /// Class responsible for managing json serialization of objects.
    /// </summary>
    public static class JsonSerializer
    {
        /// <summary>
        /// Serialize an object to Json.
        /// </summary>
        /// <param name="objectToSerialize">Object to serialize.</param>
        /// <returns>Serialized object (Json)</returns>
        public static string SerializeObject(object objectToSerialize)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(objectToSerialize);
        }

        /// <summary>
        /// Deserialize a JSON object to a type T.
        /// </summary>
        /// <typeparam name="T">Type of entity you want deserialize.</typeparam>
        /// <param name="objectJson">Json to be converted.</param>
        /// <returns>Serialized object.</returns>
        public static T DeserializeObject<T>(string objectJson)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(objectJson);
        }
    }
}
