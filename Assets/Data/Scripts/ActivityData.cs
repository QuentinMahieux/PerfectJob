using UnityEngine;

[CreateAssetMenu(fileName = "ActivityData", menuName = "Scriptable Objects/ActivityData")]
public class ActivityData : ScriptableObject
{
    public string scene;
    public string descrition;
    
    public RewardType rewardType;
    public EffectType effectType;
    public ActivtyType activtyType;

    public int scale = 1;
}
public enum RewardType
{
    None,
    Argent,
    Energy,
    Badge
}

public enum EffectType
{
    None,
    Left,
    Right,
    Double
}
public enum ActivtyType
{
    Action,
    Reward
}