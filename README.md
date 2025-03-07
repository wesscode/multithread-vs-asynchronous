# Multithread Vs Assincrono

## Processamento Multithread
  - Multithread significa rodar várias threads (linhas de execução) em paralelo dentro de um mesmo processo.
  - Cada thread compartilha o mesmo espaço de memória, mas pode executar partes diferentes do código ao mesmo tempo.
  - Útil quando você tem tarefas CPU-bound (tarefas pesadas que consomem muito processamento, como cálculos complexos ou manipulação de imagens).
  - Exemplo: Um editor de vídeo que processa diferentes partes do vídeo em threads separadas para acelerar a exportação.

**✅ Características:**
  - Várias threads competem pelos mesmos recursos (memória, CPU).
  - Comunicação entre threads pode ser complexa (lock, semáforos, etc.).
  - Paralelismo real (se o hardware tiver múltiplos núcleos).


## Processamento Assíncrono
  - Assíncrono é mais sobre coordenação eficiente de I/O (entrada e saída).
  - Enquanto uma tarefa aguarda uma resposta (como leitura de arquivo, resposta de uma API ou acesso a banco de dados), o programa pode continuar executando outras tarefas.
  - Muito comum em aplicações de rede, web servers e apps que precisam lidar com várias requisições simultâneas.
  - Usa event loop e futuras/promessas para agendar tarefas sem bloquear a execução.

**✅ Características:**
  - Ideal para tarefas I/O-bound (como esperar resposta de API ou consultar banco).
  - Não necessariamente envolve múltiplos núcleos.
  - Tende a ser mais leve que multithreading porque evita criar várias threads.

## Comparativo
<table>
  <thead>
    <tr>
      <th>Aspecto</th>
      <th>Multithead</th>
      <th>Assíncrono</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Tipo de tarefa</td>
      <td>CPU-bound (cálculos)</td>
      <td>I/O-bound (esperar resposta de rede, banco)</td>      
    </tr>
    <tr>
      <td>Execução</td>
      <td>Paralelismo real (se multicore)</td>
      <td>Concorrência (aproveita o tempo ocioso)</td>
    </tr>
    <tr>
      <td>Consumo de memória</td>
      <td>Mais alto (cada thread precisa de stack)</td>
      <td>Mais leve</td>      
    </tr>
     <tr>
      <td>Complexidade</td>
      <td>Alta (sincronização de threads)</td>
      <td>Moderada (event loop, async/await)</td>
    </tr>  
     <tr>
      <td>Exemplo</td>
      <td>Processar imagem em partes simultâneas</td>
      <td>Consultar múltiplas APIs em paralelo</td>
    </tr>  
  </tbody>
</table>

## Sobre o projeto de exemplo
- Para testar o projeto:
  - Realize o clone do repositório
  - Instale o sdk .net 9
  - Descomente na classe program o método de exemplo que deseja executar.
  - Asychrono: Implementação utilizando processamento assincrono
  - Multithead: Implementação utilizando multithead
  - Combine: Implementação ultilizando ambos no processamento
