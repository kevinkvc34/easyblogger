using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace blog.Models
{
    public class Post
    {
        [Key]
        public int PostId {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}
        public String Message {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        
    }
}