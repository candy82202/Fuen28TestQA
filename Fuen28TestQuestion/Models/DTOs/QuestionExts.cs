using Fuen28TestQuestion.Models.EFModels;

namespace Fuen28TestQuestion.Models.DTOs
{
    public static class QuestionExts
    {
        public static QuestionDto ToQDto(this Question entity)
        {
            return new QuestionDto
            {
                Id = entity.Id,
                TitleId = entity.TitleId,
                Text=entity.QuestionText
            };
        }

    }

}