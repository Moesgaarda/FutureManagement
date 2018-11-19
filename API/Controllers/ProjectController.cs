using API.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Threading.Tasks;
using System;

namespace API.Controllers
{

    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly DataContext _context;

        public ProjectController(DataContext context)
        {
            this._context = context;
        }
        public Task<Project> GetProject(int projectId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> CreateProject()
        {
            throw new NotImplementedException();
        }
        public Task<List<Project>> GetAllProjects()
        {
            throw new NotImplementedException();
        }
        public Task<bool> EditProject(int projectId)
        {
            throw new NotImplementedException(); //TODO Unit testing
        }
    }
}