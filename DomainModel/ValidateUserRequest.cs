﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class ValidateUserRequest :IRequest<ValidateUserResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
