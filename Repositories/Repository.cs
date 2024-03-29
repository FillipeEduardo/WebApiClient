﻿using System.Text.Json.Serialization;

namespace WebApiClient.Repositories;

public class Repository
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("html_url")]
    public Uri GitHubHomeUrl { get; set; }

    [JsonPropertyName("homepage")]
    public Uri Homepage { get; set; }

    [JsonPropertyName("watchers")]
    public int Watchers { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}