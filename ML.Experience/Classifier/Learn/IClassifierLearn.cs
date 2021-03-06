﻿using ML.Experience.Converter;
using ML.Experience.Data;

namespace ML.Experience.Classifier.Learn
{
    interface IClassifierLearn
    {
        void Learn(LearnData data);
        
        int[] TestPredict(LearnData data);

        void Save(string path);
    }
}
