using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using IfroAlimenta.Models;
using IfroAlimenta.Components.Pages;

namespace IfroAlimenta.Utilitarios
{
    public class Impressora
    {
        //método modelo de impressão
        public async Task GerarImpressao(List<Produto> listaProdutos, NavigationManager nav, IJSRuntime jsRuntime)
        {
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Relatorios\MeuRelatorio.frx");
                if (!File.Exists(filePath))
                {
                    var report = new FastReport.Report();
                    report.Dictionary.RegisterBusinessObject(listaProdutos, "listaprodutos", 10, true);
                    report.Report.Save(filePath);

                }

                var report1 = new FastReport.Report();
                report1.Report.Load(filePath);
                report1.Dictionary.RegisterBusinessObject(listaProdutos, "listaprodutos", 10, true);
                report1.Prepare();
                using var pdfExport = new FastReport.Export.PdfSimple.PDFSimpleExport();
                using var reportStream = new MemoryStream();
                pdfExport.Export(report1, reportStream);

                var fileName = $"Relatorio_{Guid.NewGuid()}.pdf";
                var filePathTemp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "RelatoriosTemp", fileName);

                // Cria a pasta se não existir
                Directory.CreateDirectory(Path.GetDirectoryName(filePathTemp));

                // Salva o arquivo PDF temporariamente na pasta wwwroot/RelatoriosTemp
                File.WriteAllBytes(filePathTemp, reportStream.ToArray());

                // Gera a URL para o arquivo temporário
                var url = nav.ToAbsoluteUri($"/RelatoriosTemp/{fileName}");

                //// Abre o relatório em uma nova guia
                //nav.NavigateTo(url.ToString(), true);

                await jsRuntime.InvokeVoidAsync("NovaGuia", url.ToString()); //alteração 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro aqui!: " + ex.Message.ToString());
                throw new Exception(ex.Message);

            }

        }//fim do método modelo de impressão 
    }
}

