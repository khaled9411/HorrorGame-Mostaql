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
    // LayerMask to specify which layers to consider as obstacles
    [SerializeField] private LayerMask obstacleLayer;

    StarterAssetsInputs inputs;
    private Vector3 lastInteractDir;

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
            
            if (interactable.IsVisibal()/* && IsPathClear(transform , interactable.GetInteractTransform())*/)
            {
                //RaycastHit hit;
                //Physics.Raycast(transform.position, (interactable.GetInteractTransform().position - transform.position).normalized, out hit, interactRange);

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
        return closesItemInteractble;
    }


    ///// <summary>
    ///// Checks if there is an obstacle between two objects.
    ///// </summary>
    ///// <param name="object1">The first object's Transform.</param>
    ///// <param name="object2">The second object's Transform.</param>
    ///// <returns>Returns true if there is no obstacle, false if there is an obstacle.</returns>
    //public bool IsPathClear(Transform object1, Transform object2)
    //{
    //    Vector3 direction = object2.position - object1.position;
    //    float distance = direction.magnitude;

    //    // Perform the raycast
    //    if (Physics.Raycast(object1.position, direction, distance, obstacleLayer))
    //    {
    //        // An obstacle was detected
    //        return false;
    //    }

    //    // No obstacle was detected
    //    return true;
    //}

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
