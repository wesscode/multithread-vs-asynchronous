namespace MultithreadVsAsynchrono
{
    internal class Multithread
    {
        internal static void HardProcess(object id)
        {
            Console.WriteLine($"Thread {id} started.");
            Thread.Sleep(2000);  // simulating hard process (calc, process img, etc.)
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

            Console.WriteLine("Execute thread continue...");
            Console.ReadLine();
        }
    }
}
