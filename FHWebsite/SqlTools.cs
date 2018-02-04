using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace FHWebsite
{
    public static class SqlTools
    {
        /// <summary>
        /// Connects to a database/table and runs the command
        /// </summary>
        /// <param name="con">Connection string</param>
        /// <param name="cmd">Command string</param>
        /// <param name="parameters">The parameters in the command</param>
        /// <param name="paramTypes">The types for those parameters</param>
        /// <param name="paramValues">Values for the parameters</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string con, string cmd, string[] parameters, SqlDbType[] paramTypes, object[] paramValues)
        {
            SqlConnection db = new SqlConnection(con);
            SqlCommand command = new SqlCommand(cmd, db);

            // Parameterize the command and add the values
            for (int i=0; i<parameters.Length; i++)
            {
                command.Parameters.Add(parameters[i], paramTypes[i]);
                command.Parameters[parameters[i]].Value = paramValues[i];
            }

            //try
            //{
                db.Open();
                return command.ExecuteNonQuery();
            //}
            //catch
            //{
            //    return 0;
            //}
        }
    }
}