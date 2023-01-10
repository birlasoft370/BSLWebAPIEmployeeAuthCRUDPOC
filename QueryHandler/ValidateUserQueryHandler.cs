using AutoMapper;
using DomainModel;
using MediatR;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryHandler
{
    public class ValidateUserQueryHandler : IRequestHandler<ValidateUserRequest, ValidateUserResponse>
    {
        private readonly IValidateUser validateUser;
        private readonly IMapper mapper;

        public ValidateUserQueryHandler(IValidateUser validateUser, IMapper mapper)
        {
            this.validateUser = validateUser;
            this.mapper = mapper;
        }

        public async Task<ValidateUserResponse> Handle(ValidateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await this.validateUser.Validate(request.UserName, request.Password).ConfigureAwait(false);
            var userModel = new ValidateUserResponse() { User = user };
            return userModel;
        }
    }
}
