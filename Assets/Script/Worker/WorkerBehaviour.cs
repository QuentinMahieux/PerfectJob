using System;
using UnityEngine;
using UnityEngine.UI;

public class WorkerBehaviour : MonoBehaviour
{
    public Worker worker;
    public bool permanentEmotion;

    [Header("Visual")]
    public SpriteRenderer skin;
    public SpriteRenderer hair;
    public SpriteRenderer eye;
    public SpriteRenderer body;
    public SpriteRenderer leg;
    public SpriteRenderer foot;

    [Header("Emotion")] 
    public Image emotionVisual;
    
    public Sprite happy;
    public Sprite medium;
    public Sprite sad;
    public Sprite dead;
    

    public Rigidbody2D rb;

    protected virtual void Start()
    {
        emotionVisual.gameObject.SetActive(permanentEmotion);
    }

    protected void LookEmotion(int currentEnergie, int maxEnergie)
    {
        emotionVisual.gameObject.SetActive(true);
        if (currentEnergie > maxEnergie / 2 + maxEnergie / 4)
        {
            emotionVisual.sprite = happy;
        }
        else if (currentEnergie <= maxEnergie / 2 - maxEnergie / 4 && currentEnergie > 0)
        {
            emotionVisual.sprite = sad;
        }
        else if (currentEnergie <= 0)
        {
            emotionVisual.sprite = dead;
        }
        else 
        {
            emotionVisual.sprite = medium;
        }
    }

    protected virtual void Update() { }

    public void Instantiate(Worker newWorker)
    {
        worker = newWorker;

        skin.sprite = newWorker.skin;
        skin.color = newWorker.skinColor;
        
        hair.sprite = newWorker.hair;
        hair.color = newWorker.hairColor;
        
        eye.sprite = newWorker.eye;
        eye.color = newWorker.eyeColor;
        
        body.sprite = newWorker.body;
        body.color = newWorker.bodyColor;
        
        leg.sprite = newWorker.leg;
        leg.color = newWorker.legColor;
        
        foot.sprite = newWorker.foot;
        foot.color = newWorker.footColor;
    }

}
