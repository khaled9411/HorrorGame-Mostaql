using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UHFPS.Tools;
using ThunderWire.Attributes;
using UHFPS.Runtime;

[InspectorHeader("Paper Manager")]
public class PaperManager : MonoBehaviour
{
    public ItemGuid[] Papers;

    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.Instance;
    }

    // Call when the solving Paper is taken
    public void SetPaperSolvid(int paperNumber)
    {
        // get reference to the InventoryItem
        var inventoryItem = inventory.GetInventoryItem(Papers[paperNumber]);
        var itemData = inventoryItem.CustomData;

        // get custom data using JObject
        var json = itemData.GetJson();

        // set the solved boolen to true
        //Debug.Log((bool)json["solved"]);
        json["solved"] = true;

        // save json string
        itemData.Update(json);

        //Debug.Log((bool)json["solved"]);
    }
}
