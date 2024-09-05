using App.Services.ExceptionHandlers;
using Microsoft.AspNetCore.Diagnostics;

namespace CleanApp.API.ExceptionHandlers
{
    public class CriticalExceptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
            CancellationToken cancellationToken)
        {
            // business logic

            if (exception is CriticalException)
            {
                Console.WriteLine("hata ile ilgili sms gönderildi");
            }

            return ValueTask.FromResult(false);
        }
    }
}