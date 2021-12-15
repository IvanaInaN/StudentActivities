using FormActions.Structures.Dtos;
using MediatR;
using System.Collections.Generic;

namespace FormActions.Services.CQRS.Queries.GetAllFormActionsQuery
{
    public class GetAllFormActionQueryRequest : IRequest<List<FormActionDto>>
    {
    }
}
