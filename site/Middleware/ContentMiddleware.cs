using SITE.ITEGAMAX._4._0._2.Services;

namespace SITE.ITEGAMAX._4._0._2.Middleware
{
    public class ContentMiddleware
    {
        private readonly RequestDelegate _next;

        public ContentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IContentService contentService)
        {
            string path = context.Request.Path;
            var pageContent = contentService.GetSitePageData(path);

            if (pageContent != null)
            {
                 context.Items["PageContent"] = pageContent;
            }

            await _next(context);
        }
    }

}
