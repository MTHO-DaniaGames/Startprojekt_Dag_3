using Bogkatalog.Web.Models;
namespace Bogkatalog.Web.Services;

// Udfyld klassen efter slides. Registrér den som en service i Web/Program.cs.
public class BookApiClient(IHttpClientFactory factory)
{
    public Task<List<Book>> GetAllAsync()
    {
        using var http = factory.CreateClient("Books");
        throw new NotImplementedException("Grøn A: Skriv GET-kaldet her.");
    }

    public Task<Book> AddAsync(BookInput input)
    {
        throw new NotImplementedException("Grøn C: Skriv POST-kaldet her.");
    }
}

