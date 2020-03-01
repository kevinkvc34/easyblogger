using System;
using System.Collections.Generic;


namespace blog.Models {
    public class DashViewModel {
        public User user {get;set;}
        public Post post {get;set;}
        public List<Post> posts {get;set;}
    }
}