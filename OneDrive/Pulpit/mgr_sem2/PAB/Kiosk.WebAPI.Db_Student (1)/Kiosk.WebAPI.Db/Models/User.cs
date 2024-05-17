namespace Kiosk.WebAPI.Db.Models
{
    public class User
    {
      
            public int Id { get; set; }
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }
        
            string PasswordHash {  get; set; }

            public string PhoneNumber { get; set; }
    }
}
