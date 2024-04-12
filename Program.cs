using System.Security.Cryptography;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddCommandLine(args);

var settings = builder.Configuration.Get<AppSettings>();

var app = builder.Build();
app.UseHttpsRedirection();

var fileInfo = new FileInfo(settings.FilePath);

var getInfo = () => 
{
    var content = File.ReadAllBytes(settings.FilePath);
    return new[]
    {
        new FileSaverInfo 
        {
            Name = fileInfo.Name,
            Path = fileInfo.Name,
            Sha256 = Convert.ToBase64String(SHA256.HashData(content)),
            Size = fileInfo.Length,
            Url = settings.RequestPath
        }
    };
};

app.MapGet("", () => {
    var content = File.ReadAllText(settings.FilePath);
    return new HtmlResult(content);
});

app.MapGet(settings.RequestPath, getInfo);

var putUrl = $"{settings.RequestPath}/{fileInfo.Name}";
app.MapPut(putUrl, ([FromBody]FileSaverPut model) => {
    var html = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(model.Content));
    File.WriteAllText(settings.FilePath, html);
    return getInfo();
});

Console.WriteLine($"Put URL: {putUrl}");
app.Run();
