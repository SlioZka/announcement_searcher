using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testCrud.Models;

namespace testCrud
{
    public class ExampleData
    {
        public static void Initialize(AnnouncementContext context)
        {
            if (!context.Announcements.Any())
            {
                context.Announcements.AddRange(
                    new Announcement
                    {
                        Title = "Загубили собаку",
                        Description = "Пікінес, колір чорний, відкликається на кличку Натан.",
                        Date = "24 червня"
                    },
                    new Announcement
                    {
                        Title = "Шукаємо няньку",
                        Description = "Їдемо у відпуску, потрібно посидіти з собаками та котами вдома.",
                        Date = "27 червня"
                    },
                   new Announcement
                   {
                       Title = "Знайшли телефон",
                       Description = "Знайдено айфон 4 на вулиці Грушевського, біля магазину кооператор",
                       Date = "23 червня"
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
