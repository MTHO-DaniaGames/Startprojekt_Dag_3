# Bogkatalog · dag 3 · Startprojekt

## Før du starter
Visual Studio med workloaden **ASP.NET and web development** og .NET 10 SDK. Docker kræves ikke i dag.
Åbn Bogkatalog.slnx. Start Bogkatalog.Api med http-profilen og Ctrl+F5. Kontrollér http://localhost:5200/health og /api/books.
Start derefter Bogkatalog.Web separat, mens API'et fortsat kører. Web bruger http://localhost:5100. Du kan vælge et andet Startup Project og bruge Ctrl+F5 igen eller åbne løsningen i et ekstra Visual Studio-vindue. Kør kun én kopi af hvert projekt.

Fra solution-mappen kan de også startes i hver sin terminal:
```powershell
dotnet run --project src/Bogkatalog.Api --launch-profile http
```
```powershell
dotnet run --project src/Bogkatalog.Web --launch-profile http
```
Læs altid Now listening on i konsollen. / på API'et giver 404. .http-filens baseUrl skal matche API-adressen.

## Fra dag 2 til dag 3
Alle bog-endpoints, title-filteret, /health og /about fra dag 2 er færdige. API'et bruger stadig hukommelse, ikke database.
Der er intet projekt-referenceforhold mellem Web og API. BookInput i Web beskriver det JSON-input, API'et accepterer.
Startdata nulstilles til Hobbitten og Frankenstein ved genstart af API'et.

## Dagens arbejde
Startprojektets Web viser først den lokale dag 2-app. BookApiClient har to TODO-metoder.
Grøn A: registrér named HttpClient og BookApiClient, og implementér GET. Grøn B: tilslut den forberedte side og test hentning samt genhentning. Grøn C: implementér POST og håndtering af 400.
Skabeloner/Home.razor.txt indeholder den forberedte side. Kopiér indholdet over i src/Bogkatalog.Web/Components/Pages/Home.razor på det tidspunkt, slides angiver. .txt-filer kompileres ikke.
Siden forudsætter også BookValidationException og ValidationResponse. De findes nederst i Skabeloner/BookApiClient-faerdig.cs.txt. Tilføj disse hjælpeklasser ved Grøn A. AddAsync kan midlertidigt beholde sin TODO, mens GET afprøves. Brug først formularen efter Grøn C.
Hjælp og løsninger står sidst i PowerPoint. Skabelonerne gør det muligt at sammenligne med den samlede kode. Øvelserne skal ikke afleveres.
Dette repo indeholder startprojektet og de skabeloner, der bruges i øvelserne. Den komplette løsningsversion er ikke nødvendig for at gennemføre dagen.

## Kontrol
API giver 200 og en JSON-liste på /api/books. Den færdige Web-version viser samme liste, opretter en bog via POST og kan hente den igen. En anden browser ser bogen efter Hent igen, ikke automatisk. Genstart af Web bevarer API-data. Genstart af API nulstiller dem.
Stop API og vælg Hent igen: siden skal vise en fejl og stadig fungere. Start API igen og vælg Hent igen: listen kommer tilbage.

API-adressen står i Web/appsettings.json under BooksApi:BaseUrl. Brug afsluttende / og relative paths uden indledende /. Den nuværende timeout er 5 sekunder. Der er ingen automatisk retry af POST.

## Test af API-validation gennem Web
Når POST virker, kan API-fejlhåndteringen testes uden at blive stoppet af formularens lokale validation:
I Home.razor/SaveAsync erstattes draft.Title midlertidigt med " " i new BookInput(...).
Udfyld formularen med gyldige værdier, og send. API'et skal afvise den faktiske request med 400. Web viser fejlbeskeden, og formularens værdier bevares.
Gendan draft.Title, og test en gyldig oprettelse igen.

## Gule udvidelser
Udvidelser.cs.txt indeholder DELETE- og PUT-metoder til BookApiClient. I startprojektet ligger filen i Skabeloner.
Metoderne og UI-udvidelserne er valgfrie. Kerneprojektets færdige brugergrænseflade indeholder GET og POST.
