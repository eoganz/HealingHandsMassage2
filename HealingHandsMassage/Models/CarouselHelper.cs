using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealingHandsMassage.Models
{
    public static class CarouselHelper
    {

        public static DbSet<CarouselItem> JsonText { get; set; }

        
        
        public static bool LoadNextItem()
        {
            throw new NotImplementedException();
        }
    }

    public class CarouselItem
    {
        [Key]
        public int id { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public string TextInJson { get; set; }
    }
}
