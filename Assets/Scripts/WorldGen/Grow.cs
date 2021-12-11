using LibNoise;
using UnityEngine;

namespace WorldGen
{
    [System.Serializable]
    public class Grow : SerializableModuleBase
    {
        #region Fields

        public double _width = 1;
        public double _sampleRate = 0.5;
        public double _threshold = 0.5;
        public double pass = 1;
        public double fail = 0;

        #endregion

        #region Constructors

        public Grow()
            : base(1)
        {
        }

        public Grow(ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
        }

        public Grow(ModuleBase input, double width, double sampleRate, double threshold, double pass, double fail)
            : base(1)
        {
            Threshold = threshold;
            SampleRate = sampleRate;
            Width = width;
            Threshold = threshold;
            Pass = pass;
            Fail = fail;
            Modules[0] = input;
        }

        #endregion

        #region Properties

        public double Threshold
        {
            get => _threshold;
            set => _threshold = value;
        }

        public double Width
        {
            get => _width;
            set => _width = value;
        }

        public double SampleRate
        {
            get => _sampleRate;
            set => _sampleRate = value;
        }

        public double Pass
        {
            get => pass;
            set => pass = value;
        }

        public double Fail
        {
            get => fail;
            set => fail = value;
        }

        #endregion

        #region ModuleBase Members

        public override double GetValue(double x, double y, double z)
        {
            Debug.Assert(Modules[0] != null);
            for (double i = x - Width; i <= x + Width; i+= SampleRate)
            {
                for (double j = y - Width; j <= y + Width; j+= SampleRate)
                {
                    for (double k = z - Width; k <= z + Width; k+= SampleRate)
                    {

                        if (Modules[0].GetValue(i, j, k) > Threshold) return Pass;
                    }
                }
            }
            return Fail;
        }

        #endregion
    }
}