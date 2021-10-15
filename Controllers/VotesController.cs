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
        [HttpPost]
        [Route("api/v1/chapters/{chapter_id}/contents/{content_id}/vote")]
        public IActionResult VoteContent([FromRoute] int content_id, [FromRoute] int chapter_id, [FromForm] VoteRequest reqObj)
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
                var updatedObj = _db.Votes.Where(v => v.StudentId == StudentId && v.ContentId == content_id).ToList();
                string output = VoteResponse(updatedObj);
                return Ok(output);
            }
            else{
                var UpdateVote = _db.Votes.Where(v => v.StudentId == StudentId && v.ContentId == content_id).ToList();
                UpdateVote.ForEach(v => v.IsVoted = reqObj.vote);
                _db.SaveChanges();

                string output = VoteResponse(UpdateVote);
                return Ok(output);
            }
            // return NotFound();
        }

        public string VoteResponse(List<Votes> VoteObj){

            Vote VoteCustomObject = new Vote(){
                StudentId = VoteObj[0].StudentId,
                ContentId = VoteObj[0].ContentId,
                IsVoted = VoteObj[0].IsVoted,
                VotedTime = VoteObj[0].Votedtime
            };

            VoteResponse VoteReponseObj = new VoteResponse(){
                VoteObj = VoteCustomObject,
                Message = "Voted Successfully"
            };
            string output = JsonConvert.SerializeObject(VoteReponseObj);
            return output;
        }
    }
}