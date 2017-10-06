using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntroductingWebAPI.Models
{
    public class AddMovieRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Rating { get; set; }
    }
}