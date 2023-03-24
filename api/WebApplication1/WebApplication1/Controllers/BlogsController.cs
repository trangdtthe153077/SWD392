using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;
using WebApplication1.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {

        private readonly IBlogRepository _repository;
        public BlogsController(IBlogRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public JsonResult Get()
        {

            return _repository.Get();
        }

        [HttpPost]
        public JsonResult Post(Blog course)
        {
            return _repository.Post(course);
        }
        [HttpPut]
        public JsonResult Put(Blog course)
        {
            return _repository.Put(course);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
