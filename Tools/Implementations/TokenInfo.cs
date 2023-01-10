using Logger.Exceptions;
using Logger.Tools.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tools.Implementations
{
    public class TokenInfo : ITokenInfo 
    {
        public string getToken()
        {
            string token;
            var header = IDisplay._request.Headers;
            var cookies = IDisplay._request.Cookies;
            if (header.ContainsKey("Authorization"))
            {
                token = header["Authorization"];
                token = token.Split(' ')[1];
            }
            else if (cookies.ContainsKey("token"))
            {
                token = cookies["token"];
            }
            else
            {
                throw new NoTokenException("no token found");
            }
            return token;
        }

        public string getShopId()
        {
            var token = getToken();
            string shopId;
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            try
            {
                shopId = jwtSecurityToken.Claims.First(s => s.Type == "shopId").Value.ToString();
                return shopId;
            }
            catch (InvalidOperationException)
            {
                throw new BadTokenException("the token doesn't contain the shopID");
            }

            return "";
        }

        public string getTerminalId()
        {
            var token = getToken();
            string terminalId;
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            try
            {
                terminalId = jwtSecurityToken.Claims.First(s => s.Type == "terminalId").Value.ToString();
                return terminalId;
            }
            catch (InvalidOperationException)
            {
                throw new BadTokenException("the token doesn't contain the terminalID");
            }

            return "";
        }
    }
}
