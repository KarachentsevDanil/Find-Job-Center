using FJB.Domain.Entities.Users;

namespace RJF.WebService.Models
{
    public class CurrentUserViewModel
    {
        public int UserId { get; set; }

        public bool IsClient { get; set; }

        public string Name { get; set; }

        public Role? Role { get; set; }
    }
}