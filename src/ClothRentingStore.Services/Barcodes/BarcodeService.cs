using ClothRentingStore.Core.Interfaces.Services;
using ZXing;
using ZXing.Common;

namespace ClothRentingStore.Services.Barcodes;

public class BarcodeService : IBarcodeService
{
    public byte[] GenerateBarcodePng(string content, int width = 300, int height = 100)
    {
        var writer = new BarcodeWriterPixelData
        {
            Format = BarcodeFormat.CODE_128,
            Options = new EncodingOptions
            {
                Width = width,
                Height = height,
                Margin = 2
            }
        };

        var pixelData = writer.Write(content);
        return pixelData.Pixels;
    }

    public byte[] GenerateQrCodePng(string content, int size = 250)
    {
        var writer = new BarcodeWriterPixelData
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new EncodingOptions
            {
                Width = size,
                Height = size,
                Margin = 2
            }
        };

        var pixelData = writer.Write(content);
        return pixelData.Pixels;
    }
}
