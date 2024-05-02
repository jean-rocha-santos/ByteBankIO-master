using ByteBankIO;
using System.Text;

class Programs
{
    static void Main(string[] args)
    {
        #region
        /* var enderecoArquivo = "contas.txt";
         using (var fluxoDoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
         {

             var numeroDeBytesLidos = -1;

             var buffer = new byte[1024];    //1KB


             while (numeroDeBytesLidos != 0)
             {
                 numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                 Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}");
                 EscreverBuffer(buffer, numeroDeBytesLidos);

             }
             fluxoDoArquivo.Close();
         }

         // Devoluções:
         // 0 número total de bytes lidos do buffer. Isso poderá ser menor que o número de
         // bytes solicitado se esse número de bytes não estiver disponível no momento, ou
         //zero, se o final do fluxo for atingido


         // public override int Read(byte [] array, in offset, int count);

         Console.ReadLine();

         static void EscreverBuffer(byte[] buffer, int byteLidos)
         {
             var utf8 = new UTF8Encoding();

             var texto = utf8.GetString(buffer,0,byteLidos);

             // public virtual string GetString(byte[] bytes, int index, int count);
             Console.Write(texto);
               foreach (byte b in buffer)
               {
                   Console.Write(b);
                   Console.Write(" ");
               }
         }*/
        #endregion
        var enderecoDoArquivo = "contas.txt";
        using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);

            // var linha = leitor.ReadLine();
            // var texto= leitor.ReadToEnd();
            // var numero = leitor.Read();
            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var contaCorrente = ConverterStringParaContaCorrente(linha);
                var msg = $"{contaCorrente.Titular.Nome} Conta número {contaCorrente.Numero}, ag {contaCorrente.Agencia}, Saldo {contaCorrente.Saldo} ";
                Console.WriteLine(msg);
            }
        }
        Console.ReadLine();
    }
    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        // 375 4644 2483.13 Jonatan
        var campos = linha.Split(',');

        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2].Replace('.', ',');
        var nomeTitular = campos[3];

        var agenciaComInt = int.Parse(agencia);
        var numeroComInt = int.Parse(numero);
        var saldoComDouble = double.Parse(saldo);

        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(agenciaComInt, numeroComInt, titular);
        resultado.Depositar(saldoComDouble);
        resultado.Titular = titular;

        return resultado;
    }



}