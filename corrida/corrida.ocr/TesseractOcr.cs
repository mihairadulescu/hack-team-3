using System.Drawing;
using System.IO;
using Tesseract;

namespace corrida.ocr
{
    public class TesseractOcr
    {

        public string Process(string file, string path)
        {
            var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.Default);
            var result = ocr.Process(Pix.LoadFromFile(file), Rect.Empty);

            var text =  result.GetText();
            return text;
        }
    }
}
