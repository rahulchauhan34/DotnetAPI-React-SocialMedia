using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

         [HttpGet("{id}")] //activitie/ids
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }

    }
}