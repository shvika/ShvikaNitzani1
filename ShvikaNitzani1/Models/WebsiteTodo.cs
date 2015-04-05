using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShvikaNitzani1.Models
{
    public class WebsiteTodo
    {
        public int WebsiteTodoId { get; set; }
        [Display(Name = "Suggested By")]
        public string SuggestedBy { get; set; }
        [Display(Name = "Creation Time")]
        public string Date { get; set; }
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        [Display(Name = "Details")]
        public string Details { get; set; }
    }
}