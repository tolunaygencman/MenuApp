using MenuApp.Business.DTOs.Members;
using MenuApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MenuApp.Business.Abstracts
{
    public interface IMemberService
    {
        Task<IDataResult<MemberDto>> GetByIdentityId(string identityId);
    }
}
