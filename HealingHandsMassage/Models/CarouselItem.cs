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

        public string ImagePath { get; set; }

        [Required]
        public string TextInJson { get; set; }

        public CarouselItem()
        {

        }

        public CarouselItem(string Json)
        {
            this.TextInJson = Json;
            //Populates with null if not instantiated
            this.ImagePath = "";
        }

        public CarouselItem(string Json, string ImagePath)
        {
            this.TextInJson = Json;
            this.ImagePath = ImagePath;
        }
    }
}
