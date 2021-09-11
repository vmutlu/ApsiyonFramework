using Apsiyon.Entities.Abstract;

namespace Apsiyon.Entities.Concrete
{
    public class UserOperationClaim : Entity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
