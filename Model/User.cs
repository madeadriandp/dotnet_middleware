
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace api_test.Model
{
    public class User
    {
        public int id {get;set;}
        public string username{get;set;}
        public string password{get;set;}
        public string salt{get;set;}
        public string email{get;set;}
        public string profile{get;set;}

        [ForeignKeyAttribute("author_id")]
        public ICollection<Post> Posts{get;set;}

    } 
}