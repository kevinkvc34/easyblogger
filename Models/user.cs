using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace blog.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}
        public String Password {get;set;}
        public String Username {get;set;}
        public List<Post> Posts {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}