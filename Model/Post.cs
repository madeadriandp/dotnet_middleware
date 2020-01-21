using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_test
{
    public class Post
    {
        public int id {get;set;}
        public string title{get;set;}
        public string content{get;set;}
        public string tags{get;set;}
        public string status{get;set;}
        public string create_time{get;set;}
        public string update_time {get; set;}
        [RequiredAttribute]
        public int author_id{get;set;}
        // public List<Comment> comments{get;set;}
        [ForeignKeyAttribute("post_id")]
        public ICollection<Comment> Comments {get;set;}
                
    }
}
