using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace MakePassService.Methods;

public static class Documents
{
    public static byte[] GetBytesImage(string fileName, ImageFormat imageFormat)
    {
        using var ms = new MemoryStream();
        Image.FromFile(fileName).Save(ms, imageFormat);
        return ms.ToArray();
    }

    public static async Task<byte[]> GetBytesPdf(string fileName) => 
        await File.ReadAllBytesAsync(fileName);
}