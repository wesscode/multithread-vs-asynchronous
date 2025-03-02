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
            var resultados = await Task.WhenAll(tarefasCpu);

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
