using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour, IInteractable
{
    public static event EventHandler<OnInteractWithPaperEventArgs> OnInteractWithPaper;
    public class OnInteractWithPaperEventArgs : EventArgs
    {
        public string paperContent;
    }

    [Header("Interact")]
    [SerializeField] private string interactText;
    public bool isVisible = false;

    [Header("Paper")]
    [Multiline(10)]
    [SerializeField] private string paperContent;

    public void Interact()
    {
        Debug.Log("The Item Taken");
        OnInteractWithPaper?.Invoke(this, new OnInteractWithPaperEventArgs { paperContent = paperContent });
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
