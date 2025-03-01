using System.Text.Json;

namespace MultithreadVsAsynchrono
{
    internal class Asynchrono
    {
        internal static async Task GetDataAsync(string url)
        {
            Console.WriteLine($"Iniciando requisição para {url}");
            var response = await SimulatoGetStringAsync(url);  // Aqui a thread pode liberar            
            Console.WriteLine("");
            Console.WriteLine($"Resposta de {url}: {response}");
        }

        static async Task<string> SimulatoGetStringAsync(string url)
        {
            // Aqui você simula a resposta, como se tivesse vindo da API.
            await Task.Delay(5000);
            var fakeResponse = JsonSerializer.Serialize(new { Post = $"Dado: {url.Split('/')[4]}" });            
            return await Task.FromResult(fakeResponse);
        }

        /// <summary>
        /// O que acontece aqui?
        ///  - Processamento operações I/O assíncronas
        ///  - Simulamos 3 requests a uma api
        ///  - No await a thread é liberada automaticamente e parte para próximo request
        ///  - Por fim aguardamos a finalização de todas as tarefas.
        /// </summary>        
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

            Console.WriteLine("");
            Console.WriteLine("Todas as requisições concluídas.");
        }
    }
}
