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
    public class NotesController : Controller    
    {
        private readonly LearningAppDbContext _db;
    
        public NotesController(LearningAppDbContext db)    
        {    
            _db = db;
        }
        
        [Authorize]
        [HttpPost]
        [Route("api/v1/chapters/{chapter_id}/contents/{content_id}/note")]
        public IActionResult NotesOfAContent([FromRoute] int content_id, [FromRoute] int chapter_id, [FromForm] NoteRequest reqObj)
        {
            // To get the student id from jwt token
            var currentUser = HttpContext.User;
            
            var StudentIdFromJWT = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            int StudentId = Int32.Parse(StudentIdFromJWT);

            Notes noteObj = new Notes(){
                Createdtime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                Note = reqObj.note,
                StudentId = StudentId,
                ContentId = content_id
            };
            
            var responseObj = _db.Notes.Where(n => n.StudentId == StudentId && n.ContentId == content_id).ToList();
            
            if(responseObj.Count() == 0)
            {
                _db.Notes.Add(noteObj);
                _db.SaveChanges();
                var updatedObj = _db.Notes.Where(n => n.StudentId == StudentId && n.ContentId == content_id).ToList();
                string output = NoteResponse(updatedObj);
                return Ok(output);
            }
            else{
                var UpdateNote = _db.Notes.Where(n => n.StudentId == StudentId && n.ContentId == content_id).ToList();
                UpdateNote.ForEach(v => v.Note = reqObj.note);
                _db.SaveChanges();

                string output = NoteResponse(UpdateNote);
                return Ok(output);
            }
            // return NotFound();
        }

        public string NoteResponse(List<Notes> NoteObj){

            Note NoteCustomObject = new Note(){
                StudentId = NoteObj[0].StudentId,
                ContentId = NoteObj[0].ContentId,
                Notes = NoteObj[0].Note,
                NotesCreatedTime = NoteObj[0].Createdtime
            };

            NoteResponse NoteReponseObj = new NoteResponse(){
                NoteObj = NoteCustomObject,
                Message = "Notes uploaded Successfully"
            };
            string output = JsonConvert.SerializeObject(NoteReponseObj);
            return output;
        }
    }
}