using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.IRepository
{
    public interface IBlogRepository
    {
        public JsonResult Get();
        public JsonResult Post(Blog course);
        public JsonResult Put(Blog course);
        public JsonResult Delete(int id);
    }
}
