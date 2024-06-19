using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploHTTP.Models
{
    public class Post
    {
        private int id;
        public int Id {  get => id; set=> id = value; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
