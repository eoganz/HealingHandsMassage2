using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealingHandsMassage.Models
{

    //Need help figuring out how to add new table to context. 
    //https://stackoverflow.com/questions/23662755/how-to-add-new-table-to-existing-database-code-first
    public class CarouselContext : DbContext
    {
        public CarouselContext()
        {

        }

        public virtual DbSet<CarouselItem> CarouselItems { get; set; }


    }

    public class CarouselItem
    {
        [Key]
        public int id { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public string TextInJson { get; set; }

        public CarouselItem(string Json)
        {
            this.TextInJson = Json;
            this.ImagePath = "None";
        }

        public CarouselItem(string Json, string ImagePath)
        {
            this.TextInJson = Json;
            this.ImagePath = ImagePath;
        }
    }

}
