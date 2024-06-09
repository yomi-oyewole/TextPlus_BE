using System.Text.Json;
using System.Text.Json.Serialization;
using MongoDB.Bson;

namespace TextPlus_BE.Converters
{
    public class ObjectIdConverter : JsonConverter<ObjectId>
    {
        public override ObjectId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            try
            {
                var id = new ObjectId(JsonSerializer.Deserialize<string>(ref reader, options));
                return id;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public override void Write(Utf8JsonWriter writer, ObjectId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

}

