using System;
using TMPro;
using Unity.Android.Gradle;
using UnityEngine;

public class ActivityElement : Grab
{
    [Header("Activity Element")]
    public ActivityDataInstance ActivityDataInstance;
    [Header("Attributes")]
    public TMP_Text TextReward;
    public TMP_Text TextEnergie;

    public GameObject leftEffect;
    public GameObject rightEffect;
    
    [Header("")]
    [Header("PopUp")]
    public float scaleLine = 0.5f;

    public float offsetPopUp = 0.07f;

    [Header("Générale")]
    public GameObject popUpParent;

    public SpriteRenderer icon;
    public SpriteRenderer background;

    [Header("Name")] 
    public GameObject nameParent;
    public TMP_Text textName;
    public SpriteRenderer popUpname;
    
    [Header("Descrition")] 
    public GameObject descritionParent;
    public TMP_Text textDescription;
    public SpriteRenderer popUpDescrition;
    
    [Header("Effect")] 
    public GameObject effectParent;
    public TMP_Text texteffect;
    public SpriteRenderer popUpeffect;

    public SlotActivity currentSlot;
    [SerializeField] private int rewardBonus = 0;
    
    void Start()
    {
        
        popUpParent.gameObject.SetActive(false);
    }

    protected override void Update()
    {
        base.Update();
    }

    public void Instanciate(ActivityDataInstance newActivityDataInstance)
    {
        ActivityDataInstance = newActivityDataInstance;

        textDescription.text = ActivityDataInstance.descrition;
        textName.text = ActivityDataInstance.name;
        icon.sprite = ActivityDataInstance.sprite;

        texteffect.text = SetEffect(ActivityDataInstance);
        
        TextReward.text = ActivityDataInstance.reward.ToString();
        TextEnergie.text = ActivityDataInstance.energie.ToString();

        leftEffect.gameObject.SetActive(false);
        rightEffect.gameObject.SetActive(false);
        if (ActivityDataInstance.effectType == EffectType.Left || ActivityDataInstance.effectType == EffectType.Double) leftEffect.gameObject.SetActive(true);
        if (ActivityDataInstance.effectType == EffectType.Right || ActivityDataInstance.effectType == EffectType.Double)  rightEffect.gameObject.SetActive(true);
        
        ScalePopUp(popUpDescrition.gameObject, textDescription,  scaleLine);
        ScalePopUp(popUpname.gameObject, textName,  scaleLine);
        ScalePopUp(popUpeffect.gameObject, texteffect,  scaleLine);
        
        SetGap(popUpname, popUpDescrition,descritionParent, offsetPopUp);
        SetGap(popUpDescrition, popUpeffect,effectParent, offsetPopUp);

        rewardBonus = 1;
    }

    string SetEffect(ActivityDataInstance data)
    {
        if (data.rewardType == RewardType.Multiplicateur)
        {
            return "Multiplie part x" + data.reward.ToString() + " les activités affecter.";
        }
        return "Donne +" + data.reward.ToString() + " " + data.rewardType.ToString().ToLower() + ".";
    }
    
    void ScalePopUp(GameObject popUp, TMP_Text popUpText, float popUpScale)
    {
        popUpText.ForceMeshUpdate(); 
        int ligne = popUpText.textInfo.lineCount - 1;
        
        popUp.transform.localScale += new Vector3(0, popUpScale * ligne, 0);
        popUp.transform.localPosition -= new Vector3(0, (popUpScale * ligne)/2, 0);
    }

    void SetGap(SpriteRenderer target, SpriteRenderer place,GameObject parent, float gap)
    {
        float targetDownEdge = target.bounds.min.y;
        float myHalfWidth = place.bounds.extents.y;
        
        float pivotOffsetY = place.bounds.center.y - parent.transform.position.y;


        Vector3 newPos = parent.transform.position;
        newPos.y = targetDownEdge - myHalfWidth - gap - pivotOffsetY;
        parent.transform.position = newPos;
    }

    public void SetEffect(int effect, bool isAdd)
    {
        if(ActivityDataInstance.rewardType == RewardType.Multiplicateur) return;

        if (isAdd) rewardBonus = effect;
        else rewardBonus = 1;
        
        Debug.Log(rewardBonus);
        
        TextReward.text = (ActivityDataInstance.reward * rewardBonus).ToString();
    }

    public int FindBonus(EffectType direction)
    {
        if (ActivityDataInstance.rewardType == RewardType.Multiplicateur)
        {
            if (ActivityDataInstance.effectType == EffectType.Double  || direction == ActivityDataInstance.effectType) 
                return ActivityDataInstance.reward;
        }

        return 0;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(currentSlot) return;
        
        SlotActivity slot = other.gameObject.GetComponent<SlotActivity>();
        if (slot == null) return;
        
        currentSlot = slot.AddActivity(this);;
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        SlotActivity slot = other.gameObject.GetComponent<SlotActivity>();
        if (slot == null) return;

        if (slot == currentSlot)
        {
            currentSlot.RemoveActivity(this);
            currentSlot = null;
        }
    }

    #region Mouse

    private void OnMouseEnter()
    {
        if(!isDraggind) popUpParent.gameObject.SetActive(true);
        
        if(currentSlot != null) currentSlot.Outline(true);
    }
    
    private void OnMouseExit()
    {
        popUpParent.gameObject.SetActive(false);
        
        if(currentSlot != null) currentSlot.Outline(false);
    }
    
    protected override void  OnMouseDown()
    {
        base.OnMouseDown();
        popUpParent.gameObject.SetActive(false);
        
        if(currentSlot != null) currentSlot.Outline(false);
        
    }

    private void OnMouseOver()
    {
        if(currentSlot != null) currentSlot.Outline(!isDraggind);
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        popUpParent.gameObject.SetActive(true);
        
        if(currentSlot != null) transform.position = currentSlot.transform.position;

    }

    #endregion

}
