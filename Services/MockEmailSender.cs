using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

public class MockEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Log email sending for debugging (mock email sender)
        Console.WriteLine($"Mock Email Sent to {email}: {subject}");
        return Task.CompletedTask;
    }
}