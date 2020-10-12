using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharacterManager : MonoBehaviour
{
    private Character player;
    public void Awake()
    {
        if (System.IO.File.ReadAllText(@"playerData.txt") != null)
        {
            string text = System.IO.File.ReadAllText(@"playerData.txt");
            Debug.Log(text);
            player = ScriptableObject.CreateInstance<Character>();
            Load(text, player);
        }
        else
        {
            if (FindObjectOfType<HealthManager>() != null)
            {
                player = new Character(FindObjectOfType<HealthManager>().player);
            }
            else
            {
                Debug.Log("FindObjectOfType<HealthManager>() returns null.");
            }
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(player.GetHealth());
            player.DealDamage(15);
            Debug.Log(player.GetHealth());
            if(player.GetHealth() <= 0)
            {
                Debug.Log("GG");
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SavePlayerData();
        }
    }
    public void SavePlayerData()
    {
        string json = JsonUtility.ToJson(player);
        System.IO.File.WriteAllText(@"playerData.txt", json);
    }
    public void Load(string savedData, Object obj)
    {
        JsonUtility.FromJsonOverwrite(savedData, obj);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Item")
        {
            ItemHolder droppedItem = collision.gameObject.GetComponent<ItemHolder>();
            FindObjectOfType<InventoryManager>().Add(droppedItem.item);
            Destroy(collision.gameObject);
        }
    }
}
