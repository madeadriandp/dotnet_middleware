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
    [Route("comment")]

    public class CommentController : ControllerBase
    {
    private CoreDbContext _context;


        private readonly ILogger<CommentController> _logger;

        public CommentController(ILogger<CommentController> logger, CoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        [HttpGet]
        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments;
        }

        [HttpGet("{id}")]
        public Comment GetComment (int id)
        {   
            return _context.Comments.Where(item => item.id == id).Single<Comment>();   
        }

        [HttpPost]
        public Comment AddComment(Comment comment)
        { 
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        } 

        [HttpPut ("{id}")]
       public Comment EditComment(int id, Comment item)
        {
           Comment comment = _context.Comments.Where(e=>e.id==id).Single<Comment>();
        //    Comment comment = _context.Comments.ElementAt(id);
           comment.content=item.content;
           comment.status=item.status;
        //    comment.create_time=item.create_time;
           comment.author=item.author;
           comment.email=item.email;
           comment.url=item.url;
        //    comment.post_id=item.post_id;
           _context.SaveChanges();
           return comment;
         } 

        [HttpDelete ("{id}")]
        public IEnumerable<Comment> DeleteComment(int id)
        {   
           Comment comment = _context.Comments.Where(item => item.id==id).Single<Comment>();
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return _context.Comments;
        }     


    }
}
