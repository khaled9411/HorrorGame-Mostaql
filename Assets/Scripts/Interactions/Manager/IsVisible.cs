using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour
{
    private IInteractable item;

    private void Start()
    {
        item = GetComponentInParent<IInteractable>();
    }

    private void OnBecameVisible()
    {
        item.SetIsVisibal(true);
    }

    private void OnBecameInvisible()
    {
        item.SetIsVisibal(false);
    }
}
