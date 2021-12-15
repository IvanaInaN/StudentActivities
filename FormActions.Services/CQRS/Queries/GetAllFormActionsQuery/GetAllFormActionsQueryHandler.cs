using AutoMapper;
using FormActions.Domain.Models;
using FormActions.Domain.Repositories;
using FormActions.Services.CQRS.Queries.GetAllFormActionsQuery;
using FormActions.Structures.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ComplexApp.Services.CQRS.Queries.GetAllFormActionsQuery
{
    public class GetAllFormActionsQueryHandler : IRequestHandler<GetAllFormActionQueryRequest, List<FormActionDto>>
    {
        private readonly IFormActionRepository _formActionRepository;
        private readonly IMapper _mapper;

        public GetAllFormActionsQueryHandler(IFormActionRepository formActionRepository,
            IMapper mapper)
        {
            _formActionRepository = formActionRepository;
           _mapper = mapper;
        }

        public async Task<List<FormActionDto>> Handle(GetAllFormActionQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _formActionRepository.GetFormActionsAsync();

            var formActions = _mapper.Map<List<FormAction>, List<FormActionDto>>(result);

            return formActions;
        }
    }
}
