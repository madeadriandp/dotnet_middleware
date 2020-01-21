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
    [Route("user")]

    public class UserController : ControllerBase
    {
    private CoreDbContext _context;


        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, CoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.Include("Posts.Comments");
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id )
        {
            var user = _context.Users.FirstOrDefault(e=>e.id==id);
            if(user==null)
            {
                return NotFound();
            }
            return Ok(User);
        }
        // public User GetUser (int id)
        // {   
        //     return _context.Users.Include("Posts.Comments").Where(item => item.id == id).Single<User>();   
        // }

        [HttpPost]
        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        } 

        [HttpPut ("{id}")]
        public User EditUser(int id, User item)
        {
           User user = _context.Users.Where(e=>e.id==id).Single<User>();
        //    User user = _context.Users.ElementAt<User>(id);
           user.password=item.password;
           user.email=item.email;
           user.profile=item.profile;
           user.salt=item.salt;
           user.username=item.username;
           _context.SaveChanges();
           return user;
         } 

        [HttpDelete ("{id}")]
        public IEnumerable<User> DeleteUser(int id)
        {   
            User user = _context.Users.Where(item => item.id==id).Single<User>();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return _context.Users.Include("Posts.Comments");
        }

             


        // [HttpGet]
        // public IEnumerable<User> GetUsers()
        // {   
            // _context.Users.Add(new User(){
            //     username="Angkasa", password="wakwaw", salt="klikklakkluk", email="angas@email.com", profile="pertama"});
         
            // _context.Users.Add(new User(){
            //     username="Aurora", password="huehue", salt="abc5dasar", email="aur@email.com", profile="kedua"});
            // _context.Posts.Add(new Post(){title="Luar Angkasa", content="Perjalanan Angkasa yang dibohongi ayahnya", author_id=1});
            // _context.Comments.Add(new Comment(){content="peran angkasa warbyasa", status="banyak yang dislike", post_id=4});
            // _context.SaveChanges();
            // return _context.Users.ToList();
        // }
    }
}
