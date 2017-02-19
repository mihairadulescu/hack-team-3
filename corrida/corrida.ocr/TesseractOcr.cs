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
            var language = "ron";
            var result = new TesseractResult();

            string fileExtension = Path.GetExtension(filePath);

            if (fileExtension != "tif")
            {
                using (TesseractEngine engine = new TesseractEngine(testDataFolder, language, EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(filePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            result.Pages.Add(page.GetText());
                            result.MeanConfidences.Add(page.GetMeanConfidence());

                        }
                    }
                }
            }
            else
            {

                using (TesseractEngine engine = new TesseractEngine(testDataFolder, language, EngineMode.Default))
                {
                    using (PixArray pages = PixArray.LoadMultiPageTiffFromFile(filePath))
                    {
                        foreach (Pix p in pages)
                        {
                            using (Page page = engine.Process(p))
                            {
                                result.Pages.Add(page.GetText());
                                result.MeanConfidences.Add(page.GetMeanConfidence());
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
