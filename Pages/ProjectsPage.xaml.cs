using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUIPortfolio.Models;
using System.Diagnostics.CodeAnalysis;
using DotEnv.Core;
namespace WinUIPortfolio.Pages
{
    public sealed partial class ProjectsPage : Page
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public ProjectsPage()
        {
            this.InitializeComponent();
        }

        [RequiresUnreferencedCode("Calls System.Text.Json.JsonSerializer.Deserialize<TValue>(String, JsonSerializerOptions)")]
        private async void LoadGitHubRepositories()
        {
            try
            {
                LoadingIndicator.IsActive = true;
                LoadingIndicator.Visibility = Visibility.Visible;
                var apiUrl = "https://api.github.com/user/repos";
                new EnvLoader().Load();

                var personalAccessToken = Environment.GetEnvironmentVariable("API_TOKEN");

                httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("WinUIPortfolioApp", "1.0"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", personalAccessToken);

                var response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var repositories = JsonSerializer.Deserialize<List<GitHubRepository>>(jsonResponse);
                

                ReposListView.ItemsSource = repositories;
                LoadingIndicator.IsActive = false;
                LoadingIndicator.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching repositories: {ex.Message}");
            }
        }
        
    }

}
