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
            string connection = ConfigurationManager.ConnectionStrings["FHConnectionString"].ConnectionString;
            string[] parameters = new string[] { "@Date" };
            SqlDbType[] paramTypes = new SqlDbType[] { SqlDbType.Date };
            string[] paramValues = new string[1];
            DateTime firstDay = DateTime.Today;
            string[] days = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri" };
            DateTime[] dates = new DateTime[5];

            string updateCommand = @"UPDATE Meals
                                    SET   [Dinner] = ISNULL(NULLIF(Dinner,''), {0}Dinner)
                                        ,[Lunch] = ISNULL(NULLIF(Lunch,''), {0}Lunch)
                                        ,[LQty] = CASE WHEN Lunch = '' THEN	1 ELSE LQty END
                                        ,[DQty] = CASE WHEN Dinner = '' THEN 1 ELSE DQty END
                                    FROM
									    [dbo].[Meals] AS Meals
									    INNER JOIN [dbo].[WeeklyMeals] AS Weekly
										    ON Meals.UserID = Weekly.UserID
                                    WHERE [Date] = @DATE";

            string insertCommand = @"INSERT INTO Meals ([UserID], [Dinner], [Lunch], [LQty], [DQty], [Date])
                                    SELECT UserID AS ID, {0}Dinner AS Dinner, {0}Lunch AS Lunch, 1 AS LQty, 1 AS DQty, @Date AS Date
                                    FROM
									    [dbo].[WeeklyMeals] AS Weekly
							        WHERE NOT EXISTS (SELECT * FROM Meals WHERE UserID = Weekly.UserID AND Date = @Date)";

            // Run the command
            SqlTools.ExecuteNonQuery(connection, String.Format(updateCommand, days[(int)firstDay.DayOfWeek - 1]), parameters, paramTypes, new string[] { firstDay.ToString("yyyy-MM-dd") });
            SqlTools.ExecuteNonQuery(connection, String.Format(insertCommand, days[(int)firstDay.DayOfWeek - 1]), parameters, paramTypes, new string[] { firstDay.ToString("yyyy-MM-dd") });

            

        }
    }
}
