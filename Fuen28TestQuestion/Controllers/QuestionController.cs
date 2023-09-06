using Fuen28TestQuestion.Models.DTOs;
using Fuen28TestQuestion.Models.EFModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata.Ecma335;

namespace Fuen28TestQuestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly TestContext _context;
        private HashSet<int> appearedQuestionIds = new HashSet<int>();
        private Dictionary<int, HashSet<int>> appearedQuestionIdsByTitle = new Dictionary<int, HashSet<int>>();
        private List<int> allQuestionIds;
        public QuestionController(TestContext context)
        {
            _context = context;
            allQuestionIds = _context.Questions.Select(q => q.Id).ToList();
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<QuestionDto>>> GetQuestions()
        {
            var questions = await _context.Questions             
             .Select(q => q.ToQDto())
             .ToListAsync();

            if (questions == null || questions.Count == 0)
            {
                return NotFound();
            }

            return questions;
        }
        [HttpGet("GetAllRandom")]
        public async Task<ActionResult<List<QuestionDto>>> GetRandomizedQuestions()
        {
            var questions = await _context.Questions
                .Select(q => q.ToQDto())
                .ToListAsync();

            if (questions == null || questions.Count == 0)
            {
                return NotFound();
            }

            // Shuffle the questions using a random seed
            Random random = new Random();
            questions = questions.OrderBy(q => random.Next()).ToList();

            return questions;
        }
        [HttpGet("GetDiceRandom")]
        public async Task<ActionResult<List<QuestionDto>>> GetRandomiQuestionsForDice()
        {
            var questions = await _context.Questions
                .Select(q => q.ToQDto())
                .ToListAsync();

            if (questions == null || questions.Count == 0)
            {
                return NotFound();
            }

            // Shuffle the questions using a random seed
            Random random = new Random();
            questions = questions.OrderBy(q => random.Next()).Take(16).ToList();

            return questions;
        }
   
        [HttpGet]
        public async Task<ActionResult<List<QuestionDto>>> GetQuestionsByTitleId(int titleId)
        {
            var questions = await _context.Questions
             .Where(q => q.TitleId == titleId)
             .Select(q => q.ToQDto())
             .ToListAsync();

            if (questions == null || questions.Count == 0)
            {
                return NotFound();
            }

            return questions;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDto>> GetQuestionsById(int id)
        {
            var question = await _context.Questions
            .Where(q => q.Id == id)
            .Select(q => q.ToQDto())
   .FirstOrDefaultAsync();

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }
        [HttpGet("random")]
        public async Task<ActionResult<QuestionDto>> GetRandomQuestionsByTitleId(int titleId)
        {
            var questions = await _context.Questions
             .Where(q => q.TitleId == titleId)
             .Select(q => q.ToQDto())
             .ToListAsync();

            if (questions == null || questions.Count == 0)
            {
                return NotFound();
            }
            int seed = Guid.NewGuid().GetHashCode();
            var random = new Random(seed);
            int randomIndex = random.Next(questions.Count);

            return questions[randomIndex];
        }
        //[HttpGet("randomNotrepeat")]
        //public async Task<ActionResult<QuestionDto>> GetRandomNotRepeatQuestionsByTitleId(int titleId)
        //{
        //    var questions = await _context.Questions
        // .Where(q => q.TitleId == titleId)
        // .Select(q => q.ToQDto())
        // .ToListAsync();

        //    if (questions == null || questions.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    List<QuestionDto> availableQuestions = questions
        //        .Where(q => !appearedQuestionIds.Contains(q.Id))
        //        .ToList();

        //    if (availableQuestions.Count == 0)
        //    {
        //        appearedQuestionIds.Clear();
        //        availableQuestions = questions.ToList();
        //    }

        //    if (appearedQuestionIds.Count == availableQuestions.Count)
        //    {
        //        appearedQuestionIds.Clear();
        //    }

        //    int seed = Guid.NewGuid().GetHashCode();
        //    var random = new Random(seed);

        //    int randomIndex;
        //    do
        //    {
        //        randomIndex = random.Next(availableQuestions.Count);
        //    } while (appearedQuestionIds.Contains(availableQuestions[randomIndex].Id));

        //    int selectedQuestionId = availableQuestions[randomIndex].Id;
        //    appearedQuestionIds.Add(selectedQuestionId);

        //    return availableQuestions[randomIndex];
        //}
        [HttpGet("randomNotrepeat")]
        public async Task<ActionResult<QuestionDto>> GetRandomQuestionsnotrepByTitleId(int titleId)
        {
            var availableQuestionIds = allQuestionIds.Except(appearedQuestionIds).ToList();

            if (availableQuestionIds.Count == 0)
            {
                appearedQuestionIds.Clear();
                availableQuestionIds = allQuestionIds.ToList();
            }

            int seed = Guid.NewGuid().GetHashCode();
            var random = new Random(seed);
            int randomIndex = random.Next(availableQuestionIds.Count);
            int selectedQuestionId = availableQuestionIds[randomIndex];
            appearedQuestionIds.Add(selectedQuestionId);

            var selectedQuestion = await _context.Questions
                .Where(q => q.Id == selectedQuestionId)
                .Select(q => q.ToQDto())
                .FirstOrDefaultAsync();

            return selectedQuestion;
        }
    }
}
