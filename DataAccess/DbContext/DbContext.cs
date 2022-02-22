using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Db_Context
{
    public static class DbContext
    {
        public static SqlCommand GetContext(string Connection, CommandType CommandType)
        {
            return new SqlCommand
            {
                Connection = new SqlConnection(Connection),
                CommandType = CommandType
            };
        }

        private static void Execute(SqlCommand comd, string CommandText, Action Execute, Action<Exception> ex = null)
        {
            comd.Connection.Open();

            using (SqlTransaction transaction = comd.Connection.BeginTransaction(CommandText))
            {
                try
                {
                    Execute();

                    transaction.Commit();
                }
                catch (Exception exe)
                {
                    transaction.Rollback();
                    ex?.Invoke(exe);
                }
            }

            comd.Connection.Close();
            comd.Dispose();
        }

        public static void ExecuteQuery(this SqlCommand comd, string CommandText, Action<int> Action = null, Action<Exception> ex = null)
        {
            Execute(comd, CommandText, () =>
            {
                int value = comd.ExecuteNonQuery();

                Action?.Invoke(value);

            },ex);
        }

        public static void ExecuteToReader(this SqlCommand comd, string CommandText, Action<SqlDataReader> Action = null, Action<Exception> ex = null)
        {
            Execute(comd, CommandText, () =>
            {
                SqlDataReader value = comd.ExecuteReader();

                Action?.Invoke(value);

            }, ex);
        }
    }
}
