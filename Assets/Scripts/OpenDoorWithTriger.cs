using System.Collections;
using System.Collections.Generic;
using UHFPS.Runtime;
using UnityEngine;

public class OpenDoorWithTriger : MonoBehaviour
{
    [SerializeField] private DynamicObject dynamicObject;
    private bool isLocked = true;

    private void OnTriggerEnter(Collider other)
    {
        isLocked = false;
        dynamicObject.SetLockedStatus(isLocked);
    }
}
