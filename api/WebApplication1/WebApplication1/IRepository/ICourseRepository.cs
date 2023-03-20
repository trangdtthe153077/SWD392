using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.IRepository
{
    public interface ICourseRepository
    {
        public JsonResult Get();
        public JsonResult Post(Course course);
        public JsonResult Put(Course course);
        public JsonResult Delete(int id);
    }
}
