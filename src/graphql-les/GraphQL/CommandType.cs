using graphql_les.Data;
using graphql_les.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace graphql_les.GraphQL
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("A command-line action provided by a platform.");
            
            descriptor
                .Field(n => n.Platform)
                .ResolveWith<Resolvers>(n => n.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("The platform provding this command.");
        }

        private class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext context) 
                => context.Platforms.FirstOrDefault(n => n.Id == command.PlatformId);
        }
    }
}
