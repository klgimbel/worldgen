﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LibNoise;

[System.Serializable]
public class SerializableModuleBase : ModuleBase
{
    public SerializableModuleBase(int count) : base(count)
    {
    }

    public override ModuleBase this[int index] { get => base[index]; set => base[index] = value; }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override double GetValue(double x, double y, double z)
    {
        return 0d;
    }

    public override string ToString()
    {
        return base.ToString();
    }

    protected override bool Disposing()
    {
        return base.Disposing();
    }
}
