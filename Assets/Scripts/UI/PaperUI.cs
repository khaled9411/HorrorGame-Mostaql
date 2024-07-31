using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaperUI : MonoBehaviour
{
    [SerializeField] private GameObject paperPanel;
    [SerializeField] private TMP_Text paperText;
    private StarterAssetsInputs inputs;
    private FirstPersonController firstPersonController;
    private bool isPaperOpen = false;
    private float lastInteractionTime;
    private float interactionCooldown = 0.1f;

    // Initializes components and subscribes to events
    void Start()
    {
        inputs = Player.Instance.GetComponent<StarterAssetsInputs>();
        firstPersonController = Player.Instance.GetComponent<FirstPersonController>();
        Paper.OnInteractWithPaper += Paper_OnInteractWithPaper;
        inputs.OnInteraction += Inputs_OnInteraction;
    }

    // Handles general interaction input
    // Closes the paper if it's open and enough time has passed since the last interaction
    private void Inputs_OnInteraction(object sender, System.EventArgs e)
    {
        if (Time.time - lastInteractionTime < interactionCooldown)
        {
            return; // Ignore interaction if cooldown hasn't elapsed
        }
        if (isPaperOpen)
        {
            ClosePaper();
        }
    }

    // Handles specific interaction with a paper object
    // Opens the paper and sets the last interaction time
    private void Paper_OnInteractWithPaper(object sender, Paper.OnInteractWithPaperEventArgs e)
    {
        if (!isPaperOpen)
        {
            OpenPaper(e.paperContent);
        }
        lastInteractionTime = Time.time; // Set last interaction time to prevent immediate closing
    }

    // Opens the paper UI and displays its content
    private void OpenPaper(string content)
    {
        Debug.Log("Opening the paper");
        firstPersonController.enabled = false; // Disable player movement
        paperPanel.SetActive(true); // Show paper UI
        paperText.text = content; // Set paper content
        isPaperOpen = true;
    }

    // Closes the paper UI
    private void ClosePaper()
    {
        Debug.Log("Closing the paper");
        firstPersonController.enabled = true; // Re-enable player movement
        paperPanel.SetActive(false); // Hide paper UI
        isPaperOpen = false;
    }

    // Unsubscribes from events to prevent memory leaks
    private void OnDestroy()
    {
        Paper.OnInteractWithPaper -= Paper_OnInteractWithPaper;
        inputs.OnInteraction -= Inputs_OnInteraction;
    }
}