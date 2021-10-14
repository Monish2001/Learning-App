using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc; 
using System;        
using System.Security.Claims;    
using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
using Newtonsoft.Json;
using Learning_App.Models;

namespace Learning_App.Controllers    
{   
    public class VotesController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public VotesController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        
        [Authorize]
        [HttpGet]
        [Route("api/v1/contents/{content_id}/vote")]
        public IActionResult VoteContent([FromRoute] int content_id, [FromForm] VoteRequest reqObj)
        {
            // To get the student id from jwt token
            var currentUser = HttpContext.User;
            
            var StudentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int StudentId = Int32.Parse(StudentIdFromJWT);

            Votes voteObj = new Votes(){
                Votedtime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                IsVoted = reqObj.vote,
                StudentId = StudentId,
                ContentId = content_id
            };
            
            var responseObj = _db.Votes.Where(v => v.StudentId == StudentId && v.ContentId == content_id).ToList();
            
            if(responseObj.Count() == 0)
            {
                _db.Votes.Add(voteObj);
                _db.SaveChanges();
                string output = JsonConvert.SerializeObject(voteObj);
                return Ok(output);
            }
            else{
                var UpdateVote = _db.Votes.Where(v => v.StudentId == StudentId && v.ContentId == content_id).ToList();
                UpdateVote.ForEach(v => v.IsVoted = reqObj.vote);
                _db.SaveChanges();
                string output = JsonConvert.SerializeObject(UpdateVote);
                return Ok(output);
            }
            // return NotFound();
        }
    }
}