using DataEntity;
using DomainModel;
using Newtonsoft.Json;
using Repository;
using RepositoryHandler.JsonFile.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryHandler.JsonFile
{
    public class UserjsonFileOperation : IuserOperation
    {
        string jsonFile = @"mydata/userData.json";
        public async Task<UserModel> Validate(string username, string password)
        {
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();

                UserDTOJSonModel item = JsonConvert.DeserializeObject<UserDTOJSonModel>(json);

                User user = item.Users.FirstOrDefault(x => x.UserName == username.Trim().ToLower() && x.Password == password.Trim().ToLower());

                if (user == null)
                {
                    return new UserModel() { Id = 0, UserName = "", Password = "" };
                };
                UserModel userModel = new UserModel() { Id = user.Id, UserName = user.UserName, Password = user.Password };

                return await Task.FromResult(userModel);
            }
        }
    }
}
