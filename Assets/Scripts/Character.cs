using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character")]
public class Character : ScriptableObject
{
    [SerializeField]
    private string Name;
    [SerializeField]
    private int health;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int armor;

    public Character(Character character)
    {
        this.Name = character.Name;
        this.health = character.health;
        this.damage = character.damage;
        this.armor = character.armor;
    }
    public string GetName()
    {
        return Name;
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetDamage()
    {
        return damage;
    }
    public int GetArmor()
    {
        return armor;
    }
    public void DealDamage(int damageDealt)
    {
        health -= damageDealt;
    }    
}
