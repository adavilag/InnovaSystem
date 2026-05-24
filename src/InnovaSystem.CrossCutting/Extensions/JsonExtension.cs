using System.Text.Json;
using System.Text.Json.Serialization;

namespace InnovaSystem.CrossCutting.Extensions
{
    public static class JsonExtension
    {
        // Configuración optimizada y estándar para APIs modernas
        private static readonly JsonSerializerOptions DefaultOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, 
            WriteIndented = false,                             // Cambiar a true si deseas el JSON formateado con saltos de línea
            DefaultIgnoreCondition = JsonIgnoreCondition.Never, 
            ReferenceHandler = ReferenceHandler.IgnoreCycles   // Evita bucles infinitos en relaciones bidireccionales            
        };

        /// <summary>
        /// Convierte cualquier clase u objeto a una cadena en formato JSON.
        /// </summary>
        public static string ToJson<T>(this T obj)
        {
            if (obj == null) return string.Empty;

            return JsonSerializer.Serialize(obj, DefaultOptions);
        }

        /// <summary>
        /// Convierte una cadena JSON de vuelta a la clase o tipo especificado.
        /// </summary>
        public static T? FromJson<T>(this string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return default;

            try
            {
                return JsonSerializer.Deserialize<T>(json, DefaultOptions);
            }
            catch (JsonException)
            {
                return default; // No retornamos excepcion para no romper el flujo
            }
        }
    }
}
