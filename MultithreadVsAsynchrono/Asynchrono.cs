using System.Text.Json;

namespace MultithreadVsAsynchrono
{
    internal class Asynchrono
    {
        internal static async Task GetDataAsync(string url)
        {
            Console.WriteLine($"Iniciando requisição para {url}");
            var response = await SimularGetStringAsync(url);  // Aqui a thread pode liberar            
            Console.WriteLine($"Resposta de {url}: {response}");
            Console.WriteLine("");
        }

        static Task<string> SimularGetStringAsync(string url)
        {
            // Aqui você simula a resposta, como se tivesse vindo da API.
            var fakeResponse = JsonSerializer.Serialize(new { Post = $"Dado: {url.Split('/')[4]}" });

            // Retorna como se fosse uma Task, igual GetStringAsync faz
            return Task.FromResult(fakeResponse);
        }

        internal static async Task Execute()
        {
            var urls = new string[]
            {
                "https://json1.com/posts/1",
                "https://json2.com/posts/2",
                "https://json3.com/posts/3"
            };

            var tarefas = new Task[urls.Length];

            for (int i = 0; i < urls.Length; i++)
            {
                tarefas[i] = GetDataAsync(urls[i]);
            }

            await Task.WhenAll(tarefas);  // Aguarda todas completarem

            Console.WriteLine("Todas as requisições concluídas.");
        }
    }
}
