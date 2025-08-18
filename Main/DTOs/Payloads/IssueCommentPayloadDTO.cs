using System.Text.Json.Serialization;

namespace Main.DTOs.Payloads
{
    public class IssueCommentPayloadDTO
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("issue")]
        public IssueDTO Issue { get; set; }
    }

    public class IssueDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("number")]
        public long Number { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("user")]
        public UserDTO User { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("changes")]
        public ChangesDTO Changes { get; set; }

        [JsonPropertyName("pull_request")]
        public PullRequestDTO PullRequest { get; set; }
    }

    public class UserDTO
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }
    }

    public class CommentDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("user")]
        public UserDTO User { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }

    public class PullRequestDTO
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        [JsonPropertyName("diff_url")]
        public string DiffUrl { get; set; }

        [JsonPropertyName("patch_url")]
        public string PatchUrl { get; set; }
    }

    public class ChangesDTO
    {
        [JsonPropertyName("body")]
        public ChangesBodyDTO Body { get; set; }
    }

    public class ChangesBodyDTO
    {
        [JsonPropertyName("from")]
        public string From { get; set; }
    }
}
