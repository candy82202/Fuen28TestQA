using Fuen28TestQuestion.Models.EFModels;

namespace Fuen28TestQuestion.Models.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public string Text { get; set; }

      //  public string Answer { get; set; }

        public int TitleId { get; set; }

    }
   
}
