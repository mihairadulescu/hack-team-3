using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Tesseract;

namespace corrida.ocr
{
    public class TesseractOcr
    {
        public TesseractResult Process(string filePath, string testDataFolder)
        {
            var result = new TesseractResult();

            using (TesseractEngine engine = new TesseractEngine(testDataFolder, "eng", EngineMode.Default))
            {
                using (PixArray pages = PixArray.LoadMultiPageTiffFromFile(filePath))
                {
                    foreach (Pix p in pages)
                    {
                        using (Page page = engine.Process(p))
                        {
                            string text = page.GetText();
                            result.Pages.Add(text);
                        }
                    }
                }
            }
            return result;
        }
    }
}
