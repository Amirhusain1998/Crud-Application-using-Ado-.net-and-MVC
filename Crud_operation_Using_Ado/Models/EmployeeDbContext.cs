using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Crud_operation_Using_Ado.Models
{
    public class EmployeeDbContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<Employee> GetEmployees() 
        {
            List<Employee> Employeeslist = new List<Employee>();
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetEmployees", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.Emp_id =Convert.ToInt32( reader.GetValue(0).ToString());
                emp.Emp_name = reader.GetValue(1).ToString();
                emp.Emp_gender = reader.GetValue(2).ToString();
                emp.Empage=Convert.ToInt32( reader.GetValue(3).ToString());
                emp.Empsalary = Convert.ToInt32(reader.GetValue(4).ToString());
                emp.Empcity = reader.GetValue(5).ToString();

                Employeeslist.Add(emp);
            }
            conn.Close();

            return Employeeslist;
        }
        public bool AddEmployee(Employee emp)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddEmployees", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", emp.Emp_name);
            cmd.Parameters.AddWithValue("@gender", emp.Emp_gender);
            cmd.Parameters.AddWithValue("@age", emp.Empage);
            cmd.Parameters.AddWithValue("@salary", emp.Empsalary);
            cmd.Parameters.AddWithValue("@city", emp.Empcity);
            conn.Open();
            int i =cmd.ExecuteNonQuery();
            
            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateEmployee(Employee emp)
        {
            SqlConnection conn = new SqlConnection(cs);

            
            SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", emp.Emp_id);
            cmd.Parameters.AddWithValue("@name", emp.Emp_name);
            cmd.Parameters.AddWithValue("@gender", emp.Emp_gender);
            cmd.Parameters.AddWithValue("@age", emp.Empage);
            cmd.Parameters.AddWithValue("@salary", emp.Empsalary);
            cmd.Parameters.AddWithValue("@city", emp.Empcity);

            conn.Open();

            int i = cmd.ExecuteNonQuery();

            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteEmployee(int id)
        {
            SqlConnection conn = new SqlConnection(cs);


            SqlCommand cmd = new SqlCommand("spDeleteEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
           

            conn.Open();

            int i = cmd.ExecuteNonQuery();

            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}