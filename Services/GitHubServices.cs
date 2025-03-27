namespace CV_hantering_REST_API.Services
{
    public class GitHubServices
    {
        private readonly HttpClient _httpClient;

        public GitHubServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GitHubRepositoryDTO>> GetRepositoriesByUsername(string username)
        {
            var response = await _httpClient.GetFromJsonAsync<List<GitHubRepositoryDTO>>($"https://api.github.com/users/{username}/repos");
            return response ?? new List<GitHubRepositoryDTO>();
        }
    }

    public class GitHubRepositoryDTO
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string HtmlUrl { get; set; }
    }
}
