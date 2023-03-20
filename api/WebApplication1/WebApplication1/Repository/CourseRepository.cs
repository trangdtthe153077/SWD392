using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebApplication1.IRepository;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CourseRepository: ICourseRepository
    {
        private readonly IConfiguration _configuration;
        public CourseRepository(IConfiguration configuration)
        {
            _configuration=configuration;
        }

  
        public JsonResult Get()
        {
            string query = @"
                SELECT Id, Category, Status, Owner, Name, Thumbnail, Tagline, Title, [Date], [Description], FeaturedSubject 
                FROM dbo.Course
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

   
        public JsonResult Post(Course course)
        {
            string query = @"
                INSERT INTO dbo.Course
                (Category, Status, Owner, Name, Thumbnail, Tagline, Title, [Date], [Description], FeaturedSubject)
                VALUES (@Category, @Status, @Owner, @Name, @Thumbnail, @Tagline, @Title, @Date, @Description, @FeaturedSubject)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Category", course.Category);
                    myCommand.Parameters.AddWithValue("@Status", course.Status);
                    myCommand.Parameters.AddWithValue("@Owner", course.Owner);
                    myCommand.Parameters.AddWithValue("@Name", course.Name);
                    myCommand.Parameters.AddWithValue("@Thumbnail", course.Thumbnail);
                    myCommand.Parameters.AddWithValue("@Tagline", course.Tagline);
                    myCommand.Parameters.AddWithValue("@Title", course.Title);
                    myCommand.Parameters.AddWithValue("@Date", course.Date);
                    myCommand.Parameters.AddWithValue("@Description", course.Description);
                    myCommand.Parameters.AddWithValue("@FeaturedSubject", course.FeaturedSubject);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Course added successfully");
        }


      
        public JsonResult Put(Course course)
        {
            string query = @"
                UPDATE dbo.Course
                SET Category = @Category, Status = @Status, Owner = @Owner, Name = @Name, Thumbnail = @Thumbnail, 
                    Tagline = @Tagline, Title = @Title, [Date] = @Date, [Description] = @Description, 
                    FeaturedSubject = @FeaturedSubject
                WHERE Id = @Id
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", course.Id);
                    myCommand.Parameters.AddWithValue("@Category", course.Category);
                    myCommand.Parameters.AddWithValue("@Status", course.Status);
                    myCommand.Parameters.AddWithValue("@Owner", course.Owner);
                    myCommand.Parameters.AddWithValue("@Name", course.Name);
                    myCommand.Parameters.AddWithValue("@Thumbnail", course.Thumbnail);
                    myCommand.Parameters.AddWithValue("@Tagline", course.Tagline);
                    myCommand.Parameters.AddWithValue("@Title", course.Title);
                    myCommand.Parameters.AddWithValue("@Date", course.Date);
                    myCommand.Parameters.AddWithValue("@Description", course.Description);
                    myCommand.Parameters.AddWithValue("@FeaturedSubject", course.FeaturedSubject);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

 
        public JsonResult Delete(int id)
        {
            string query = @"
                          DELETE FROM [dbo].[Course]
                            where Id=@id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }



    }
}
