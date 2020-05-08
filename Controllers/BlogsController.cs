using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public BlogsController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs = await _dataContext.Blogs.OrderByDescending(b => b.PostDate).ToListAsync();
            Console.WriteLine(blogs);

            return Ok(blogs);

        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await _dataContext.Blogs.FirstOrDefaultAsync(blog => blog.Id == id);
            return Ok(blog);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBlog(Blog blog)
        {
            await _dataContext.Blogs.AddAsync(blog);
            await _dataContext.SaveChangesAsync();

            return StatusCode(201);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            Console.WriteLine("DeleteBlog id:" + id);

            var blog = _dataContext.Blogs.SingleOrDefault(b => b.Id == id);
            _dataContext.Blogs.Remove(blog);
            await _dataContext.SaveChangesAsync();
            return StatusCode(200);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(Blog blog)
        {
            _dataContext.Blogs.Update(blog);
            await _dataContext.SaveChangesAsync();

            return StatusCode(200);

        }



    }
}