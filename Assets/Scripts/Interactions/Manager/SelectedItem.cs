using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedItem : MonoBehaviour
{
    private IInteractable item;
    [SerializeField] private GameObject visualGameObject;

    // Start is called before the first frame update
    void Start()
    {
        item = GetComponentInParent<IInteractable>();

        Player.Instance.OnSelectedItemChanged += Player_OnSelectedItemChanged;
    }

    private void Player_OnSelectedItemChanged(object sender, Player.OnSelectedItemChangedEventArgs e)
    {
        try
        {
            if (e?.selectedItem == item)
            {
                Show();
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

    private void Show()
    {
        visualGameObject.SetActive(true);
    }

    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
