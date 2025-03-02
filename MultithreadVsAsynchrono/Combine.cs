namespace MultithreadVsAsynchrono
{
    internal class Combine
    {
        private static void ProcessFile(string arquivo)
        {
            Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Processando {arquivo}...");
            Thread.Sleep(2000); // Simulando CPU-bound
            Console.WriteLine($"Conteúdo processado de {arquivo}");
        }

        private static async Task GetInfosAsync(string arquivo)
        {
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Buscando dados para {arquivo}...");
                string url = "https://jsonplaceholder.typicode.com/posts/1";  // API de exemplo
                var response = await client.GetStringAsync(url);
                Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Dados obtidos para {arquivo}: {response.Substring(0, 10)}...");
            }
        }

        private static async Task ProcessFilesAsync(string[] arquivos)
        {
            // Executa o processamento (CPU) em múltiplas threads
            var tarefasCpu = new Task[arquivos.Length];
            for (int i = 0; i < arquivos.Length; i++)
            {
                int index = i;
                tarefasCpu[i] = Task.Run(() => ProcessFile(arquivos[index]));
            }

            // Espera todos os processamentos de CPU terminarem
            await Task.WhenAll(tarefasCpu);

            // Agora faz consultas externas (I/O) de forma assíncrona para cada arquivo processado
            var tarefasIo = new Task[arquivos.Length];
            for (int i = 0; i < arquivos.Length; i++)
            {
                string arquivo = arquivos[i];
                tarefasIo[i] = GetInfosAsync(arquivo);
            }

            // Aguarda todas as tarefas I/O concluírem
            await Task.WhenAll(tarefasIo);

            Console.WriteLine("Todos os arquivos foram processados e dados externos buscados.");
        }

        internal static async Task Execute()
        {
            string[] arquivos = { "arquivo1.txt", "arquivo2.txt", "arquivo3.txt" };

            await ProcessFilesAsync(arquivos);

            Console.WriteLine("Processo finalizado.");
        }
    }
}
