using System.Collections.Generic;
using System.Linq;
using backend.Models;
using Newtonsoft.Json;

namespace backend.Data.DataSeeds
{
    public class Seed
    {
        public static void SeedBlogs(DataContext dataContext)
        {
            if (!dataContext.Blogs.Any())
            {
                var blogData = System.IO.File.ReadAllText("Data/DataSeeds/BlogsSeedData.json");
                var blogs = JsonConvert.DeserializeObject<List<Blog>>(blogData);

                foreach (var blog in blogs)
                {
                    dataContext.Blogs.Add(blog);
                }
                dataContext.SaveChanges();

            }
        }
    }
}