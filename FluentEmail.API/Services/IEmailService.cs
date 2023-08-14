using FluentEmail.API.DTOs;

namespace FluentEmail.API.Services
{
    public interface IEmailService
    {
        Task Send(EmailMetadata emailMetadata);
    }
}