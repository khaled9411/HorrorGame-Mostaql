using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;
    public bool isVisible = false;
    public void Interact()
    {
        Debug.Log("The Item Taken");
        gameObject.SetActive(false);
    }


    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetInteractTransform()
    {
        return transform;
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
