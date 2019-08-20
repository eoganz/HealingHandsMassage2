using HealingHandsMassage.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealingHandsMassage.Models
{
    public static class CarouselHelper
    {

        //First need to figure out migrations
        public static List<CarouselItem> GetAllItems(ApplicationDbContext context)
        {
            var list = context.CarouselItems.ToList();
            List<CarouselItem> listOfItems = new List<CarouselItem>();

            foreach(string obj in list)
            {
                var item = Newtonsoft.Json.JsonConvert.DeserializeObject(obj);
                listOfItems.Add((CarouselItem)item);
            }
            
            return listOfItems;
        }

        //public static bool GetNextItem(CarouselItem currItem)
        //{
        //    var currId = currItem.id;



        //    return
        //}

        public static async Task<bool> SaveChangesAsync(CarouselItem item,ApplicationDbContext context)
        {
            var worked = await context.SaveChangesAsync();

            if(worked == 1)
            {
                return true;
            }

            return false;
        }

        public static void AddItem(CarouselItem item, ApplicationDbContext context)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            context.CarouselItems.AddAsync(json);
        }
    }


}
