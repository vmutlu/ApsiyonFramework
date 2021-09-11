using Apsiyon.Utilities.Results;
using System;

namespace Apsiyon.Services.Abstract
{
    public interface IPaginationUriService
    {
        public Uri GetPageUri(PaginationQuery paginationQuery);
    }
}
