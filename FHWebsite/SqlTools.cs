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
        /// Connects to a database/table and runs the command. Returns the number of rows affected.
        /// </summary>
        /// <param name="con">Connection string</param>
        /// <param name="cmd">Command string</param>
        /// <param name="parameters">The parameters in the command</param>
        /// <param name="paramTypes">The types for those parameters</param>
        /// <param name="paramValues">Values for the parameters</param>
        /// <returns>Number of rows affected or 0 if there was an error</returns>
        public static int ExecuteNonQuery(string con, string cmd, string[] parameters, SqlDbType[] paramTypes, string[] paramValues)
        {
            SqlConnection db = new SqlConnection(con);
            SqlCommand command = new SqlCommand(cmd, db);

            // Parameterize the command and add the values
            BuildCommand(command, parameters, paramTypes, paramValues);

            db.Open();
            return command.ExecuteNonQuery();

        }

        private static SqlCommand BuildCommand(SqlCommand cmd, string[] parameters, SqlDbType[] paramTypes, string[] paramValues)
        {
            // Parameterize the command and add values
            for (int i = 0; i < parameters.Length; i++)
            {
                cmd.Parameters.Add(parameters[i], paramTypes[i]);
                cmd.Parameters[parameters[i]].Value = paramValues[i];
            }
            return cmd;
        }

        /// <summary>
        /// Executes a query and returns the data
        /// </summary>
        /// <param name="con">Connection string for the database</param>
        /// <param name="cmd">Command to run</param>
        /// <param name="parameters">Parameters for the command</param>
        /// <param name="paramTypes">The types of each of those parameters</param>
        /// <param name="paramValues">Values of the parameters</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteQuery(string con, string cmd, string[] parameters, SqlDbType[] paramTypes, string[] paramValues)
        {
            SqlConnection db = new SqlConnection(con);
            SqlCommand command = new SqlCommand(cmd, db);

            BuildCommand(command, parameters, paramTypes, paramValues);

            db.Open();
            return command.ExecuteReader();
        }
    }
}