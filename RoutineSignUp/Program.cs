using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FHWebsite;
using System.Data;
using System.Configuration;

namespace RoutineSignUp
{
    class AddData
    {
        static void Main(string[] args)
        {
            string[] parameters = new string[] { "@Date" };
            SqlDbType[] paramTypes = new SqlDbType[] { SqlDbType.Date };
            string[] paramValues = new string[1];
            DateTime firstDay = DateTime.Today;
            string[] days = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri" };
            DateTime[] dates = new DateTime[5];

            string command = @"INSERT INTO [dbo].[Meals]
                                           ([UserID]
                                           ,[Date]
                                           ,[Dinner]
                                           ,[Lunch]
                                           ,[LQty]
                                           ,[DQty])
                                     SELECT [UserID], @Date, [{0}Dinner], [{0}Lunch], 1, 1
	                                 FROM[dbo].[WeeklyMeals]
                                        WHERE UserID = 7777";

            // Configure everything
            for(int i=0; i<days.Length; i++)
            {
                firstDay = firstDay.AddDays(1);
                // Get the day to a weekday
                while ((firstDay.DayOfWeek > DayOfWeek.Friday) | (firstDay.DayOfWeek < DayOfWeek.Monday))
                {
                    firstDay = firstDay.AddDays(1);
                }
                // Run the command
                SqlTools.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["FHConnectionString"].ConnectionString, String.Format(command, days[(int)firstDay.DayOfWeek - 1]), parameters, paramTypes, new string[] { firstDay.ToString("yyyy-MM-dd") });
            }

            

        }
    }
}
