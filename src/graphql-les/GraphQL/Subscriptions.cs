using graphql_les.Models;
using HotChocolate;
using HotChocolate.Types;

namespace graphql_les.GraphQL
{
    public class Subscriptions
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;

        [Subscribe]
        [Topic]
        public Command OnCommandAdded([EventMessage] Command command) => command;
    }
}
