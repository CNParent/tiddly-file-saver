using System.Net.Mime;
using System.Text;

public class HtmlResult : IResult
{
    private readonly string _html;

    public HtmlResult(string html) => _html = html;

    public Task ExecuteAsync(HttpContext context)
    {
        context.Response.ContentType = MediaTypeNames.Text.Html;
        context.Response.ContentLength = Encoding.UTF8.GetByteCount(_html);
        return context.Response.WriteAsync(_html);
    }
}