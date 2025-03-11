namespace TwixterR.Presentation.Extensions;

public static class AppRegistration
{
    public static WebApplication AddPresentationApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        //app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseExceptionHandler(_ => { });
        app.UseCors("AllowAll");
        app.MapControllers();
        app.Run();
        return app;
    }
}