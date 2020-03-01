using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewItem", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "New item";
    public Sprite icon = null;
    public bool isDefaultItem = false;


}
