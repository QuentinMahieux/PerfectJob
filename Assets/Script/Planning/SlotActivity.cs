using System;
using UnityEngine;

public class SlotActivity : MonoBehaviour
{
    public ActivityElement currentActivity;
    [SerializeField] private SlotActivity slotLeft;
    [SerializeField] private SlotActivity slotRight;

    public GameObject taskView;
    public GameObject outline;

    private void Start()
    {
        taskView.SetActive(false);
        outline.SetActive(false);
    }

    public SlotActivity AddActivity(ActivityElement activity)
    {
        if(currentActivity != null) return null;
        currentActivity = activity;
        activity.gameObject.transform.position = transform.position;
        
        Effect(activity.ActivityDataInstance, this);
        Refresh();

        return this;
    }

    public void RemoveActivity(ActivityElement activity)
    {
        if(currentActivity != activity) return;
        
        activity.SetEffect(1,false);

        currentActivity = null;
        
        Refresh();
        Outline(false);
    }
    
    
    public void Outline(bool isOutline)
    {
        if(!currentActivity) return;
        
        var effectType = currentActivity.ActivityDataInstance;
        
        if(slotLeft && (effectType.effectType == EffectType.Left || effectType.effectType == EffectType.Double)) slotLeft.outline.SetActive(isOutline);
        if(slotRight && (effectType.effectType == EffectType.Right || effectType.effectType == EffectType.Double)) slotRight.outline.SetActive(isOutline);
    }

    void Effect(ActivityDataInstance data, SlotActivity slot,bool isAdd = true)
    {
        if(!isAdd && currentActivity) currentActivity.SetEffect(1, false);
        
        if (data.rewardType != RewardType.Multiplicateur)
        {
            int multi = 0;
            
            if (slot.slotLeft)
                if (slot.slotLeft.currentActivity)
                    multi += slot.slotLeft.currentActivity.FindBonus(EffectType.Right);
            if (slot.slotRight)
                if (slot.slotRight.currentActivity)
                    multi += slot.slotRight.currentActivity.FindBonus(EffectType.Left);
            if(multi != 0) currentActivity.SetEffect(multi, true);
            else currentActivity.SetEffect(1, false);
        }
    }

    void Refresh()
    {
        if (slotLeft)
            if(slotLeft.currentActivity)
            {
                slotLeft.Effect(slotLeft.currentActivity.ActivityDataInstance, slotLeft);
            }
        if (slotRight) 
            if(slotRight.currentActivity)
            {
                slotRight.Effect(slotRight.currentActivity.ActivityDataInstance, slotRight);
            }
    }
}
