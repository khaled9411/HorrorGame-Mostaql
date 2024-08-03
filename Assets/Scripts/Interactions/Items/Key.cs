using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;
    public string requiredKeyName;
    public bool isVisible = false;

    PlayerInventory inventory;

    private void Start()
    {
        inventory = FindAnyObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        if (inventory != null)
        {
            inventory.AddKey(requiredKeyName);
        }
        Debug.Log("Key Taken");
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
