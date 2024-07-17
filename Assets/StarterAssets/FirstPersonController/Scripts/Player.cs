using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float interactDistance = 5f;

    StarterAssetsInputs inputs;
    private Vector3 lastInteractDir;

    // Start is called before the first frame update
    void Start()
    {
        inputs = GetComponent<StarterAssetsInputs>();

        inputs.OnInteraction += Inputs_OnInteraction;
    }

    private void Inputs_OnInteraction(object sender, System.EventArgs e)
    {

        Vector3 lookDir = new Vector3(inputs.look.x, 0f, inputs.look.y);

        if (lookDir != Vector3.zero)
        {
            lastInteractDir = lookDir;
        }

        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance))
        {
            if (raycastHit.transform.TryGetComponent<Interactable>(out Interactable interactable))
            {
                interactable.Interact();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        Vector3 lookDir = new Vector3(inputs.look.x, 0f, inputs.look.y);

        if (lookDir != Vector3.zero) 
        { 
            lastInteractDir = lookDir;
        }

        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance))
        {
            if (raycastHit.transform.TryGetComponent<Interactable>(out Interactable interactable)) 
            {
            }
        }
    }
}
