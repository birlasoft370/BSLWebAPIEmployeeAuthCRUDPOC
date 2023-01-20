using DataEntity;
using DomainModel.User;
using Newtonsoft.Json;
using Repository;
using RepositoryHandler.JsonFile.ModelDTO;

namespace RepositoryHandler.JsonFile
{
    public class UserjsonFileOperation : IUserOperation
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

        public async Task<UserDTO> Add(UserDTO User)
        {
            //  var json = await File.ReadAllTextAsync(jsonFile);
            string jSONString = string.Empty;
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();

                UserDTOJSonModel item = JsonConvert.DeserializeObject<UserDTOJSonModel>(json);
                User.Id = item.Users.Max(E => E.Id) + 1;

                User e = new User()
                {
                    Id = User.Id,
                    UserName = User.UserName,
                    Password = User.Password
                };

                item.Users.Add(e);


                jSONString = JsonConvert.SerializeObject(item, Formatting.Indented);
            }

            // await File.WriteAllTextAsync(jsonFile, newJsonResult);
            using (var streamWriter = File.CreateText(jsonFile))
            {
                streamWriter.Write(jSONString);
            }
            return await Task.FromResult(User);
        }

        public async Task DeleteUserByIdAsync(int UserId)
        {
            string jSONString = string.Empty;
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = await r.ReadToEndAsync();
                UserDTOJSonModel item = JsonConvert.DeserializeObject<UserDTOJSonModel>(json);
                var UserToDeleted = item.Users.FirstOrDefault(obj => obj.Id == UserId);

                item.Users.Remove(UserToDeleted);

                jSONString = JsonConvert.SerializeObject(item, Formatting.Indented);
            }

            using (var streamWriter = File.CreateText(jsonFile))
            {
                streamWriter.Write(jSONString);
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUser()
        {
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();
                UserDTOJSonModel item = JsonConvert.DeserializeObject<UserDTOJSonModel>(json);
                List<UserDTO> User = item.Users.Select(x => new UserDTO()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Password = x.Password
                }).OrderBy(x => x.Id).ToList();
                return await Task.FromResult(User);
            }
        }

        public async Task<UserDTO> GetUserById(int UserId)
        {
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();
                UserDTOJSonModel item = JsonConvert.DeserializeObject<UserDTOJSonModel>(json);
                UserDTO User = item.Users.Where(x => x.Id == UserId).Select(x => new UserDTO()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Password = x.Password
                }).FirstOrDefault();
                return await Task.FromResult(User);
            }
        }

        public async Task<UserDTO> Update(UserDTO UserChanges)
        {
            string jSONString = string.Empty;
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();

                UserDTOJSonModel item = JsonConvert.DeserializeObject<UserDTOJSonModel>(json);

                foreach (var User in item.Users.Where(obj => obj.Id == UserChanges.Id))
                {
                    User.UserName = UserChanges.UserName;
                    User.Password = UserChanges.Password;
                }

                jSONString = JsonConvert.SerializeObject(item, Formatting.Indented);
            }

            using (var streamWriter = File.CreateText(jsonFile))
            {
                streamWriter.Write(jSONString);
            }
            return await Task.FromResult(UserChanges);
        }
    }
}
