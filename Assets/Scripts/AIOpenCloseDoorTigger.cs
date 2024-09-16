using System.Collections;
using System.Collections.Generic;
using UHFPS.Runtime;
using UnityEngine;
using UnityEngine.AI;

public class AIOpenCloseDoorTigger : MonoBehaviour
{
    [SerializeField] private DynamicObject door;
    //[SerializeField] private bool isOpenedDoor;
    private int agentsInRange = 0;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform);
        if(other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent) && !door.isLocked)
        {
            agentsInRange++;

            door.openable.OnDynamicOpen();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent) && !door.isLocked)
        {
            agentsInRange--;

            if(agentsInRange == 0)
            {
                door.openable.OnDynamicClose();
            }
        }
    }
}
