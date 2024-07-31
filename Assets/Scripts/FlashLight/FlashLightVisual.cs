using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightVisual : MonoBehaviour
{
    [SerializeField] private GameObject spot;

    // Start is called before the first frame update
    void Start()
    {
        FlashLight.Instance.OnChangeFlashLightMode += FlashLight_OnChangeFlashLightMode;
    }

    private void FlashLight_OnChangeFlashLightMode(object sender, FlashLight.OnChangeFlashLightModeArgs e)
    {
        if (e.mode == FalshLightMode.Off)
        {
            spot.SetActive(false);
        }
        else
        {
            spot.SetActive(true);

            if (e.mode == FalshLightMode.Noraml)
            {
                spot.GetComponent<Light>().color = Color.white;
            }
            else if(e.mode == FalshLightMode.UV)
            {
                spot.GetComponent <Light>().color = Color.magenta;
            }

        }

    }
}
