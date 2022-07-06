
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Domain.Settings;
using Red_Social.Infrastructure.Shared.Services;

namespace Red_Social.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            services.AddTransient<IUploadFileService, UploadFileService>();
        }
    }
}
