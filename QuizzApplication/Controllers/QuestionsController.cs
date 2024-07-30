using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuizzApplication.Data;
using QuizzApplication.Model;
using System;
using System.Text.Json;

namespace QuizzApplication.Controllers
{
    public class QuestionsController : Controller
    {
        public readonly QuestionsContext context;
        public QuestionsController(QuestionsContext _context) { 
            context = _context;
        }
        [HttpPost]
        [Route("/postData")]
        //[FromBody]
        public async Task<IActionResult> postData([FromBody]Questions allQuestionData)
        {
            try {

                context.Questions.Add(allQuestionData);
                await context.SaveChangesAsync();
                return Ok(new { message="successfully updated" });
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error creating new employee record");
            } 
        }

        [HttpGet]
        [Route("/getData")]
        public async Task<IActionResult> GetData(string Languages,string Levels,int No_of_questions)
        {
            context.Database.ExecuteSqlRaw($"truncate table particularQuestion");
            //context.Database.ExecuteSqlRaw($"INSERT INTO PARTICULARQUESTION(questions,optionA,optionB,optionC,optionD,Answers) SELECT TOP {No_of_questions} questions,optionA,optionB,optionC,optionD,Answers FROM questions Where Languages='{Languages}' and Levels='{Levels}' ORDER BY NEWID()");
            context.Database.ExecuteSqlRaw($@"INSERT INTO PARTICULARQUESTION(questions, optionA, optionB, optionC, optionD, Answers) SELECT TOP {No_of_questions} COALESCE(questions, 'null')
            AS questions, COALESCE(optionA, 'null') AS optionA, COALESCE(optionB, 'null') AS optionB, COALESCE(optionC, 'null') AS optionC, COALESCE(optionD, 'null') AS optionD,
            COALESCE(Answers, 'null') AS Answers FROM questions WHERE Languages = '{Languages}' AND Levels = '{Levels}' AND questions IS NOT NULL AND Answers IS NOT NULL ORDER BY NEWID()");
            var Data = context.particularQuestion.FromSql($"SELECT * FROM PARTICULARQUESTION").ToList();
            int totalCount = Data.Count();
            //var settings = new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //};
            //var json = JsonConvert.SerializeObject(appxRegisters, settings);
            //return Content(json, "application/json");
            return Ok(new { Data, totalCount });
        }
        [HttpGet]
        [Route("/getParticularQuestion")]
        public async Task<IActionResult> getParticularQuestion(int count, int page)
        {
            var list = context.particularQuestion.FromSql($"SELECT  * FROM PARTICULARQUESTION ORDER BY id  OFFSET {count * (page - 1)} ROWS  FETCH NEXT {count} ROWS ONLY").ToList();
            return Ok(new { list });
        }
        [HttpGet]
        [Route("/getAllDataForQuestions")]
        public async Task<IActionResult> getAllDataForQuestions()
        {
            var list = await context.Questions.ToListAsync();
            return Ok(list);
        }

        [HttpDelete]
        [Route("/deleteDataForQuestions")]
        public async Task<IActionResult> deleteDataForQuestions(int id)
        {
            var person = await context.Questions.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            context.Questions.Remove(person);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}

//[HttpGet]
//[Route("/getData")]
////Insert into table2
//public async Task<IActionResult> GetData()
//{
//    context.Database.ExecuteSqlRaw($"truncate table particularQuestion");
//    context.Database.ExecuteSqlRaw($"INSERT INTO PARTICULARQUESTION(questions,optionA,optionB,optionC,optionD,Answers) SELECT TOP 10 questions,optionA,optionB,optionC,optionD,Answers FROM questions ORDER BY NEWID()");
//    //var Data = context.Questions.FromSql($"SELECT TOP 10 * FROM questions ORDER BY NEWID()").ToList();
//    var Data = context.Questions.FromSql($"SELECT * FROM PARTICULARQUESTION").ToList();

//    int totalCount = Data.Count();
//    return Ok(new { Data, totalCount });
//}

//try
//{
//    if (employee == null)
//        return BadRequest();

//    var createdEmployee = await employeeRepository.AddEmployee(employee);

//    return CreatedAtAction(nameof(GetEmployee),
//        new { id = createdEmployee.EmployeeId }, createdEmployee);
//}
//catch (Exception)
//{
//    return StatusCode(StatusCodes.Status500InternalServerError,
//        "Error creating new employee record");
//}