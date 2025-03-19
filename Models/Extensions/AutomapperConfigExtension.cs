using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Models.Extensions
{
    public static class AutomapperConfigExtension
    {
        public static IServiceCollection AddAutomapperConfiguration(this IServiceCollection services)
        {
            services
              .AddScoped<IMapper, Mapper>()
              .AddSingleton<AutoMapper.IConfigurationProvider>(ctx =>
              {
                  var mapperConfig = new MapperConfiguration(cfg =>
                  {
                      var profiles = ctx.GetService<IEnumerable<Profile>>();
                      if (profiles != null)
                      {
                          foreach (var profile in profiles)
                          {
                              cfg.AddProfile(profile);
                          }
                      }
                  });
                  mapperConfig.AssertConfigurationIsValid(); // validate all dto's mapping;
                  return mapperConfig;
              })
              .AddSingleton<Profile, AutoMapperProfile>()
              ;
            return services;
        }
    }
}
