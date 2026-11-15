using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ActivityData", menuName = "Scriptable Objects/ActivityData")]
public class ActivityData : ScriptableObject
{
    [field: SerializeField] public string name { get; private set; }
    [field: SerializeField] public string descrition{ get; private set; }
    [field: SerializeField] public Sprite sprite { get; private set; }
    
    [field: SerializeField] public RewardType rewardType{ get; private set; }
    [field: SerializeField] public EffectType effectType{ get; private set; }

    [field: SerializeField] public int reward { get; private set; }
    [field: SerializeField] public int energie { get; private set; }


    public ActivityDataInstance Instance()
    {
        return new ActivityDataInstance(this);
    }

    void OnValidate()
    {
        if (rewardType == RewardType.Multiplicateur && effectType == EffectType.None) effectType = EffectType.Double;
        if (rewardType != RewardType.Multiplicateur) effectType = EffectType.None;
    }
}

[System.Serializable]
public class ActivityDataInstance
{
    public string name;
    public string descrition;
    public Sprite sprite;
    
    public RewardType rewardType;
    public EffectType effectType;
    
    public int reward;
    public int energie;
    
    public ActivityDataInstance(ActivityData data)
    {
        name = data.name;
        descrition = data.descrition;
        sprite = data.sprite;
        
        rewardType = data.rewardType;
        effectType = data.effectType;
        
        reward = data.reward;
        energie = data.energie;
    }
}

public enum RewardType
{
    Multiplicateur,
    Argent,
    Energy
}

public enum EffectType
{
    None,
    Left,
    Right,
    Double
}