using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api_test.Database;
using Microsoft.EntityFrameworkCore;
using api_test.Model;

namespace api_test.Controllers
{  
    [ApiController]
    [Route("post")]

    public class PostController : ControllerBase
    {
    private CoreDbContext _context;


        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger, CoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        [HttpGet]
        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts.Include("Comments");
        }

        [HttpGet("{id}")]
        public Post GetPost (int id)
        {   
            return _context.Posts.Include("Comments").Where(item => item.id == id).Single<Post>();   
        }

        [HttpPost]
        public Post AddPost(Post post)
        { 
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        } 

        [HttpPut ("{id}")]
        public Post EditPost(int id, Post item)
        {
           Post post = _context.Posts.Where(e=>e.id==id).Single<Post>();
        //    Post post = _context.Posts.ElementAt(id);
           post.title=item.title;
           post.content=item.content;
           post.tags=item.tags;
           post.status=item.status;
        //    post.create_time=item.create_time;
        //    post.update_time=item.update_time;
        //    post.author_id=item.author_id;
           _context.SaveChanges();
           return post;
         } 

        [HttpDelete ("{id}")]
        public IEnumerable<Post> DeletePost(int id)
        {   
           Post post = _context.Posts.Where(item => item.id==id).Single<Post>();
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return _context.Posts.Include("Comments");
        }     


    }
}
