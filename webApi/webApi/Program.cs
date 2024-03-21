var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
using var client = new HttpClient();

List<Produto> produtos = 
[  
    new Produto("Celular", "IOS"),
    new Produto("Celular", "IOS"),
    new Produto("Celular", "IOS"),
    new Produto("Celular", "IOS")
];

app.MapGet("/", () => "Hello World!");

app.MapGet("/disgraca", () => produtos);

app.MapPost("/cadastro", () => produtos);

// app.MapGet("/viacep/{cep}", async (HttpContext context) => {
//         try
//         {
//             var cep = context.Request.RouteValues["cep"];
//             var response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
//             var content = await response.Content.ReadAsStringAsync();
//             return content; 
//         }
//         catch (Exception)
//         {
//             throw new Exception("sabe deus oq deu rapa");
//         }
        
    
// });

app.Run();


record Produto(string nome, string desc);