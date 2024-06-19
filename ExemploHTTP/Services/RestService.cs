using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ExemploHTTP.Models;
using System.Text.Json;
using System.Linq.Expressions;
using System.Diagnostics;

namespace ExemploHTTP.Services
{
    public class RestService
    {
        private HttpClient client;
        private Post post;
        private List<Post> posts;
        private JsonSerializerOptions _serializerOptions;

        RestService()
        {
            client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Post>> getPostsAsync()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    posts = JsonSerializer.Deserialize<List<Post>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return posts;
        }
    }
}
