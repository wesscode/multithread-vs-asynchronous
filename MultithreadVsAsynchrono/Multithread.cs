namespace MultithreadVsAsynchrono
{
    internal class Multithread
    {
        internal static void HardProcess(object id)
        {
            Console.WriteLine($"Thread {id} started.");
            Thread.Sleep(2000);  // Simulando trabalho pesado (cálculo, etc.)
            Console.WriteLine($"Thread {id} ended.");
        }

        /// <summary>
        /// - O que acontece aqui?
        ///   - Criamos 5 threads.
        ///   - Cada thread simula um trabalho pesado.
        ///   - As threads rodam em paralelo (se tiver núcleos disponíveis).
        ///   - A thread principal(execute) fica esperando.
        /// </summary>
        public static void Execute()
        {
            for (int i = 0; i < 5; i++)
            {
                var thread = new Thread(HardProcess!);
                thread.Start(i);
            }

            Console.WriteLine("Execute thread continuando...");
            Console.ReadLine();
        }

        /// <summary>
        /// - O que acontece aqui?
        ///    - Mesmo exemplo acima, porém a thead principal (ExecuteAndWait) fica agurdando.
        /// </summary>
        internal static void ExecuteAndWait()
        {
            Thread[] threads = new Thread[5];

            for (int i = 0; i < threads.Length; i++)
            {
                int id = i; // Para identificar a thread
                threads[i] = new Thread(() => HardProcess(id));
                threads[i].Start();
            }

            // Aguarda todas as threads concluírem
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine("Todas as threads foram concluídas!");
            Console.ReadLine();
        }
    }
}
