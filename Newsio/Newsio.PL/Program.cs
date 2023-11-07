using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newsio.BLL;
using Newsio.BLL.Interfaces.Services;
using Newsio.BLL.Services;
using Newsio.DAL.EF;
using Newsio.DAL.Interfaces;
using Newsio.DAL.Interfaces.Repositories;
using Newsio.DAL.Repositories;
using Newsio.PL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITagRepository, TagRepository>();
builder.Services.AddTransient<INewsTagRepository, NewsTagRepository>();
builder.Services.AddTransient<INewsRepository, NewsRepository>();
builder.Services.AddTransient<ISectionRepository, SectionRepository>();

builder.Services.AddTransient<IUnitOfWork, EFUnitOfWork>();

builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<ITagService, TagService>();
builder.Services.AddTransient<INewsTagService, NewsTagService>();
builder.Services.AddTransient<INewsService, NewsService>();
builder.Services.AddTransient<ISectionService, SectionService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(build =>
    {
        build.AllowAnyOrigin().
        AllowAnyMethod().
        AllowAnyHeader();
    });
});

var connectionString = builder.Configuration.GetConnectionString("NewsDb");
builder.Services.AddDbContext<NewsContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddTransient<NewsContext>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutomapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.ApplyMigrations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();