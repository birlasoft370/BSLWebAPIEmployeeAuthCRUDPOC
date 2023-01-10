using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IuserOperation
    {
        public Task<UserModel> Validate(string username, string password);
    }
}
