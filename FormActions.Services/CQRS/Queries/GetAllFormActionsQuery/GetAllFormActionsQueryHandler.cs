using AutoMapper;
using FormActions.Domain.Models;
using FormActions.Domain.Repositories;
using FormActions.Structures.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FormActions.Services.CQRS.Queries.GetAllFormActionsQuery
{
    public class GetAllFormActionsQueryHandler : IRequestHandler<GetAllFormActionQueryRequest, List<FormActionDto>>
    {
        public GetAllFormActionsQueryHandler() { }

        public Task<List<FormActionDto>> Handle(GetAllFormActionQueryRequest request, CancellationToken cancellationToken)
        {
            var result = new List<FormActionDto>()
            {
                new FormActionDto()
            };
            return Task.FromResult(result);
        }
    }
}
