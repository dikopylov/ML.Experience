using System.Data;

namespace ML.Experience.Converter
{
    interface IConverter<TInput, TOutput>
    {
        TInput[][] Inputs { get; set; }

        TOutput[] Outputs { get; set; }

        void Convert(string path);
    }
}
