using graphql_les.Data;
using graphql_les.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace graphql_les.GraphQL
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Any software or service that has a command-line interface.");
            
            descriptor.Ignore(n => n.LicensKey);

            descriptor
                .Field(n => n.Commands)
                .ResolveWith<Resolvers>(n => n.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("All commands offered by this platform");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context) 
                => context.Commands.Where(n => n.PlatformId == platform.Id);
        }
    }
}
