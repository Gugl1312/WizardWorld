using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public Item proba;

    public void Add(Item item)
    {
        if (items.Contains(item))
        {
            int index = items.BinarySearch(item);
            items[index].count++;
        }
        else
        {
            items.Add(item);
        }
    }
    public void Remove(Item item)
    {

    }
    public void Start()
    {
        
    }
    public void Update()
    {
        
    }    
}
