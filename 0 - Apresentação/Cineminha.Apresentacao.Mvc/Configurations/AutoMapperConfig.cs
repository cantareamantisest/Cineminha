﻿using Cineminha.Aplicacao.AutoMapper;

namespace Cineminha.Apresentacao.Mvc.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}