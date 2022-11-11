using Venhancer.Crowd.Identity.Core.Confugiration;
using Venhancer.Crowd.Identity.Core.Dtos;
using Venhancer.Crowd.Identity.Core.Models;

namespace Venhancer.Crowd.Identity.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);
        Task<ClientTokenDto> CreateTokenByClient(Client client);
    }
}
