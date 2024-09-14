using System.Collections;
using System.Collections.Generic;
using UHFPS.Runtime;
using UnityEngine;


public class Paper : MonoBehaviour
{
    [SerializeField] private ItemGuid thisItem;
    [SerializeField] private Material paperMaterialBeforeSolving;
    [SerializeField] private Material paperMaterialAfterSolving;

    private Inventory inventory;

    private static bool canStart = false;
    // Start is called before the first frame update
    private void Start()
    {
        PaperManager.Instance.OnPaperStutesChange += PaperManager_OnPaperStutesChange;

        if (!canStart)
            StartCoroutine(SetCanStart());
    }

    private void OnEnable()
    {
        inventory = Inventory.Instance;

        if (canStart)
        {
            Debug.Log("OnEnable.TrySetPaper()");
            TrySetPaper();
        }

    }

    private void PaperManager_OnPaperStutesChange(object sender, System.EventArgs e)
    {
        Debug.Log("OnPaperStutesChange().TrySetPaper()");
        TrySetPaper();
    }

    public void TrySetPaper()
    {
        Debug.Log($"inventory {inventory} and thisItem {thisItem}");
        // get reference to the InventoryItem
        var inventoryItem = inventory.GetInventoryItem(thisItem);
        var itemData = inventoryItem.CustomData;

        // get custom data using JObject
        var json = itemData.GetJson();

        if ((bool)json["solved"])
        {
            gameObject.GetComponent<MeshRenderer>().material = paperMaterialAfterSolving;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = paperMaterialBeforeSolving;
        }
    }

    private IEnumerator SetCanStart()
    {
        yield return new WaitForSeconds(0.5f);
        canStart = true;
    }

    private void OnDestroy()
    {
        PaperManager.Instance.OnPaperStutesChange -= PaperManager_OnPaperStutesChange;
    }
}