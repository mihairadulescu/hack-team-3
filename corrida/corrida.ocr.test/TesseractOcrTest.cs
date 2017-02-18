﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using corrida.ocr;

namespace corrida.ocr.test
{
    [TestClass]
    public class TesseractOcrTest
    {
        [TestMethod]
        public void TestProcess()
        {
            TesseractOcr ocr = new TesseractOcr();

            string file = @"Files/InvoiceStay_NY.tif";
            string path = "Files";
            ocr.Process(file, path);

        }
    }
}