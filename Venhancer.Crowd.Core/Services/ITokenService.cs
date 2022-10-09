using Venhancer.Crowd.Core.Confugiration;
using Venhancer.Crowd.Core.Dtos;
using Venhancer.Crowd.Core.Models;

namespace Venhancer.Crowd.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);
        Task<ClientTokenDto> CreateTokenByClient(Client client);
    }
}
