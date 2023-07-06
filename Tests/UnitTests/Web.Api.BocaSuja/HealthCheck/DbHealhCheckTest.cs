﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Web.Api.BocaSuja.Context;
using Web.Api.BocaSuja.HealthCheck;

namespace Tests.UnitTests.Web.Api.BocaSuja.HealthCheck;

[TestFixture]
public class DbHealhCheckTest
{

    [Test, Category("WebApi - Health - DbHealthCheck")]
    [Description("Verifica se o teste de saúde do banco de dados está ocorrendo normalmente")]
    public void Check_HealthyDb()
    {
        var serviceProvider = CriarServiceProviderSaudavel();

        bool result = DbHealthCheck.Check(serviceProvider);

        Assert.That(actual: result, Is.True);
    }

    private IServiceProvider CriarServiceProviderSaudavel()
    {
        var services = new ServiceCollection();

        services.AddDbContext<BocaSujaDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "DbTeste"));

        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider;
    }

}