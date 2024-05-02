using System.Text;
using ByteBank_IO;


static void CriarArquivoComWriter()
{
    var caminhoNovoArquivo = "contasExportadas.csv";

    using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
    using (var escritor = new StreamWriter(fluxoDeArquivo))
    {
        escritor.Write("456,65465,456.0,Pedro");
    }
}
