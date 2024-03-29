﻿using CleanArch.Application.AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Handlers;
using CleanArch.Application.Services;
using CleanArch.Domain.Repositories;
using CleanArch.Domain.UnitOfWork;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Repositories;
using CleanArch.Infra.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlOpts =>
                {
                    sqlOpts.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                });
            });
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProductCommandHandler).Assembly));

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile).Assembly);

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IUnitOfWork, UoW>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
