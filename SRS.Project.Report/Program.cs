using Stimulsoft.Base;
using static Stimulsoft.Report.StiOptions;


try
{
    string licens = System.IO.File.ReadAllText("wwwroot/keylicense/license.key");
    Stimulsoft.Base.StiLicense.Key = licens;

}
catch (Exception ex)
{
    Console.WriteLine("Run without license!!!");

}


foreach (string f in Directory.EnumerateFiles("wwwroot/fonts/", "*.ttf", SearchOption.AllDirectories))
{
    StiFontCollection.AddFontFile(f);
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
//builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    //endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=DesignTemplate}/{action=Reports}/{id?}");
});

app.Run();
