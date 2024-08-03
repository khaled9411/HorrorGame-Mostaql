using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public enum DoorType
    {
        Normal,
        Key,
        Passcode
    }

    public DoorType doorType = DoorType.Normal;
    public string requiredKeyName;
    public string correctPasscode;

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
        switch (doorType)
        {
            case DoorType.Normal:
                return "Open/Close The Door";
            case DoorType.Key:
                return "Use Key to Open Door";
            case DoorType.Passcode:
                return "Enter Passcode";
            default:
                return "Interact";
        }
    }

    public Transform GetInteractTransform()
    {
        return transform;
    }

    public void Interact()
    {
        switch (doorType)
        {
            case DoorType.Normal:
                ToggleDoor();
                break;
            case DoorType.Key:
                TryOpenWithKey();
                break;
            case DoorType.Passcode:
                PromptForPasscode();
                break;
        }
    }

    private void ToggleDoor()
    {
        isOpen = !isOpen;
        GetComponent<Collider>().isTrigger = isOpen;
    }

    private void TryOpenWithKey()
    {
        PlayerInventory inventory = FindObjectOfType<PlayerInventory>();
        if (inventory != null && inventory.HasKey(requiredKeyName))
        {
            ToggleDoor();
            Debug.Log("Door opened with the correct key.");
        }
        else
        {
            Debug.Log("You need the correct key to open this door.");
        }
    }

    private void PromptForPasscode()
    {
        // Here you would implement UI to ask for passcode
        // For this example, we'll use a simple debug log
        Debug.Log("Enter passcode:");
        // In a real game, you'd get input from the player
        string enteredPasscode = "1234"; // Example passcode
        CheckPasscode(enteredPasscode);
    }

    private void CheckPasscode(string enteredPasscode)
    {
        if (enteredPasscode == correctPasscode)
        {
            ToggleDoor();
            Debug.Log("Door opened with the correct passcode.");
        }
        else
        {
            Debug.Log("Incorrect passcode.");
        }
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