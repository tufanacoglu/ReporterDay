﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ReporterDay.EntityLayer.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<Article> Articles { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
