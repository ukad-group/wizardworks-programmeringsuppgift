using Microsoft.AspNetCore.Http;
using System.Text;

namespace Wizardworks.Demo.Core.Infrastructure.Extensions;
public static class SessionExtensions
{
    private const string session_id_key = "sessionId";
    public static string GetCurrentSessionId(this ISession session)
    {
        var sessionId = session.GetString(session_id_key);
        if (string.IsNullOrWhiteSpace(sessionId))
        {
            sessionId = Guid.NewGuid().ToString();
            session.SetString(session_id_key, sessionId);
        }
        return sessionId;
    }
}
