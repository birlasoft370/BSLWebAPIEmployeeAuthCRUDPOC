﻿using DataEntity;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IValidateUser
    {
        public Task<UserModel> Validate(string username, string password);
    }
}
