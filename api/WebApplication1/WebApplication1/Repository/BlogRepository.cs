using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebApplication1.IRepository;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class BlogRepository: IBlogRepository
    {
        private readonly IConfiguration _configuration;
        public BlogRepository(IConfiguration configuration)
        {
            _configuration=configuration;
        }


        public JsonResult Get()
        {
            string query = @"
               SELECT [id]
      ,[title]
      ,[thumbnail]
      ,[brief]
      ,[description]
      ,[status]
      ,[date]
  FROM [dbo].[Blog]
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


        public JsonResult Post(Blog blog)
        {
            string query = @"
                INSERT INTO [dbo].[Blog]
           ([title]
           ,[thumbnail]
           ,[brief]
           ,[description]
           ,[status]
           ,[date])
                VALUES (@Title, @Thumbnail, @Brief, @Description, @Status, @Date)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();

                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Title", blog.Title);
                    myCommand.Parameters.AddWithValue("@Thumbnail", blog.Thumbnail);
                    myCommand.Parameters.AddWithValue("@Brief", blog.Brief);
                    myCommand.Parameters.AddWithValue("@Description", blog.Description);
                    myCommand.Parameters.AddWithValue("@Status", blog.Status);
                    myCommand.Parameters.AddWithValue("@Date", blog.Date);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                }

                myCon.Close();
            }

            return new JsonResult("Blog added successfully");
        }



        public JsonResult Put(Blog blog)
        {
            string query = @"
        UPDATE dbo.Blog
        SET Title = @Title, Thumbnail = @Thumbnail, Brief = @Brief, Description = @Description, 
            Status = @Status, Date = @Date
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
                    myCommand.Parameters.AddWithValue("@Id", blog.Id);
                    myCommand.Parameters.AddWithValue("@Title", blog.Title);
                    myCommand.Parameters.AddWithValue("@Thumbnail", blog.Thumbnail);
                    myCommand.Parameters.AddWithValue("@Brief", blog.Brief);
                    myCommand.Parameters.AddWithValue("@Description", blog.Description);
                    myCommand.Parameters.AddWithValue("@Status", blog.Status);
                    myCommand.Parameters.AddWithValue("@Date", blog.Date);

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
                         DELETE FROM [dbo].[Blog]
                            where id=@id
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
