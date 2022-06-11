using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace Entities
{
    //Have some trouble with dependency injection. its does not work

    //public static class MigrationManager
    //{
        
    //    public static WebApplication MigrateDatabase(this WebApplication webApp)
    //    {
    //        using (var scope = webApp.Services.CreateScope())
    //        {
    //            using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>())
    //            {
    //                try
    //                {
    //                    appContext.Database.Migrate();
    //                }
    //                catch (Exception ex)
    //                {
    //                    //Log errors or do anything you think it's needed
    //                    throw;
    //                }
    //            }
    //        }
    //        return webApp;
    //    }
    //}
}
