﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;


namespace Q2_P2
{
    public class DAO
    { 
        public static SqlConnection getConnection()
        {
            SqlConnection connection =  new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindDB"].ConnectionString);
            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }
        public static DataTable getTableFromSql(SqlCommand command)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            dataAdapter.Fill(table);
            return table;
        }
        public static void insertDataToSql(SqlCommand command)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
        }
        public static void updateDataToSql(SqlCommand command)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
        }
        public static void runBatchSql(List<String> dbOperations)
        {
            SqlConnection conn = DAO.getConnection();
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();

            foreach (string commandString in dbOperations)
            {
                SqlCommand cmd = new SqlCommand(commandString, conn, transaction);
                cmd.ExecuteNonQuery();
            }

            transaction.Commit();
        }
    }
}
