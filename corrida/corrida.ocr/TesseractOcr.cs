using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Tesseract;

namespace corrida.ocr
{
    public class TesseractOcr
    {
        public TesseractResult Process(string file)
        {
            var tessDataPath = @"D:\hackathon\hack-team-3\corrida\corrida\bin\tessdata";

            var result = new TesseractResult();
            using (var engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(file))
                {
                    using (var page = engine.Process(img))
                    {
                        var text = page.GetText();
                        result.Pages.Add(text);
                        result.MeanConfidence = page.GetMeanConfidence();
<<<<<<< HEAD

                        using (var iter = page.GetIterator())
                        {
                            iter.Begin();
                            do
                            {
                                result.Pages.Add(iter.GetText(PageIteratorLevel.Block));
                            } while (iter.Next(PageIteratorLevel.Block));

=======

                        using (var iter = page.GetIterator())
                        {
                            iter.Begin();
                            while (iter.Next(PageIteratorLevel.Block)) ;
>>>>>>> 8ffb850499fe3712d483faeee530392f7ebaee73
                        }
                    }
                }
            }
            return result;
        }
    }
}
