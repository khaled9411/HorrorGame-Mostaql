using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool isVisible = false;
    public bool isOpen = false;
    public float openAngle = 90f;
    public float smoothSpeed = 2f;
    public GameObject visual;

    private Quaternion initialRotation;
    private Quaternion targetRotation;

    void Start()
    {
        initialRotation = visual.transform.rotation;
        targetRotation = initialRotation;
    }

    void Update()
    {
        if (isOpen)
        {
            targetRotation = initialRotation * Quaternion.Euler(0, openAngle, 0);
        }
        else
        {
            targetRotation = initialRotation;
        }

        visual.transform.rotation = Quaternion.Slerp(visual.transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }

public string GetInteractText()
    {
        return "Open/Close The Door";
    }

    public Transform GetInteractTransform()
    {
        return transform;
    }

    public void Interact()
    {
        isOpen = !isOpen;
        GetComponent<Collider>().isTrigger = isOpen;
    }

    public bool IsVisibal()
    {
        return isVisible;
    }

    public void SetIsVisibal(bool visibal)
    {
        isVisible = visibal;
    }

}
