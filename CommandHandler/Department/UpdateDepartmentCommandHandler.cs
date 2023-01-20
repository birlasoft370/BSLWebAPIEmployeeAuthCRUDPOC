using AutoMapper;
using DataEntity;
using DomainModel;
using MediatR;
using Repository;

namespace CommandHandler
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentRequest, UpdateDepartmentResponse>
    {
        private readonly IUpdateDepartment updateDepartment;
        private readonly IMapper mapper;

        public UpdateDepartmentCommandHandler(IUpdateDepartment updateDepartment, IMapper mapper)
        {
            this.updateDepartment = updateDepartment;
            this.mapper = mapper;
        }

        public async Task<UpdateDepartmentResponse> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var DepartmentDto = mapper.Map<DepartmentDTO>(request.DepartmentModel);
            await this.updateDepartment.ExecuteAsync(DepartmentDto).ConfigureAwait(false);

            return new UpdateDepartmentResponse()
            {
                DepartmentModel = request.DepartmentModel
            };
        }
    }

}
