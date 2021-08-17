using Microsoft.IdentityModel.Tokens;
using System;
using WebApplication2.Models;

namespace WebApplication2
{
    public interface ITokenProvider
    {
        string CreateToken(Usuario usuario, DateTime expiretionDate);
        TokenValidationParameters GetValidationParameters();
    }
}

//"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJmcmFuayIsInVuaXF1ZV9uYW1lIjoiNzJEQTBFQkI2OUE0MDI3OTlFRTlBOTM5M0VBQjU1NjhBQjNDMDYyMDMzNEI5RkZDQUNGODk4NDI2MUNFQjIzQ0U2NUU5QUJDREI3N0M4NTUyMEIzMzRBMzUzQjk5NUY5MjgxNUU1NUMwNTJENjQ2ODJDQUU5NUEzRTg0RjRBMkUiLCJuYmYiOjE2MjkyMTgwNDMsImV4cCI6MTYyOTMwNDQzOSwiaWF0IjoxNjI5MjE4MDQzLCJpc3MiOiJteWFwcCIsImF1ZCI6ImF5dXNlcnMifQ.9qi039IwIbZ2dXx2LL2NE_XfeTYLYZXm3lYKHFHR2Dc"