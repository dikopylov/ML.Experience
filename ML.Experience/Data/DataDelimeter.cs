using ML.Experience.Converter;
using ML.Experience.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Experience.Data
{
    class DataDelimeter
    {
        public int Fold { get; set; }

        public DataDelimeter(int fold)
        {
            Fold = fold;
        }

        public LearnData[] Cut(LearnData data) 
        {
            LearnData[] cvData = new LearnData[Fold];
            int element = data.Inputs.Length / Fold;

            LearnData copyData = (LearnData)data.Clone();

            Shuffle(copyData);
            for (int i = 0; i < Fold; i++)
            {

                if (i == Fold - 1)
                {
                    cvData[i] = new LearnData
                    {
                        Inputs = new double[copyData.Inputs.Length - element * i][],
                        Outputs = new int[copyData.Inputs.Length - element * i]
                    };
                    Array.Copy(copyData.Inputs, cvData[i].Inputs, copyData.Inputs.Length - element * i);
                    Array.Copy(copyData.Outputs, cvData[i].Outputs, copyData.Inputs.Length - element * i);
                }
                else
                {
                    cvData[i] = new LearnData
                    {
                        Inputs = new double[element][],
                        Outputs = new int[element]
                    };
                    Array.Copy(copyData.Inputs, cvData[i].Inputs, element);
                    Array.Copy(copyData.Outputs, cvData[i].Outputs, element);
                }
            }
            return cvData;
        }

        void Shuffle(LearnData data)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = data.Outputs.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                int tmp = data.Outputs[j];
                data.Outputs[j] = data.Outputs[i];
                data.Outputs[i] = tmp;

                double[] temp = data.Inputs[j];
                data.Inputs[j] = data.Inputs[i];
                data.Inputs[i] = temp;
            }
        }

    }
}
