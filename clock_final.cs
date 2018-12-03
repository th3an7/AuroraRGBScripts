using Aurora;
using Aurora.EffectsEngine;
using Aurora.Profiles;
using Aurora.Devices;
using Aurora.Utils;
using Aurora.Settings;
using System;
using System.Drawing;
using System.Collections.Generic;

public class Clock : IEffectScript
{
    public string ID { get; private set; }

    public KeySequence DefaultKeys = new KeySequence();

    public VariableRegistry Properties { get; private set; }

    public Clock()
    {
        ID = "Clock Final (Multi-Layer)";
        Properties = new VariableRegistry();
        //Create Properties
    }

    public object UpdateLights(VariableRegistry settings, IGameState state = null)
    {
        Queue<EffectLayer> layers = new Queue<EffectLayer>();

        EffectLayer layer = new EffectLayer(this.ID);
        layer.PercentEffect(Color.White, Color.Black, new KeySequence(new[] { DeviceKeys.F1, DeviceKeys.F2, DeviceKeys.F3, DeviceKeys.F4, DeviceKeys.F5, DeviceKeys.F6, DeviceKeys.F7, DeviceKeys.F8, DeviceKeys.F9, DeviceKeys.F10, DeviceKeys.F11, DeviceKeys.F12 }), DateTime.Now.Hour % 12D, 12D, PercentEffectType.Progressive);
        layers.Enqueue(layer);

        EffectLayer layer_2 = new EffectLayer(this.ID + " 2");
        layer_2.PercentEffect(Color.White, Color.Transparent, new KeySequence(new[] { DeviceKeys.NUM_ONE, DeviceKeys.NUM_TWO, DeviceKeys.NUM_THREE, DeviceKeys.NUM_FOUR, DeviceKeys.NUM_FIVE, DeviceKeys.NUM_SIX, DeviceKeys.NUM_SEVEN, DeviceKeys.NUM_EIGHT, DeviceKeys.NUM_NINE, DeviceKeys.NUM_ZERO }), DateTime.Now.Second % 10D, 10D, PercentEffectType.Progressive);
        //layers.Enqueue(layer_2);

        EffectLayer layer_3 = new EffectLayer(this.ID + " 3");
        layer_3.PercentEffect(Color.White, Color.Transparent, new KeySequence(new[] { DeviceKeys.ONE, DeviceKeys.TWO, DeviceKeys.THREE, DeviceKeys.FOUR, DeviceKeys.FIVE, DeviceKeys.SIX, DeviceKeys.SEVEN, DeviceKeys.EIGHT, DeviceKeys.NINE, DeviceKeys.ZERO }), DateTime.Now.Minute % 10f, 10D, PercentEffectType.Progressive);
        //layers.Enqueue(layer_3);

        EffectLayer layer_4 = new EffectLayer(this.ID + " 4");
        layer_4.PercentEffect(Color.FromArgb(200, 255, 0, 0), Color.Transparent, new KeySequence(new[] { DeviceKeys.ONE, DeviceKeys.TWO, DeviceKeys.THREE, DeviceKeys.FOUR, DeviceKeys.FIVE, DeviceKeys.SIX }), DateTime.Now.Minute % 60D, 60D, PercentEffectType.Progressive);
        //layers.Enqueue(layer_4);

        EffectLayer layer_5 = new EffectLayer(this.ID + " 5");
        layer_5.PercentEffect(Color.FromArgb(200, 255, 0, 0), Color.Transparent, new KeySequence(new[] { DeviceKeys.NUM_ONE, DeviceKeys.NUM_TWO, DeviceKeys.NUM_THREE, DeviceKeys.NUM_FOUR, DeviceKeys.NUM_FIVE, DeviceKeys.NUM_SIX }), DateTime.Now.Second % 60D, 60D, PercentEffectType.Progressive);
        //layers.Enqueue(layer_5);

        EffectLayer layer_sum34 = layer_3 + layer_4;
        layers.Enqueue(layer_sum34);

        EffectLayer layer_sum25 = layer_2 + layer_5;
        layers.Enqueue(layer_sum25);

        return layers.ToArray();
    }
}