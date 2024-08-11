using StarKindred.API.Database.Models;
using Microsoft.AspNetCore.Mvc;
using StarKindred.API.Entities;
using StarKindred.API.Services;
using StarKindred.API.Database;

namespace StarKindred.API.Endpoints.Accounts;

[ApiController, Tags("Accounts")]
public sealed class RenewSession
{
    [HttpPost("/accounts/renewSession")]
    public async Task<ApiResponse<Response>> _(
        [FromServices] Db db, [FromServices] ICurrentUser currentUser, CancellationToken cToken
    )
    {
        var session = await currentUser.GetSessionOrThrow(cToken);

        var newSession = new UserSession()
        {
            UserId = session.UserId,
            ExpiresOn = DateTimeOffset.UtcNow.AddDays(3)
        };

        await currentUser.ClearSessionOrThrow(cToken);

        db.UserSessions.Add(newSession);

        await db.SaveChangesAsync(cToken);

        return new(new(newSession.Id));
    }

    public sealed record Response(Guid SessionId);
}