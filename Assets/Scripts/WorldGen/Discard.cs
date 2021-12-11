using LibNoise;
using UnityEngine;

namespace WorldGen
{
    public enum DiscardType
    {
        Above,
        Below
    }

    public enum DiscardValue
    {
        Threshold,
        Custom
    }
    [System.Serializable]
    public class Discard : SerializableModuleBase
    {
        #region Fields

        public DiscardType _discardType = DiscardType.Below;
        public DiscardValue _discardValue = DiscardValue.Custom;
        public double _customDiscardValue = 0;
        public double _threshold = 0.5;

        #endregion

        #region Constructors

        public Discard()
            : base(1)
        {
        }

        public Discard(ModuleBase input)
            : base(1)
        {
            Modules[0] = input;
        }

        public Discard(ModuleBase input, double threshold, DiscardType discardType, DiscardValue discardValue, double customDiscardvalue)
            : base(1)
        {
            Threshold = threshold;
            DiscardType = discardType;
            DiscardValue = discardValue;
            CustomDiscardValue = customDiscardvalue;
            Modules[0] = input;
        }

        #endregion

        #region Properties

        public double Threshold
        {
            get => _threshold;
            set => _threshold = value;
        }

        public DiscardType DiscardType
        {
            get => _discardType;
            set => _discardType = value;
        }

        public DiscardValue DiscardValue
        {
            get => _discardValue;
            set => _discardValue = value;
        }

        public double CustomDiscardValue
        {
            get => _customDiscardValue;
            set => _customDiscardValue = value;
        }

        #endregion

        #region ModuleBase Members

        public override double GetValue(double x, double y, double z)
        {
            Debug.Assert(Modules[0] != null);
            var v = Modules[0].GetValue(x, y, z);
            if (_discardType == DiscardType.Below && v < _threshold)
            {
                return _discardValue == DiscardValue.Threshold ? _threshold : _customDiscardValue;
            }
            if (_discardType == DiscardType.Above && v > _threshold)
            {
                return _discardValue == DiscardValue.Threshold ? _threshold : _customDiscardValue;
            }
            return v;
        }

        #endregion
    }
}