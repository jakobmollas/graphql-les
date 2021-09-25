using graphql_les.Data;
using graphql_les.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace graphql_les
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AppDbContext>(o =>
                o.UseSqlServer(_configuration.GetConnectionString("DbConnection")));

            services
                .AddGraphQLServer()
                //.AddProjections() // not needed when only using explicit GraphQL/hotchocolate types since we set up projection logic manually there
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions()
                .AddQueryType<Query>()
                .AddType<PlatformType>()
                .AddType<CommandType>()
                .AddMutationType<Mutations>()
                .AddSubscriptionType<Subscriptions>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context => await context.Response.WriteAsync("Hello World!"));
                endpoints.MapGraphQL();
                endpoints.MapGraphQLVoyager("voyager");
            });
        }
    }
}
