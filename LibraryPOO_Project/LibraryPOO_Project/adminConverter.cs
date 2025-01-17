using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace LibraryPOO_Project
{
    public class adminConverter : JsonConverter<admin>
    {
        private readonly library lb; 

        public adminConverter(library libraryInstance)
        {
            lb = libraryInstance;
        }

        public override admin Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonObject = JsonDocument.ParseValue(ref reader).RootElement;

            var userId = jsonObject.GetProperty("UserId").GetInt32();
            var name = jsonObject.GetProperty("Name").GetString();
            var email = jsonObject.GetProperty("Email").GetString();
            return new admin(userId, name, email, lb);
        }

        public override void Write(Utf8JsonWriter writer, admin value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            
            writer.WriteNumber("UserId", value.UserId);
            writer.WriteString("Name", value.Name);
            writer.WriteString("Email", value.Email);

            writer.WriteEndObject();
        }
    }
}
