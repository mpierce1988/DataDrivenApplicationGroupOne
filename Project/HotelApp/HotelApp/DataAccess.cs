//
// AUTHOR: Michael Pierce
// DATE: 5/31/2022
// PURPOSE: Hotel Data-Driven App
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HotelApp
{
    public static class DataAccess
    {
        #region Static Methods

        /// <summary>
        /// Executes one sqlQuery string against the Hotel database and returns a DataTable
        /// with the result set
        /// </summary>
        /// <param name="sqlQuery">SELECT statement to execute against Hotel database</param>
        /// <returns>DataTable containing one result set</returns>
        public static DataTable GetData(string sqlQuery)
        {
            // create datatable object
            DataTable dt = new DataTable();

            // get connection string
            string connStr = ConfigurationManager.ConnectionStrings["Hotel"].ConnectionString;

            // open connection to database using using statement
            using(SqlConnection conn = new SqlConnection(connStr))
            {
                // create sql command object
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                // create data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // use fill method to fill datatable
                adapter.Fill(dt);
            }

            // return table
            return dt;
        }

        /// <summary>
        /// Executes an array of sqlQueries against the Hotel database and returns a DataSet containing
        /// one or more DataSets/Tables
        /// </summary>
        /// <param name="sqlQueries">A string array of sqlQueries</param>
        /// <returns>DataSet containing one to many DataTables with the result set(s)</returns>
        public static DataSet GetData(string[] sqlQueries)
        {
            // create datatable object
            DataSet ds = new DataSet();

            // combine array of queries into one query
            string sqlQuery = string.Join(";", sqlQueries);

            // get connection string
            string connStr = ConfigurationManager.ConnectionStrings["Hotel"].ConnectionString;

            // open connection to database using using statement
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // create sql command object
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                // create data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // use fill method to fill datatable
                adapter.Fill(ds);
            }

            // return table
            return ds;
        }

        /// <summary>
        /// Executes an sqlQuery and returns the first row, first column as an object. Meant
        /// for queries that return one value such as SUM or AVG
        /// </summary>
        /// <param name="sqlQuery">SQLQuery string that will return one value</param>
        /// <returns>Object</returns>
        public static object ExecuteScalar(string sqlQuery)
        {
            // instantiate object
            object obj = null;

            // get connection string
            string connStr = ConfigurationManager.ConnectionStrings["Hotel"].ConnectionString;

            using( SqlConnection conn = new SqlConnection(connStr))
            {
                // create SqlCommand
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                // open connection
                conn.Open();

                // ExecuteScalar method, returns first row first column as an object
                obj = cmd.ExecuteScalar();
            }

            // return result as an object
            return obj;

        }

        #endregion
    }
}
