using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    private void Start()
    {
        Player.Instance.OnSelectedItemChanged += Player_OnSelectedItemChanged;
    }

    private void Player_OnSelectedItemChanged(object sender, Player.OnSelectedItemChangedEventArgs e)
    {
        try
        {
            if (e != null && e.selectedItem != null)
            {
                Show(e.selectedItem);
            }
            else
            {
                Hide();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred: {ex.Message}");
        }
    }

    public void Show(IInteractable selectedItem)
    {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = selectedItem.GetInteractText();
    }

    public void Hide() 
    {
        containerGameObject.SetActive(false);
    }
}
