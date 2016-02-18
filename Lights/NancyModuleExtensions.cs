using Nancy;
using System;
using System.Globalization;
using System.Linq;

public static class NancyModuleExtenstions
{

    public static void CheckForIfNonMatch(this NancyContext context)
    {
        var request = context.Request;
        var response = context.Response;

        string responseETag;
        if (!response.Headers.TryGetValue("ETag", out responseETag)) return;
        if (request.Headers.IfNoneMatch.Contains(responseETag))
        {
            context.Response = HttpStatusCode.NotModified;
        }
    }

    public static void CheckForIfModifiedSince(this NancyContext context)
    {
        var request = context.Request;
        var response = context.Response;

        string responseLastModified;
        if (!response.Headers.TryGetValue("Last-Modified", out responseLastModified)) return;
        DateTime lastModified;

        if (!request.Headers.IfModifiedSince.HasValue || !DateTime.TryParseExact(responseLastModified, "R", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastModified)) return;
        if (lastModified <= request.Headers.IfModifiedSince.Value)
        {
            context.Response = HttpStatusCode.NotModified;
        }
    }
}