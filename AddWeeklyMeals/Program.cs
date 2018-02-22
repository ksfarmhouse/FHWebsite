using System;
using FHWebsite;
using System

namespace AddWeeklyMeals
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = @"UPDATE Meals
                               SET   [Dinner] = ISNULL(NULLIF(Dinner,''), {1}Dinner)
                                    ,[Lunch] = ISNULL(NULLIF(Lunch,''), {1}Lunch)
                                    ,[LQty] = ISNULL(NULLIF(Lunch,''), 1)
                                    ,[DQty] = ISNULL(NULLIF(Dinner,''), 1)
                               FROM
									[dbo].[Meals] AS Meals
									INNER JOIN [dbo].[WeeklyMeals] AS Weekly
										ON Meals.UserID = Weekly.ID
                               WHERE [Date] = {0}";
            string connection = 

            connection


        }
    }
}