using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venhancer.Crowd.Identity.Shared.Dtos
{
    public class CreateTokenDto
    {
        public class Data
        {
            public string? AccessToken { get; set; }
            public DateTime AccessTokenExpiration { get; set; }
            public string? RefreshToken { get; set; }
            public DateTime RefreshTokenExpiration { get; set; }
        }

        public class Root
        {
            public Data? Data { get; set; }
            public int StatusCode { get; set; }
            public bool IsSuccessful { get; set; }
            public ErrorDto? Error { get; set; }
        }
    }
}
