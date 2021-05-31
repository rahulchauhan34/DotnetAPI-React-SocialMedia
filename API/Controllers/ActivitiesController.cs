using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System;

using Application.Activities;


namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {     
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] //activitie/ids
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id=id}); //API.exe debbuger
        }

        [HttpPost] // saves the whole Activity object 
        public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command{Activity =activity}));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id,[FromBody] Activity activity)
        {   
            activity.Id=id;
            return Ok(await Mediator.Send(new Edit.Command{Activity=activity}));
        }
        [HttpDelete("{id}")]
         public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id=id}));
        }

    }
}