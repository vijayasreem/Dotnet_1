
using System;

namespace dotnet
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Level { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }
}
