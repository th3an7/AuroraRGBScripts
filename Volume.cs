using Aurora;
using Aurora.EffectsEngine;
using Aurora.Profiles;
using Aurora.Devices;
using Aurora.Utils;
using Aurora.Settings;
using System;
using System.Drawing;
using System.Collections.Generic;
using NAudio.CoreAudioApi;

public class VolumeScript : IEffectScript
{

    MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
    MMDevice defaultDevice = null;
    public string ID { get; private set; }

    public KeySequence DefaultKeys = new KeySequence();

    public VariableRegistry Properties { get; private set; }

    public VolumeScript()
    {
        ID = "Volume Layer - Show every 10%";
        Properties = new VariableRegistry();
        //Create Properties
    }

    public object UpdateLights(VariableRegistry settings, IGameState state = null)
    {
        if (defaultDevice == null)
                defaultDevice = devEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            Queue<EffectLayer> layers = new Queue<EffectLayer>();

        EffectLayer layer = new EffectLayer(this.ID);
        float currentVolume = defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar;
        layer.PercentEffect(Color.White, Color.Transparent, new KeySequence(new[] { DeviceKeys.F1, DeviceKeys.F2, DeviceKeys.F3, DeviceKeys.F4, DeviceKeys.F5, DeviceKeys.F6, DeviceKeys.F7, DeviceKeys.F8, DeviceKeys.F9, DeviceKeys.F10, }), currentVolume % 10D, 1.0f, PercentEffectType.Progressive);
        //layers.Enqueue(layer);

        EffectLayer layer_2 = new EffectLayer(this.ID + " 2");
        layer_2.PercentEffect(Color.FromArgb(255, 0, 0, 0), Color.Transparent, new KeySequence(new[] { DeviceKeys.F1, DeviceKeys.F2, DeviceKeys.F3, DeviceKeys.F4, DeviceKeys.F5, DeviceKeys.F6, DeviceKeys.F7, DeviceKeys.F8, DeviceKeys.F9, DeviceKeys.F10, }), currentVolume % 10D - 0.1f, 1.0f, PercentEffectType.Progressive);
        //layers.Enqueue(layer_2);

        EffectLayer layerMain = layer + layer_2;
        layers.Enqueue(layerMain);
        
        return layers.ToArray();
	}
}