using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace api_test
{
    public class Comment
    {
        public int id {get;set;}
        public string content{get;set;}
        public string status{get;set;}
        public string create_time{get;set;}
        public string author{get;set;}
        public string email{get;set;}
        public string url {get; set;}
        [RequiredAttribute]
        public int post_id{get;set;}
               
    }
}
