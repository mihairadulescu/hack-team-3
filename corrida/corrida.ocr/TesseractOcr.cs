using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Tesseract;

namespace corrida.ocr
{
    public class TesseractOcr
    {
        public TesseractResult Process(string filePath)
        {
            var tessDataPath = @"D:\hackathon\hack-team-3\corrida\corrida\bin\tessdata";

            var result = new TesseractResult();

            using (TesseractEngine engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
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
