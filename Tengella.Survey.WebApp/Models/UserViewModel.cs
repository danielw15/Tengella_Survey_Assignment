namespace Tengella.Survey.WebApp.Models
{
    public class UserViewModel
    {

        public int UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; }

        public string UserType { get; set; }
        public string? OrgNumber { get; set; }
        public string? OrgName { get; set; }
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}


