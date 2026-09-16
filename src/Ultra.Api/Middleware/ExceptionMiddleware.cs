namespace Ultra.Api.Middleware;

public class ExceptionMiddleware
{
    private RequestDelegate _request; 
    private ILogger<ExceptionMiddleware> _logger;
    public ExceptionMiddleware(RequestDelegate request, ILogger<ExceptionMiddleware> logger)
    {
        _request = request;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    { 
        try
        {
            await _request(context);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex,"Unhandled exception");
            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new
                {
                    message = "Internal server error"
                });
            }
        }
    }
}