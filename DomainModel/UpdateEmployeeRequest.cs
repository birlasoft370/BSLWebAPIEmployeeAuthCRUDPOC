using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class UpdateEmployeeRequest : IRequest<UpdateEmployeeResponse>
    {
        public UpdateEmployeeRequest()
        {
            EmployeeModel = new();
        }

        public EmployeeModel EmployeeModel { get; set; }

    }
}
