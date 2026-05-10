using Microsoft.Data.SqlClient;
using StepClass.Models;
using StepClass.Services;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StepClass
{
    internal class Program
    {
        const string _connectionString = @"Server=YourServer;Database=YourDatabase;Trusted_Connection=True;TrustServerCertificate=True;";

        static async Task Main(string[] args)
        {
            //var allStudents = await GetSingleStudentAsync(1);

            //var newStudent = new CreateStudentDto
            //{
            //    FirstName = "John",
            //    LastName = "Doe",
            //    BirthDate = new DateTime(2000, 1, 1),
            //    Email = "johndildo@gmail.com",
            //    Phone = "1234567891",
            //    GroupName = "SE-524-8"
            //};


            //var result = await AddStudentAsync(newStudent);
            // Console.WriteLine(result);


            DatabaseService databaseService = new DatabaseService(_connectionString);
           await databaseService.ExecuteAsync("AddNewStudent",
                new SqlParameter("@firstName", "kako"),
                new SqlParameter("@lastName", "gasviani"),
                new SqlParameter("@birthDate", new DateTime(2000, 1, 1)),
                new SqlParameter("@email", "vinme@gmail.com"),
                new SqlParameter("@phone", "123456789"),
                new SqlParameter("@groupName", "SE-524-8"));
        }


        private async static Task<List<Student>> GetStudentsAsync()
        {
            var students = new List<Student>();
            
            using SqlConnection connection = new SqlConnection(_connectionString);
            
            using SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);
            command.CommandType = CommandType.Text;

            await connection.OpenAsync();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                students.Add(new Student
                {
                    Id = reader.GetInt32("Id"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    BirthDate = reader.GetDateTime("BirthDate"),
                    Email = reader.GetString("Email"),
                    Phone = reader.GetString("Phone"),
                    GroupName = reader.GetString("GroupName")
                });
            }
            return students;
        }


        private async static Task<Student> GetSingleStudentAsync(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = new SqlCommand("SELECT * FROM Students WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.CommandType = CommandType.Text;

            await connection.OpenAsync();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                return new Student
                {
                    Id = reader.GetInt32("Id"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    BirthDate = reader.GetDateTime("BirthDate"),
                    Email = reader.GetString("Email"),
                    Phone = reader.GetString("Phone"),
                    GroupName = reader.GetString("GroupName")
                };
            }

            return default;
        }


        private async static Task<int> AddStudentAsync(CreateStudentDto model)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("INSERT INTO Students (FirstName, LastName, BirthDate, Email, Phone, GroupName) VALUES (@firstName, @lastName, @birthDate, @email, @phone, @groupName);", connection);
            command.Parameters.AddWithValue("@firstName", model.FirstName);
            command.Parameters.AddWithValue("@lastName", model.LastName);
            command.Parameters.AddWithValue("@birthDate", model.BirthDate);
            command.Parameters.AddWithValue("@email", model.Email);
            command.Parameters.AddWithValue("@phone", model.Phone);
            command.Parameters.AddWithValue("@groupName", model.GroupName);
            command.CommandType = CommandType.Text;

            await connection.OpenAsync();

            return await command.ExecuteNonQueryAsync();

         
        }
    }
}
