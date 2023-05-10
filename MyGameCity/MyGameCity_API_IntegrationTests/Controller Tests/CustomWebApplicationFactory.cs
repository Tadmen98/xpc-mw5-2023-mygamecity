using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.IntegrationTests.Controller_Tests
{
    internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
       public Mock<DbContext> DatabaseMock { get;}

        public CustomWebApplicationFactory()
        {
            DatabaseMock = new Mock<DbContext>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureTestServices(Services =>
            {
                Services.AddSingleton(DatabaseMock.Object);
            });
        }
    }
}
