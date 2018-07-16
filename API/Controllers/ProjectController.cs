using API.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Threading.Tasks;
using System;

namespace API.Controllers
{

    [Route("api/[]")]
    public class ProjectController : Controller
    {
        private readonly DataContext _context;

        public ProjectController(DataContext context){
            this._context = context;
        }
        public async Task<Project> GetProject(int projectId){
            throw new NotImplementedException();
        }
        public async Task<bool> CreateProject(){
            throw new NotImplementedException();
        }
        public async Task<List<Project>> GetAllProjects(){
            throw new NotImplementedException();
        }
        public async Task<bool> EditProject(int projectId){
            throw new NotImplementedException(); //TODO Unit testing
        }
    }
}