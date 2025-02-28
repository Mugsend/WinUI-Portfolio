using System.Text.Json.Serialization;
namespace WinUIPortfolio.Models
{
    internal class GitHubRepository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("html_url")]
        public string Html_Url { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
