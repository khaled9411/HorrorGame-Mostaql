using System.Collections;
using System.Collections.Generic;
using UHFPS.Runtime;
using UnityEngine;


public class CloseDoorWithTriger : MonoBehaviour
{
    [SerializeField] private DynamicObject dynamicObject;

    private void OnTriggerEnter(Collider other)
    {
        dynamicObject.SetCloseState();
        dynamicObject.TryUnlockResult(false);
    }
}
