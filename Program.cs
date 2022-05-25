using System.Net.Http.Headers;
using System.Text.Json;
using WebApiClient.Repositories;

namespace WebApiClient;

public class Program
{
    private static readonly HttpClient Client = new();
    
    public static async Task Main(string[] args)
    {
        var repositories = await ProcessRepositories();

        foreach (var repo in repositories)
        {
            Console.WriteLine(repo.Name);
            Console.WriteLine(repo.Description);
            Console.WriteLine(repo.GitHubHomeUrl);
            Console.WriteLine(repo.Homepage);
            Console.WriteLine(repo.Watchers);
            Console.WriteLine();
        }
    }
    
    private static async Task<List<Repository>> ProcessRepositories()
    {
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders
            .Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        Client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        var stream = await Client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
        var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);
        return repositories;

    }
}
