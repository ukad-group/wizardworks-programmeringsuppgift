using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text;

namespace Wizardworks.Demo.Core.Infrastructure.Extensions;
public static class CookiesExtensions
{
    private const string user_id_key = "user_id";
    public static string GetCurrentUserId(this HttpRequest request)
    {
        if (request.Headers.TryGetValue(user_id_key, out var userIdValue) is false
            || string.IsNullOrWhiteSpace(userIdValue))
        {
            throw new UnauthorizedAccessException();
        }

        return userIdValue!;
    }
}
