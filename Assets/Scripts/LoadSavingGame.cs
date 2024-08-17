using System.Collections;
using System.Collections.Generic;
using UHFPS.Runtime;
using UnityEngine;

public class LoadSavingGame : MonoBehaviour
{
    private void OnEnable()
    {
        if(TryGetComponent<SavesUILoader>(out SavesUILoader loader))
        {
            loader.LoadSavedGames();
        }
    }
}
