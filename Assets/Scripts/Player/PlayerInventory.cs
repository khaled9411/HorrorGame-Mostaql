using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<string> keys = new List<string>();

    public void AddKey(string keyName)
    {
        keys.Add(keyName);
    }

    public bool HasKey(string keyName)
    {
        return keys.Contains(keyName);
    }
}