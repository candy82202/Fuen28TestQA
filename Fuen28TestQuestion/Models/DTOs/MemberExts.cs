using Fuen28TestQuestion.Models.EFModels;

namespace Fuen28TestQuestion.Models.DTOs
{
    public static class MemberExts
    {
        public static MembersDTO ToQDto(this Member entity)
        {
            return new MembersDTO
            {
                Id = entity.Id,
                Username = entity.Username,
                ImageName = entity.ImageName,

            };
        }
    }
}
