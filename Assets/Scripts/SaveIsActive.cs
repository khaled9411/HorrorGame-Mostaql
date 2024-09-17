using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UHFPS;
using UHFPS.Runtime;
using Newtonsoft.Json.Linq;
using ThunderWire.Attributes;

[InspectorHeader("Save Is Active")]
public class SaveIsActive : MonoBehaviour, ISaveable
{
    public void OnLoad(JToken data)
    {
        transform.GetChild(0).gameObject.SetActive(data[transform.parent.name + transform.GetChild(0).gameObject.name].ToObject<bool>());
    }

    public StorableCollection OnSave()
    {
        return new StorableCollection
        {
            {transform.parent.name +  transform.GetChild(0).gameObject.name, transform.GetChild(0).gameObject.activeSelf}
        };
    }
}
