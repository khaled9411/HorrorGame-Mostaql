using System;
using System.Collections;
using System.Collections.Generic;
using UHFPS.Runtime;
using UnityEngine;

public class OpenDoorWithTriger : MonoBehaviour
{
    [Serializable]
    public enum DoorType
    {
        locked,
        noremal
    }

    [SerializeField] private DoorType type = DoorType.locked;
    [SerializeField] private DynamicObject dynamicObject;

    private bool isLocked = true;

    private void OnTriggerEnter(Collider other)
    {
        if (type == DoorType.locked)
        {
            isLocked = false;
            dynamicObject.SetLockedStatus(isLocked);
        }
        else
        {
            dynamicObject.dynamicStatus = DynamicObject.DynamicStatus.Normal;
        }
    }
}
