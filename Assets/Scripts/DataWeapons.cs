using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DataWeapons 
{
    public int id;
    public string name;
    public string description;
    public float speed;
    public Sprite WeaponSprite;
    public GameObject projectile;
    public enum type { brick, blade}
    public int damage;
}
