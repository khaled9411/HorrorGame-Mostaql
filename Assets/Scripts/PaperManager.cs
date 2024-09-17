using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UHFPS.Tools;
using ThunderWire.Attributes;
using UHFPS.Runtime;
using static UHFPS.Runtime.InventoryItem;
using System;

[InspectorHeader("Paper Manager")]
public class PaperManager : MonoBehaviour
{
    public static PaperManager Instance;

    public event EventHandler OnPaperStutesChange;

    public ItemGuid[] Papers;

    private Inventory inventory;

    public static bool canStart = false;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.Instance;

        //OnPaperStutesChange?.Invoke(this, EventArgs.Empty);
        //Debug.Log((bool)json["solved"]);
    }


    private void Awake()
    {
        Instance = this;
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

    public void SetAllPapersSolvid()
    {
        foreach (var paper in Papers)
        {
            if (inventory.GetInventoryItem(paper))
            {
                // get reference to the InventoryItem
                var inventoryItem = inventory.GetInventoryItem(paper);
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
        OnPaperStutesChange?.Invoke(this, EventArgs.Empty);
    }

    private void OnDestroy()
    {
        canStart = false;
    }
}

