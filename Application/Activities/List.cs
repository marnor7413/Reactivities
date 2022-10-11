using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<ActivityDto>>> {}

        public class Handler : IRequestHandler<Query, Result<List<ActivityDto>>>
        {
            private readonly DataContext _context;
        private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<ActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                //// this creates circular reference 
                // var activities = await _context.Activities
                //     .Include(a => a.Attendees)
                //     .ThenInclude(u => u.AppUser)
                //     .ToListAsync(cancellationToken);

                // // create and return a DTO instead to resolve this
                // var activitiesToReturn = _mapper.Map<List<ActivityDto>>(activities);


                // alternative solution using projection with help of Automapper .ProjectTo<> that comes from Automapper.QueryableExtensions
                // above solution creates a large query that includes props from the User-table which is unncessary whilst this solution creates a slimmer query
                var activities = await _context.Activities
                    .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                    
                return Result<List<ActivityDto>>.Success(activities);
            }
        }
    }
}