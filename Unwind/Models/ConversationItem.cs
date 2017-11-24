namespace Unwind
{
    using Newtonsoft.Json;

    public class ConversationItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }    
    }
}
