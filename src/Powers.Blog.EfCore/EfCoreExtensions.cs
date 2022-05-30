using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Powers.Blog.Core.Options;
using Powers.Blog.EfCore;
using System.Linq;
using System.Text;

namespace Powers.Blog.Apis.Extensions.EfCore;

/// <summary>
/// </summary>
public static class EfCoreExtensions
{
    /// <summary>
    /// 添加EfCore
    /// </summary>
    /// <param name="services"> </param>
    /// <returns> </returns>
    public static IServiceCollection AddEfCore(this IServiceCollection services)
    {
        IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>()!;
        var setting = configuration.GetSection("DbSettings").Get<DbSettings>()!.Settings.FirstOrDefault(x => x.IsEnable)!;

        services.AddDbContext<PowersBlogDbContext>(opts =>
        {
            switch (setting.Name)
            {
                case "Sqlite":
                    opts.UseSqlite(setting.ConnectionString, x =>
                    {
                        x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        //x.MigrationsAssembly("Powers.Blog.Shared");
                    });
                    break;

                //case "Npgsql":
                //    opts.UseNpgsql(setting.ConnectionString, x =>
                //    {
                //        x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                //        x.MigrationsAssembly("Powers.Blog.Shared");
                //    });
                //    break;

                //case "MySql":
                //    opts.UseMySql(ServerVersion.AutoDetect(setting.ConnectionString), x =>
                //    {
                //        x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                //        x.MigrationsAssembly("Powers.Blog.Shared");
                //    });
                //    break;

                case "SqlServer":
                default:
                    opts.UseSqlServer(setting.ConnectionString, x =>
                    {
                        x.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        //x.MigrationsAssembly("Powers.Blog.Shared");
                    });
                    break;
            }
        });

        return services;
    }
}