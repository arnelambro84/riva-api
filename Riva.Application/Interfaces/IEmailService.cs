using Riva.Application.DTOs.Email;
using System.Threading.Tasks;

namespace Riva.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}