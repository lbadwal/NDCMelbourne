using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CaWorkshop.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists
{
    public class GetTodoListsQuery : IRequest<TodosVm>
    {
    }

    public class GetTodoListsQueryHandler
        : IRequestHandler<GetTodoListsQuery, TodosVm>
    {
        private readonly IApplicationDbContext _context;

        public GetTodoListsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodosVm> Handle(
            GetTodoListsQuery request,
            CancellationToken cancellationToken)
        {
            var vm = new TodosVm
            {
                Lists = await _context.TodoLists
                    .Select(TodoListDto.Projection)
                    .ToListAsync(cancellationToken)
            };
            return vm;
        }
    }
}