using Api.Domain;
using System.Collections.Generic;

namespace Api.Businesss
{
    public interface IUserConnectService
    {
        List<Response> GetAllMails();
    }
}
