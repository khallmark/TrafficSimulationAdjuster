﻿using System;
using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;

namespace TrafficSimulationAdjuster;

[FileLocation(nameof(TrafficSimulationAdjuster))]
public class TrafficSimulationAdjusterOptions : ModSetting
{
    public TrafficSimulationAdjusterOptions(IMod mod)
        : base(mod)
    {
        SetDefaults();
    }

    private int _TrafficReductionCoefficient;
    [SettingsUISlider(min = 0, max = 10)]
    public int TrafficReductionCoefficient
    {
        get { return _TrafficReductionCoefficient; }
        set
        {
            if (_TrafficReductionCoefficient == value) return;
            _TrafficReductionCoefficient = value;
            new PrefabPatcher().PatchEconomyParameters(value);
        }
    }
    
    public override void SetDefaults()
    {
        TrafficReductionCoefficient = 4;
    }
}