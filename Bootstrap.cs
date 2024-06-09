using Microsoft.Extensions.Options;
using TextPlus_BE.Converters;
using TextPlus_BE.Helper.Security;
using TextPlus_BE.Interfaces;
using TextPlus_BE.Repository;
using TextPlus_BE.Repository.RepoService;
using TextPlus_BE.Setting;

namespace TextPlus_BE
{
    public class Bootstrap
    {
        private readonly IServiceCollection _service;
        private readonly IConfiguration _configuration;
        public Bootstrap(IServiceCollection services, IConfiguration configuration)
        {
            _service = services;
            _configuration = configuration;
        }


        public void InitDependencies()
        {

            _service.Configure<DbSettings>(_configuration.GetSection(nameof(DbSettings)));
            _service.AddSingleton<IDbSettings>(d => d.GetRequiredService<IOptions<DbSettings>>().Value);

            _service.Configure<JwtSettings>(_configuration.GetSection(nameof(JwtSettings)));
            _service.AddSingleton<IJwtSettings>(d => d.GetRequiredService<IOptions<JwtSettings>>().Value);


            // _service.AddScoped<IAuthorizationContext, AuthorizationContext>();

            _service.AddScoped<IConversationRepository, ConversationRepository>();
            _service.AddScoped<ILoginRepository, LoginRepository>();
            _service.AddScoped<IMessageRepository, MessageRepository>();
            _service.AddScoped<IUserRepository, UserRepository>();
            _service.AddScoped<IConversationService, ConversationService>();
            _service.AddScoped<IJwtProvider, JwtProvider>();

            _service.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new ObjectIdConverter());
            });

            // _service.AddCors(options =>
            // {
            //     options.AddPolicy("AllowClientOrigin", builder =>
            //     {
            //         //builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().Build();
            //         builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().Build();
            //     });
            // });
        }

    }
}


