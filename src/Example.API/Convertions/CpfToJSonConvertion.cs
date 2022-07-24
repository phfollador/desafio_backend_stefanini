using System.Text.Json;
using System.Text.Json.Serialization;
using Example.Domain.CitizenAggregate;

namespace Example.API.Convertions
{
    public class CpfToJSonConvertion : JsonConverter<Cpf>
    {
        public override Cpf Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Cpf.Create(reader.GetString() ?? "");
        }

        public override void Write(Utf8JsonWriter writer, Cpf cpf, JsonSerializerOptions options)
        {
            writer.WriteStringValue(cpf.Value);
        }
    }
}
