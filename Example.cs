using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADONETExample
{
    class Example
    {
        public static SqlConnection conn = null;
        public static SqlCommand cmd;
        public void SelectData()
        {
            try
            {
                if(conn == null)
                {
                    throw new Exception("Connected Not Initiated");
                }
                cmd = new SqlCommand("Select * from Employee", conn);
                cmd.Connection = conn;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        Console.Write(reader[i] + "\t\t");
                    Console.WriteLine("\n");
                }
                reader.Close();
            }
            
            catch (Exception e)
            {
                Console.WriteLine("Exception Occurred in SelectData() Method \n" + e);
            }
        }

        public int InsertRecord(int empid, string name, string city, int deptid, float sal, int reportsto)
        {
            int count = 0;
            try
            {
                cmd = new SqlCommand("Employee_Add", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", empid);
                cmd.Parameters.AddWithValue("@ename", name);
                cmd.Parameters.AddWithValue("@doj", DateTime.Now);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@did", deptid);
                cmd.Parameters.AddWithValue("@sal", sal);
                cmd.Parameters.AddWithValue("@repsto", reportsto);
                count = cmd.ExecuteNonQuery();
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Unable to Insert a Record\n" + e);
            }
            return count;
        }

        static SqlConnection InitiateDB()
        {
            try
            {
                conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=LearningDemodb; Integrated Security=true");
                conn.Open();
                Console.WriteLine("DB Initiated");
            }
            catch(Exception)
            {
                Console.WriteLine("Unable to Initiate Database");
            }
            return conn;
        }
        public SqlConnection Initiate()
        {
            return InitiateDB();
        }
        public void Close()
        {
            conn.Close();
        }
    }
}
