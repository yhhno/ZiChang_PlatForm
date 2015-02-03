using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public class SqlHelp
{
    #region ConnectionString
    //public static readonly string ConnString = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
    #endregion

    public static string ConnString = string.Empty;
    #region ExecuteNonQuery
    
    public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
    {
        int reValue = 0;
        using (SqlConnection conn = new SqlConnection(ConnString))
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                PrepareCommand(cmd, cmdType, cmdText, cmdParams);
                conn.Open();
                reValue = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                CloseConnection(conn);
            }
        }
        return reValue;
    }
    public static int ExecuteNonQuery(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
    {
        int reValue = 0;
        using (SqlCommand cmd = conn.CreateCommand())
        {
            PrepareCommand(cmd, cmdType, cmdText, cmdParams);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            reValue = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        return reValue;
    }
    #endregion

    #region ExecuteReader
    public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
    {
        SqlConnection conn = new SqlConnection(ConnString);
        try
        {
            SqlDataReader reReader;
            using (SqlCommand cmd = conn.CreateCommand())
            {
                PrepareCommand(cmd, cmdType, cmdText, cmdParams);
                conn.Open();
                reReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
            }
            return reReader;
        }
        catch
        {
            conn.Close();
            throw;
        }
    }
    public static SqlDataReader ExecuteReader(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
    {
        SqlDataReader reReader;
        using (SqlCommand cmd = conn.CreateCommand())
        {
            PrepareCommand(cmd, cmdType, cmdText, cmdParams);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            reReader = cmd.ExecuteReader();
            cmd.Parameters.Clear();
        }
        return reReader;
    }
    #endregion

    #region ExecuteScalar
    public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
    {
        object reValue;
        using (SqlConnection conn = new SqlConnection(ConnString))
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                PrepareCommand(cmd, cmdType, cmdText, cmdParams);
                conn.Open();
                reValue = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
            }
        }
        return reValue;
    }
    public static object ExecuteScalar(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
    {
        object reValue;
        using (SqlCommand cmd = conn.CreateCommand())
        {
            PrepareCommand(cmd, cmdType, cmdText, cmdParams);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            reValue = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
        }
        return reValue;
    }
    #endregion

    #region ExecuteDataTable
    public static DataTable ExecuteDataTable(CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
    {
        DataTable reData = new DataTable();
        using (SqlConnection conn = new SqlConnection(ConnString))
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                PrepareCommand(cmd, cmdType, cmdText, cmdParams);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    conn.Open();
                    sda.Fill(reData);
                }
                cmd.Parameters.Clear();
            }
        }
        return reData;
    }
    public static DataTable ExecuteDataTable(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParams)
    {
        DataTable reData = new DataTable();
        using (SqlCommand cmd = conn.CreateCommand())
        {
            PrepareCommand(cmd, cmdType, cmdText, cmdParams);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                sda.Fill(reData);
            }
            cmd.Parameters.Clear();
        }
        return reData;
    }
    #endregion

    #region CloseConnection
    public static void CloseConnection(SqlConnection conn)
    {
        if (conn.State != ConnectionState.Closed)
            conn.Close();
    }
    #endregion

    #region PrepareCommand
    private static void PrepareCommand(SqlCommand cmd, CommandType cmdType, string cmdText, SqlParameter[] cmdParams)
    {
        cmd.CommandText = cmdText;
        cmd.CommandType = cmdType;
        if (cmdParams != null)
        {
            foreach (SqlParameter param in cmdParams)
            {
                cmd.Parameters.Add(param);
            }
        }
    }
    #endregion

}