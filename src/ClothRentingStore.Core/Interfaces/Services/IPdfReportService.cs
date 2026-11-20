namespace ClothRentingStore.Core.Interfaces.Services;

public interface IPdfReportService
{
    Task<byte[]> GenerateHangerTagPdfAsync(int garmentId, CancellationToken cancellationToken = default);
}
