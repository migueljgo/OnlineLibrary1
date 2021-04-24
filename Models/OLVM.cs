using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibrary1.Models
{
    public class OLVM
    {
        public Book books { get; set; }
        public List<Book> booksList { get; set; }  
        public Borrowed borroweds { get; set; }
        public List<Borrowed> borrowedsList { get; set; }   
        public User users { get; set; }
        public List<User> usersList { get; set; }



    }
}