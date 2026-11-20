namespace ClothRentingStore.Core.Interfaces.Services;

public interface IBarcodeService
{
    byte[] GenerateBarcodePng(string content, int width = 300, int height = 100);
    byte[] GenerateQrCodePng(string content, int size = 250);
}
