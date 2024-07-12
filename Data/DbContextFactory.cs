using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Data;

public class DbContextFactory(IHttpContextAccessor httpContextAccessor)
{
    public StoreDbContext Create(Type repositoryType)
    {
        var services = httpContextAccessor.HttpContext.RequestServices;
        var dbContexts = services.GetService<Dictionary<Type, StoreDbContext>>();
        
        if (!dbContexts.ContainsKey(repositoryType))
            dbContexts[repositoryType] = services.GetService<StoreDbContext>();

        return dbContexts[repositoryType];
    }
}