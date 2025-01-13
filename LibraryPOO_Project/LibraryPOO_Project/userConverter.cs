namespace LibraryPOO_Project;
using System.Text.Json;
using System.Globalization;
using System.Text.Json.Serialization;

public class userConverter : JsonConverter<user>
{
    public override user? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonObject = JsonDocument.ParseValue(ref reader).RootElement;
        var type = jsonObject.GetProperty("Type").GetString();

        return type switch
        {
            "StandardUser" => JsonSerializer.Deserialize<standardUser>(jsonObject.GetRawText(), options),
            "AdvancedUser" => JsonSerializer.Deserialize<advancedUser>(jsonObject.GetRawText(), options),
            _ => throw new NotSupportedException($"Unknown type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, user value, JsonSerializerOptions options)
    {
        var type = value.GetType().Name;
        writer.WriteStartObject();
        writer.WriteString("Type", type);
        foreach (var prop in value.GetType().GetProperties())
        {
            writer.WritePropertyName(prop.Name);
            JsonSerializer.Serialize(writer, prop.GetValue(value), options);
        }
        writer.WriteEndObject();
    }
}