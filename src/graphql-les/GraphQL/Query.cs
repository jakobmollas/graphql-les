using graphql_les.Data;
using graphql_les.Models;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace graphql_les.GraphQL
{
    
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommands([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}
