using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zzkluck.Arknights.Library.AkdataObject
{
    public static class JsonFileObjectParser
    {
        private static JsonSerializerOptions _caseInsensitive = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        public static T Parse<T>(string jsonString) where T : class, IJsonFileObject, new()
        {
            if (typeof(IJsonFileObjectDictionaryExt).IsAssignableFrom(typeof(T)))
            {
                var result = (new T() as IJsonFileObjectDictionaryExt);
                var dic = result.GetDictionary();
                using (JsonDocument document = JsonDocument.Parse(jsonString))
                {
                    foreach (var element in document.RootElement.EnumerateObject())
                    {
                        var character = JsonSerializer.Deserialize(element.Value.GetRawText(),result.GetSubType());
                        dic.Add(element.Name, character);
                    }
                }
                return result as T;
            }
            else
            {
                return JsonSerializer.Deserialize<T>(jsonString, _caseInsensitive);
            }
        }
    }
}
