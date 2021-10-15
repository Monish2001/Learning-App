using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;
using System;    
using System.Security.Claims;    
using System.Collections.Generic;
using System.Linq;
using Learning_App.Data;
using Learning_App.Models;
using Newtonsoft.Json;

    
namespace Learning_App.Controllers    
{   
    public class BoardsController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public BoardsController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        

        [Authorize]
        [HttpGet]
        [Route("api/v1/boards")]
        public IActionResult ListOfBoards()
        {            
            var boardList = _db.Boards.ToList();
            
            List<Board> ListOfBoards = new List<Board>();
            
            for (var i = 0; i < boardList.Count; i++)
            {
                Board responseObj = new Board(){
                    Id = boardList[i].Id,
                    Name = boardList[i].Name,
                    Description = boardList[i].Description,
                    Logo = boardList[i].Logo
                };

                ListOfBoards.Add(responseObj);
            }
            string output = JsonConvert.SerializeObject(ListOfBoards);  
            return Ok(output);
        }

        [Authorize]
        [HttpPut]
        [Route("api/v1/boards")]
        public IActionResult SelectBoard([FromForm] BoardResquest boardObj)
        {
            var currentUser = HttpContext.User;
            
            var StudentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int StudentId = Int32.Parse(StudentIdFromJWT);
        
            int BoardId = boardObj.Id;

            StudentEnrollments s = new StudentEnrollments{
                StudentId = StudentId,
                BoardId = BoardId
            };

            _db.StudentEnrollments.Add(s);
            _db.SaveChanges();
            
            var BoardDetails = _db.Boards.Where(b => b.Id == BoardId).ToList();

            Board responseObj = new Board(){
                    Id = BoardDetails[0].Id,
                    Name = BoardDetails[0].Name,
                    Description = BoardDetails[0].Description,
                    Logo = BoardDetails[0].Logo
                };

            string output = JsonConvert.SerializeObject(responseObj);  
            return Ok(output);
        }
    }
}