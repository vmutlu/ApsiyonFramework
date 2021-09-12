using Apsiyon.Entities.Abstract;
using System.Collections.Generic;

namespace Apsiyon.Entities.Concrete
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash{ get; set; }
        public bool Status{ get; set; }
        public List<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
