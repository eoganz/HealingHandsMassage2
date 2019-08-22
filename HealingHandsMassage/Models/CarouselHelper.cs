using HealingHandsMassage.Data;
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
        //First need to figure out migrations
        public static List<CarouselItem> GetAllItems(ApplicationDbContext context)
        {
            var list = context.CarouselItems.ToList();

            return list;
        }

        //public static bool GetNextItem(CarouselItem currItem)
        //{
        //    var currId = currItem.id;

            

        //    return
        //}

        public static async Task AddAndSaveAsync(CarouselItem item,ApplicationDbContext context)
        {
            await context.CarouselItems.AddAsync(item);
            await context.SaveChangesAsync();
        }
        public static void AddAndSave(CarouselItem item, ApplicationDbContext context)
        {
            context.CarouselItems.Add(item);
            context.SaveChanges();
        }
    }


}
