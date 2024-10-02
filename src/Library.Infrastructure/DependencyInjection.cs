using Library.Application.Common.Interfaces;
using Library.Infrastructure.Common.Persistence;
using Library.Infrastructure.Repositories.Authors.Persistence;
using Library.Infrastructure.Repositories.Books.Persistence;
using Library.Infrastructure.Repositories.Genres.Persistence;
using Library.Infrastructure.Repositories.TakenBooks.Persistence;
using Library.Infrastructure.Repositories.Users.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<LibraryDbContext>(options => options.UseSqlite("Data Source = Library.db"));
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITakenBooksRepository, TakenBooksRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<LibraryDbContext>());
        return services;
    }
}