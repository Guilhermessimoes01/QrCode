using QRCoder;
using System.Drawing;

Console.WriteLine("Hello World!");

Console.WriteLine("Input your url to convert: ");
var url = Console.ReadLine();

if(string.IsNullOrEmpty(url))
{
    Console.WriteLine("Invalid input.");
}

var qrGenerator = new QRCodeGenerator();
var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);

var qrCode = new BitmapByteQRCode(qrCodeData);
var qrCodeImage = qrCode.GetGraphic(pixelsPerModule: 20);

using var ms = new MemoryStream(qrCodeImage);
using var imgFromStream = Image.FromStream(ms);

// Defina o caminho do diretório onde deseja salvar a imagem
string directoryPath = @"C:\Users\Simões\source\repos\QrCode";

// Verifique se o diretório existe e, se não existir, crie-o
if (!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);
}

// Crie o caminho completo do arquivo
string filePath = Path.Combine(directoryPath, "qrcode.png");

// Salve a imagem no caminho especificado
imgFromStream.Save(filePath);
Console.WriteLine($"QR Code saved to {filePath}");