using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items")]
public class Item : ScriptableObject
{
    new public string name;
    public Sprite icon = null;
    public int count = 0;
}
