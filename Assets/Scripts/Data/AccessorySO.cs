using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AccessorySO", menuName = "ScriptableObjects/AccessorySO")]
[Serializable]
public class AccessorySO : ScriptableObject
{
    public Sprite picture;
    public string description;
    public int reward;
    public int amount;
    // public ItemSO item;
}
