using System.Text.Json.Serialization;

namespace webapi
{
    public class FirebaseSettings
    {
        [JsonPropertyName("project_id")]
        public string ProjectId => "that-rug-really-tied-the-room-together-72daa";

        [JsonPropertyName("private_key_id")]
        public string PrivateKeyId => "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

        // ... and so on
    }
}
