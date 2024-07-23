using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour
{
    [SerializeField] private Item item;

    private void OnBecameVisible()
    {
        item.isVisible = true;
    }

    private void OnBecameInvisible()
    {
        item.isVisible = false;
    }
}
