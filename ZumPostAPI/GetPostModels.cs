using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using ZumPostAPI.Models;

namespace ZumPostAPI
{
    public class GetPostModels : IGetPostModels
    {
        public async Task<List<PostModel>> ReturnPostsByTag(string tag, string sortBy, string direction)
        {
            using var client = new HttpClient();

            var url = new Uri($"https://api.hatchways.io/assessment/blog/posts?tag={tag}");
        
            var response = await client.GetAsync(url);

            string json;
            using (var content = response.Content)
            {
                json = await content.ReadAsStringAsync();
            }

            var postsList = JsonConvert.DeserializeObject<Posts>(json).posts.ToList();

            if (sortBy != "" && sortBy != "Not Selected")
            {
                string sort = sortBy;
                bool isDescending = direction == "Asec" ? true : false;
                {
                    switch (sort)
                    {
                        case "id":
                            postsList = isDescending
                                ? postsList.OrderByDescending(x => x.Id).ToList()
                                : postsList.OrderBy(x => x.Id).ToList();
                            break;
                        case "reads":
                            postsList = isDescending
                                ? postsList.OrderByDescending(x => x.Reads).ToList()
                                : postsList.OrderBy(x => x.Reads).ToList();
                            break;
                        case "likes":
                            postsList = isDescending
                                ? [.. postsList.OrderByDescending(x => x.Likes)]
                                : postsList.OrderBy(x => x.Likes).ToList();
                            break;
                        case "popularity":
                            postsList = isDescending
                                ? postsList.OrderByDescending(x => x.Popularity).ToList()
                                : postsList.OrderBy(x => x.Popularity).ToList();
                            break;
                        default:
                            postsList = postsList.OrderBy(x => x.Id).ToList();
                            break;
                    }
                }
            }
            return postsList;
        }
    }
}
