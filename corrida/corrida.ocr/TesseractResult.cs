using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace corrida.ocr
{
    public class TesseractResult
    {
        public List<string> Pages { get; set; }

        public List<float> MeanConfidences { get; set; }

        public TesseractResult()
        {
            Pages = new List<string>();
            MeanConfidences =new List<float>();
        }
    }
}
