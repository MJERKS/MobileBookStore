using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Aspose.Pdf;
using Aspose.Pdf.Devices;
using MobileBookStore.Model.Entities;
using Ninject.Activation;

namespace MobileBookStore.Helpers
{
    public static class FileManager
    {
        private const string BookFolder = "BooksById\\";
        public const string ImageFolder = "ImagesFromBooks\\";
        private const int pagesToRender = 4;

        public static List<string> GeneratePreviewImages(Book book, string physicalPath)
        {
            if (book != null)
                {
                var bookPath = physicalPath + BookFolder;
                var imgPath = physicalPath + ImageFolder;
                var bookName = Pdf(book.Id.ToString());

                if (!File.Exists(bookPath + bookName))
                    FileManager.DownloadFile(new Uri(book.FilePath), bookPath + bookName);
            

                var imgNames = new List<string>();
                for (var i = 0; i < pagesToRender; i++)
                    imgNames.Add(Png(book.Id + "-" + i));

                for (int i = 0; i < imgNames.Count; i++) {
                    if (!File.Exists(imgPath + imgNames[i]))
                        FileManager.RenderPdfToPng(bookPath + bookName, imgPath + imgNames[i], i);
                }

                return imgNames;
            }
            return new List<string>();
        }

        private static void DownloadFile(Uri address, string filePath)
        {
            using (var client = new WebClient())
            using (var stream = client.OpenRead(address))
            using (var file = File.Create(filePath))
            {
                var buffer = new byte[4096];
                int bytesReceived;
                while ((bytesReceived = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    file.Write(buffer, 0, bytesReceived);
                }
            }
        }

        private static void RenderPdfToPng(string pdfPath, string imgPath, int pageNr)
        {
                var pdfDocument = new Aspose.Pdf.Document(pdfPath);

                using (FileStream imageStream = new FileStream(imgPath, FileMode.Create))
                {
                    imageStream.Close();
                    Resolution resolution = new Resolution(72);
                    PngDevice pngDevice = new PngDevice(resolution);
                    pngDevice.Process(pdfDocument.Pages[pageNr+1], imgPath);
                    
                }
        }



        private static string Pdf(string name)
        {
            return name + ".pdf";
        }
        private static string Png(string name)
        {
            return name + ".png";
        }
    }
}