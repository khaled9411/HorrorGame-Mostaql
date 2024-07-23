using System;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }

    public event EventHandler<OnSelectedItemChangedEventArgs> OnSelectedItemChanged;
    public class OnSelectedItemChangedEventArgs : EventArgs
    {
        public IInteractable selectedItem;
    }

    [SerializeField] private float interactRange = 4f;

    StarterAssetsInputs inputs;
    private Vector3 lastInteractDir;
    Camera mainCamera;

    private Item selectedItem;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        inputs = GetComponent<StarterAssetsInputs>();

        inputs.OnInteraction += Inputs_OnInteraction;

        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        OnSelectedItemChanged?.Invoke(this, new OnSelectedItemChangedEventArgs { selectedItem = GetInteractableItem() });
    }
    private void Inputs_OnInteraction(object sender, System.EventArgs e)
    {
        IInteractable interactable = GetInteractableItem();
        if (interactable != null)
        {
            interactable.Interact();
        }
    }

    public IInteractable GetInteractableItem()
    {
        List<IInteractable> interactables = new List<IInteractable>();

        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactables.Add(interactable);
            }
        }

        IInteractable closesItemInteractble = null;
        foreach (IInteractable interactable in interactables) 
        {
            
            if (interactable.IsVisibal())
            {
                RaycastHit hit;
                if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, interactRange) 
                    && hit.transform.TryGetComponent<IInteractable>(out IInteractable interactableItem))
                {
                    if (closesItemInteractble == null)
                    {
                        closesItemInteractble = interactable;
                    }
                    else
                    {
                        if (Vector3.Distance(transform.position, interactable.GetInteractTransform().position) <
                            Vector3.Distance(transform.position, closesItemInteractble.GetInteractTransform().position))
                        {

                            //closes
                            closesItemInteractble = interactable;
                        }
                    }
                }
            }
            
           
        }
        return closesItemInteractble;
    }



    void OnDrawGizmos()
    {
        float interactRange = 4f;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);

        Vector3 playerForward = transform.forward;
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, playerForward * interactRange);

        IInteractable interactable = GetInteractableItem();
        if (interactable != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.forward, interactable.GetInteractTransform().position);
        }
    }
}
