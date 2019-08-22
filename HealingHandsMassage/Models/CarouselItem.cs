using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealingHandsMassage.Models
{
    public class CarouselItem
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Text { get; set; }

        public CarouselItem(string text)
        {
            this.Text = text;
        }
    }
}
