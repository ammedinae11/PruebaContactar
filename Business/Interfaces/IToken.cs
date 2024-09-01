using DTO.Request.Token;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IToken
    {
        Task<GenericResponse<TokenResponse>> Token(TokenRequest model);
    }
}
