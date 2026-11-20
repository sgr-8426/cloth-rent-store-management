using ClothRentingStore.Core.Interfaces.Services;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ClothRentingStore.Services.Reports;

public class PdfReportService : IPdfReportService
{
    static PdfReportService()
    {
        // QuestPDF license configuration
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public Task<byte[]> GenerateHangerTagPdfAsync(int garmentId, CancellationToken cancellationToken = default)
    {
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A6);
                page.Margin(1, Unit.Centimetre);
                page.DefaultTextStyle(x => x.FontSize(11));

                page.Header()
                    .AlignCenter()
                    .Text($"Cloth Renting Store - Tag #{garmentId}")
                    .SemiBold().FontSize(14);

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(col =>
                    {
                        col.Item().Text($"Garment Reference: {garmentId}");
                        col.Item().Text("Ready for hanger tag printing");
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Generated at: ");
                        x.Span(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    });
            });
        });

        var bytes = document.GeneratePdf();
        return Task.FromResult(bytes);
    }
}
