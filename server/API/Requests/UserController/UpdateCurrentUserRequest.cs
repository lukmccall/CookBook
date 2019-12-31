namespace CookBook.API.Requests.UserController
{
    public class UpdateCurrentUserRequest
    {
        public string UserName { get; set; }

        public string UserSurname { get; set; }
        
        public int? Age { get; set; }

        public string Description { get; set; }
        
        public string PhoneNumber { get; set; }
    }
}