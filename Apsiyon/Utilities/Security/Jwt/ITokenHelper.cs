using Apsiyon.Entities.Concrete;
using System.Collections.Generic;

namespace Apsiyon.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
