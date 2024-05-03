using UnityEngine;

[CreateAssetMenu(fileName = "PlayerBodyPartSO", menuName = "ScriptableObjects/PlayerBodyPartSO", order = 1)]
public class PlayerBodyPartSO : ScriptableObject
{
    public string animatorControllerName;

    public BodyPartType bodyPartType;
}

public enum BodyPartType
{
    HAT,
    CLOTHES,
    HAIR,
    BASE
}
