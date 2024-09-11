using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAndDisactiveOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjectsToActive;
    [SerializeField] private GameObject[] gameObjectsToDisactive;

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject obj in gameObjectsToActive)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in gameObjectsToDisactive)
        {
            obj.SetActive(false);
        }
    }
}
