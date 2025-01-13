namespace LibraryPOO_Project;
using System.Text.Json;
using System.Globalization;
using System.Text.Json.Serialization;
public class resourceConverter : JsonConverter<resource>
{
    public override resource? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonObject = JsonDocument.ParseValue(ref reader).RootElement;
        var type = jsonObject.GetProperty("Type").GetString();

        return type switch
        {
            "Manual" => JsonSerializer.Deserialize<manual>(jsonObject.GetRawText(), options),
            "ReadingBook" => JsonSerializer.Deserialize<book>(jsonObject.GetRawText(), options),
            "EBook" => JsonSerializer.Deserialize<ebook>(jsonObject.GetRawText(), options),
            "Magazine" => JsonSerializer.Deserialize<magazine>(jsonObject.GetRawText(), options),
            _ => throw new NotSupportedException($"Unknown type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, resource value, JsonSerializerOptions options)
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