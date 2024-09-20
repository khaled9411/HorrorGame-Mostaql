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
        Debug.Log(dynamicObject.dynamicStatus);
        dynamicObject.dynamicStatus = DynamicObject.DynamicStatus.Normal;
        Debug.Log(dynamicObject.dynamicStatus);
    }
}
