using AutoMapper;
using DataEntity;
using DomainModel;
using DomainModel.Department;
using MediatR;
using Repository;

namespace CommandHandler
{
    public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentRequest, AddDepartmentResponse>
    {
        private readonly IAddDepartment addDepartment;
        private readonly IMapper mapper;

        public AddDepartmentCommandHandler(IAddDepartment addDepartment, IMapper mapper)
        {
            this.addDepartment = addDepartment;
            this.mapper = mapper;
        }

        public async Task<AddDepartmentResponse> Handle(AddDepartmentRequest request, CancellationToken cancellationToken)
        {
            var DepartmentDto = mapper.Map<DepartmentDTO>(request.DepartmentModel);
            var result = await this.addDepartment.ExecuteAsync(DepartmentDto).ConfigureAwait(false);
            var entity = mapper.Map<DepartmentModel>(result);

            return new AddDepartmentResponse()
            {
                DepartmentModel = entity
            };
        }
    }
}
