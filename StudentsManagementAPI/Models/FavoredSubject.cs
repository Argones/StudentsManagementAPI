using System.Text.Json.Serialization;

namespace StudentsManagementAPI.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FavoredSubject
    {
        ICT = 1,
        Math = 2,
        Chemistry = 3,
        Biology = 4,
        Physic = 5,
        Languages = 6
    }
}
