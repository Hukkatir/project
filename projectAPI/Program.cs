using Domian.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using BusinessLogic.Services;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Domain.Interfaces;

namespace projectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<projectDBContext>(
                options => options.UseSqlServer(builder.Configuration["ConnectionString"]));
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ICommentRateService, CommentRateService>();

            builder.Services.AddScoped<IContentService, ContentService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IMediaFileService, MediaFileService>();

            builder.Services.AddScoped<IMediumService, MediumService>();
            builder.Services.AddScoped<IMessagesUserService, MessagesUserService>();
            builder.Services.AddScoped<IMyRatingService, MyRatingService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IPaymentUserService, PaymentUserService>();
            builder.Services.AddScoped<IRoomService, RoomService>();

            builder.Services.AddScoped<IRoomsUserService, RoomsUserService>();
            builder.Services.AddScoped<IGroupMediumService, GroupMediumService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API",
                    Description = "Что-то",
                    Contact = new OpenApiContact
                    {
                        Name = "Лучшая версия меня",
                        Url = new Uri("https://www.kinopoisk.ru/")
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            app.UseCors(builder => builder.WithOrigins(new[] { "https://project-kxd1.onrender.com", })
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin());

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<projectDBContext>();

                context.Database.Migrate();
                context.Database.EnsureCreated();

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Role { RoleName = "Admin" },
                        new Role { RoleName = "User" }
                    );
                    context.SaveChanges();
                }

                if (!context.Genres.Any())
                {
                    context.Genres.AddRange(
                        new Genre { GenreName = "Боевик" },
                        new Genre { GenreName = "Комедия" },
                        new Genre { GenreName = "Драма" },
                        new Genre { GenreName = "Фантастика" },
                        new Genre { GenreName = "Фэнтези" },
                        new Genre { GenreName = "Ужасы" },
                        new Genre { GenreName = "Триллер" },
                        new Genre { GenreName = "Мелодрама" },
                        new Genre { GenreName = "Приключения" },
                        new Genre { GenreName = "Анимация" },
                        new Genre { GenreName = "Детектив" },
                        new Genre { GenreName = "Исторический" },
                        new Genre { GenreName = "Военный" },
                        new Genre { GenreName = "Музыкальный" },
                        new Genre { GenreName = "Семейный" },
                        new Genre { GenreName = "Спорт" },
                        new Genre { GenreName = "Документальный" },
                        new Genre { GenreName = "Криминал" },
                        new Genre { GenreName = "Биография" },
                        new Genre { GenreName = "Вестерн" },
                        new Genre { GenreName = "Нуар" },
                        new Genre { GenreName = "Мистика" },
                        new Genre { GenreName = "Артхаус" },
                        new Genre { GenreName = "Короткометражка" },
                        new Genre { GenreName = "Аниме" }
                    );
                    context.SaveChanges();
                }

                if (!context.MediaTypes.Any())
                {
                    context.MediaTypes.AddRange(
                        new MediaType { MediaTypeName = "Фильм" },
                        new MediaType { MediaTypeName = "Сериал" },
                        new MediaType { MediaTypeName = "Мультфильм" },
                        new MediaType { MediaTypeName = "Аниме" },
                        new MediaType { MediaTypeName = "Документальный фильм" },
                        new MediaType { MediaTypeName = "ТВ-шоу" },
                        new MediaType { MediaTypeName = "Короткометражный фильм" },
                        new MediaType { MediaTypeName = "Трейлер" },
                        new MediaType { MediaTypeName = "Видеоклип" },
                        new MediaType { MediaTypeName = "Обзор" }
                    );
                    context.SaveChanges();
                }

                if (!context.CategoryContents.Any())
                {
                    context.CategoryContents.AddRange(
                        new CategoryContent { CategoryName = "Новости" },
                        new CategoryContent { CategoryName = "Рецензии" },
                        new CategoryContent { CategoryName = "Интервью" },
                        new CategoryContent { CategoryName = "Аналитика" },
                        new CategoryContent { CategoryName = "Топ-листы" },
                        new CategoryContent { CategoryName = "Закулисье" },
                        new CategoryContent { CategoryName = "Рекомендации" },
                        new CategoryContent { CategoryName = "Истории создания" },
                        new CategoryContent { CategoryName = "Фан-теории" },
                        new CategoryContent { CategoryName = "Сравнения" }
                    );
                    context.SaveChanges();
                }

                if (!context.CategoryFiles.Any())
                {
                    context.ChangeTracker.Clear();
                    var existingFiles = context.CategoryFiles.AsNoTracking().ToList();
                    context.CategoryFiles.RemoveRange(existingFiles);
                    context.SaveChanges();

                    context.CategoryFiles.AddRange(
                        new CategoryFile { CategoryFileName = "Трейлер" },
                        new CategoryFile { CategoryFileName = "Постер" },
                        new CategoryFile { CategoryFileName = "Скриншоты" },
                        new CategoryFile { CategoryFileName = "Фан-арт" },
                        new CategoryFile { CategoryFileName = "Заставка" },
                        new CategoryFile { CategoryFileName = "Логотип" },
                        new CategoryFile { CategoryFileName = "Кадры из фильма" },
                        new CategoryFile { CategoryFileName = "Закулисье" },
                        new CategoryFile { CategoryFileName = "Интервью" },
                        new CategoryFile { CategoryFileName = "Концепт-арт" }
                    );
                    context.SaveChanges();
                }

                if (!context.StatusMessages.Any())
                {
                    context.StatusMessages.AddRange(
                        new StatusMessage { StatusMessageName = "Отправлено" },
                        new StatusMessage { StatusMessageName = "Доставлено" },
                        new StatusMessage { StatusMessageName = "Прочитано" },
                        new StatusMessage { StatusMessageName = "Удалено" }
                    );
                    context.SaveChanges();
                }
            }


            /*  if (app.Environment.IsDevelopment()) */
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}