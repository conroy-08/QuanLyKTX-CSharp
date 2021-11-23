using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX
{
    class DataHelper
    {
        string sqlConnect = "Data Source=COMPUTER-OF-VHD\\SQLEXPRESS;Initial Catalog=QLKTXSV;User ID=sa;Password=6723";
        SqlConnection sql_conn = null;

        public void OpenConnect()
        {
            sql_conn = new SqlConnection(sqlConnect);
            if (sql_conn.State != ConnectionState.Open)
            {
                sql_conn.Open();
            }
        }

        public void CloseConnect()
        {
            if (sql_conn.State != ConnectionState.Closed)
            {
                sql_conn.Close();
                sql_conn.Dispose();
            }
        }

        // Thực thi câu lệnh sql
        public void ExecuteQuery(string sql)
        {
            try
            {
                OpenConnect();
                SqlCommand command = new SqlCommand();
                command.Connection = sql_conn;
                command.CommandText = sql;
                command.ExecuteNonQuery();
                CloseConnect();
                command.Dispose();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }       
        }

        public DataTable getTable(string sql)
        {
            try
            {
                DataTable dta = new DataTable();
                OpenConnect();
                SqlDataAdapter res = new SqlDataAdapter(sql, sqlConnect);
                res.Fill(dta);
                res.Dispose();
                CloseConnect();
                return dta;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }


        public DataTable GetData(string proc)
        {

            OpenConnect();
            SqlCommand command = new SqlCommand(proc, sql_conn);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CloseConnect();
            return dt;

        }
        public DataTable GetDataByCondition(string proc, string[] name, object[] value, int Napra)
        {
            OpenConnect();
            SqlCommand cmd = new SqlCommand(proc, sql_conn);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < Napra; i++)
            {
                cmd.Parameters.AddWithValue(name[i], value[i]);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CloseConnect();
            return dt;
        }

        public void ExecuteQuery(string proc, string[] name, object[] value, int Napra)
        {

            OpenConnect();
            SqlCommand command = new SqlCommand(proc, sql_conn);
            command.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < Napra; i++)
            {
                command.Parameters.AddWithValue(name[i], value[i]);
            }
            command.ExecuteNonQuery();
            CloseConnect();
            command.Dispose();

        }

    }
}
