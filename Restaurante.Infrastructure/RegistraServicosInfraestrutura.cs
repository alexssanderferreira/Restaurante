﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurante.Infrastructure.Contratos;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositorio;

namespace Restaurante.Infrastructure
{
    public static class RegistraServicosInfraestrutura
    {
        public static IServiceCollection AddServicosInfraEstrutura(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestauranteContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IItemDoMenuRepository, ItemDoMenuRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<ICartaoRepository, CartaoRepository>();


            return services;
        }
    }
}
