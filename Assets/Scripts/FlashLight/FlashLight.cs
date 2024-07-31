using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum FalshLightMode
{
    Off,
    Noraml,
    UV
}

public class FlashLight : MonoBehaviour
{
    public static FlashLight Instance { get; private set; }

    public event EventHandler<OnChangeFlashLightModeArgs> OnChangeFlashLightMode;
    public class OnChangeFlashLightModeArgs : EventArgs
    {
        public FalshLightMode mode; 
    }

    StarterAssetsInputs inputs;

    public FalshLightMode mode;
    private FalshLightMode lastMode = FalshLightMode.Noraml;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        inputs = GetComponent<StarterAssetsInputs>();

        inputs.onFlashLightTurn += Inputs_onFlashLightTurn;
        inputs.onChanageFlashLightType += Inputs_onChanageFlashLightType;

    }

    private void Inputs_onChanageFlashLightType(object sender, EventArgs e)
    {
        if (mode != FalshLightMode.Off)
        {
            if (mode == FalshLightMode.Noraml)
            {
                UVLight();
            }
            else if (mode == FalshLightMode.UV)
            {
                NormalLight();
            }
        }
        OnChangeFlashLightMode?.Invoke(this, new OnChangeFlashLightModeArgs { mode = mode });
    }

    private void Inputs_onFlashLightTurn(object sender, EventArgs e)
    {
        if (mode == FalshLightMode.Off)
        {
            TurnOnFlashLight();
        }
        else if (mode != FalshLightMode.Off)
        {
            TurnoffFlashLight();
        }
        OnChangeFlashLightMode?.Invoke(this, new OnChangeFlashLightModeArgs { mode = mode });
    }
    private void NormalLight()
    {
        mode = FalshLightMode.Noraml;
        lastMode = mode;
    }

    private void UVLight()
    {
        mode = FalshLightMode.UV;
        lastMode = mode;

    }

    private void TurnOnFlashLight()
    {
        mode = lastMode;
    }

    private void TurnoffFlashLight()
    {
        mode = FalshLightMode.Off;
    }
}
