using graphql_les.Data;
using graphql_les.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using System.Threading;
using System.Threading.Tasks;

namespace graphql_les.GraphQL
{
    public class Mutations
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformResult> AddPlatformAsync(AddPlatformInput input, [ScopedService] AppDbContext context, [Service] ITopicEventSender eventSender, CancellationToken cs)
        {
            var platform = new Platform
            {
                Name = input.name
            };

            context.Platforms.Add(platform);
            await context.SaveChangesAsync(cs);

            await eventSender.SendAsync(nameof(Subscriptions.OnPlatformAdded), platform, cs);

            return new AddPlatformResult(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandResult> AddCommandAsync(AddCommandInput input, [ScopedService] AppDbContext context, [Service] ITopicEventSender eventSender, CancellationToken cs)
        {
            input.Deconstruct(out var howTo, out var commandLine, out var platformId);

            var command = new Command
            {
                HowTo = howTo,
                CommandLine = commandLine,
                PlatformId = platformId
            };

            context.Commands.Add(command);
            await context.SaveChangesAsync(cs);

            await eventSender.SendAsync(nameof(Subscriptions.OnCommandAdded), command, cs);

            return new AddCommandResult(command);
        }
    }

    public record AddPlatformInput(string name);
    public record AddPlatformResult(Platform platform);

    public record AddCommandInput(string howTo, string commandLine, int platformId);
    public record AddCommandResult(Command command);
}
