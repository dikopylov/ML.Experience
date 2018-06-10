using ML.Experience.Converter;
using ML.Experience.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience.CrossValid
{
    class CrossValidation
    {
        public int Fold { get; set; }

        public int K { get; set; }

        public CrossValidation(int fold, int k = 3)
        {
            Fold = fold;
            K = k;
        }

        public LearnData[][] Fit(LearnData lData) 
        {
            LearnData[][] cvData = new LearnData[Fold][];
            int element = lData.Inputs.Length / K;

            for (int i = 0; i < Fold; i++)
            {
                int startElement = 0;
                lData = Shuffle(lData);
                cvData[i] = new LearnData[K];
                for (int k = 0; k < K; k++)
                {
                    
                    cvData[i][k] = new LearnData();

                    if (k == K - 1)
                    {
                        cvData[i][k].Inputs = new double[lData.Inputs.Length - element * k][];
                        cvData[i][k].Outputs = new int[lData.Inputs.Length - element * k];
                        Array.Copy(lData.Inputs, startElement, cvData[i][k].Inputs, 0, lData.Inputs.Length - element * k);
                        Array.Copy(lData.Outputs, startElement, cvData[i][k].Outputs, 0, lData.Inputs.Length - element * k);
                    }
                    else
                    {
                        cvData[i][k].Inputs = new double[element][];
                        cvData[i][k].Outputs = new int[element];
                        Array.Copy(lData.Inputs, startElement, cvData[i][k].Inputs, 0, element);
                        Array.Copy(lData.Outputs, startElement, cvData[i][k].Outputs, 0, element);
                        startElement += element;
                    }

                }

            }
            return cvData;
        }

        LearnData Shuffle(LearnData lData)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = lData.Outputs.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                int tmp = lData.Outputs[j];
                lData.Outputs[j] = lData.Outputs[i];
                lData.Outputs[i] = tmp;

                double[] temp = lData.Inputs[j];
                lData.Inputs[j] = lData.Inputs[i];
                lData.Inputs[i] = temp;
            }
            return lData;
        }

    }
}
