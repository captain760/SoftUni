using System;
using System.Data.SqlClient;

namespace LiveDemo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();
            string countQuery = "SELECT COUNT(*) AS [EmployeesCount] FROM [Employees]";
            string employeesQuery = "SELECT [FirstName],                                                                        [LastName],                                                                         [JobTitle] FROM [Employees]";
            SqlCommand sqlCommand = new SqlCommand(countQuery, sqlConnection);
            int employeesCount = (int)sqlCommand.ExecuteScalar();
            Console.WriteLine(employeesCount);

            SqlCommand sqlTableCommand = new SqlCommand(employeesQuery, sqlConnection);
            using SqlDataReader tableQuery = sqlTableCommand.ExecuteReader();
            int rowNum = 1;
            while (tableQuery.Read())
            {
                string firstName = (string)tableQuery["FirstName"];
                string lastName = (string)tableQuery["LastName"];
                string jobTitle = (string)tableQuery["JobTitle"];
                Console.WriteLine($"{rowNum++}. --> {firstName} {lastName} =====>> {jobTitle}");
            }
            tableQuery.Close();
            sqlConnection.Close();
        }
    }
}
