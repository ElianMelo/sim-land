using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AccessorySO", menuName = "ScriptableObjects/AccessorySO")]
[Serializable]
public class AccessorySO : ScriptableObject
{
    public Sprite icon;
    public string title;
    public int price;
    public BodyPartType type;
}
