using Api.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Api.Businesss
{
    public class UserConnectService : IUserConnectService
    {
        public List<Response> GetAllMails()
        {
            var json = File.ReadAllText(@".\index.json");
            List<Response> response = JsonConvert.DeserializeObject<List<Response>>(json);

            return response;
        }
    }
}
