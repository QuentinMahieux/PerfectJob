using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorkerCreator : MonoBehaviour
{
    [Header("Spawn")] 
    public Transform spawnPoint;
    public int numberWorker;
    public WorkerBehaviour prefabWorker;
    
    [Header("DataBases")]
    public string[] names;
    public Vector2 energieTranche;

    public Sprite[] skins;
    public Color[] skinColors;
    
    public Sprite[] hairs;
    public Color[] hairColors;
    
    public Sprite[] eyes;
    public Color[] eyesColors;
    
    public Sprite[] bodys;
    public Color[] bodyColors;
    
    public Sprite[] legs;
    public Color[] legColors;
    
    public Sprite[] foots;
    public Color[] footColors;

    
    void Start()
    {
        MakeWorker(numberWorker);
    }

    //Choix des elements du travailleur
    void MakeWorker(int nbrWorker)
    {
        string name = " ";
        int energy = 0;

        Sprite skin = null;
        Color skinColor = new Color();

        Sprite hair = null;
        Color hairColor = new Color();
    
        Sprite eye = null;
        Color eyeColor = new Color();
         
        Sprite body = null;
        Color bodyColor = new Color();
        
        Sprite leg = null;
        Color legColor = new Color();
        
        Sprite foot = null;
        Color footColor = new Color();
        
        
        for (int i = 0; i < numberWorker; i++)
        {
            name = names[Random.Range(0, names.Length)];
            energy = (int)Random.Range(energieTranche.x, energieTranche.y);
            
            skin = skins[Random.Range(0, skins.Length)];
            skinColor = skinColors[Random.Range(0, skinColors.Length)];
            
            hair = hairs[Random.Range(0, hairs.Length)];
            hairColor = hairColors[Random.Range(0, hairColors.Length)];
            
            eye = eyes[Random.Range(0, eyes.Length)];
            eyeColor = eyesColors[Random.Range(0, eyesColors.Length)];
            
            body = bodys[Random.Range(0, bodys.Length)];
            bodyColor = bodyColors[Random.Range(0, bodyColors.Length)];
            
            leg = legs[Random.Range(0, legs.Length)];
            legColor = legColors[Random.Range(0, legColors.Length)];
            
            foot = foots[Random.Range(0, foots.Length)];
            footColor = footColors[Random.Range(0, footColors.Length)];
            
            CreateWorker(name, energy,hair,eye,body,skin,leg,foot,bodyColor,skinColor,hairColor,eyeColor,legColor,footColor);
        }
    }

    //Génération du travailleur
    void CreateWorker(string name, int energy, Sprite hair, Sprite eye, Sprite body, Sprite skin, Sprite leg, Sprite foot, Color bodyColor, Color skinColor, Color hairColor, Color eyesColor, Color legColor, Color footColor)
    {
        Worker newWorker = new Worker();
        
        newWorker.id = Guid.NewGuid().ToString();
        
        newWorker.name = name;
        newWorker.energy = energy;
        newWorker.currentEnergy = energy;
        
        newWorker.skin = skin;
        newWorker.skinColor = skinColor;
        
        newWorker.hair = hair;
        newWorker.hairColor = hairColor;
        
        newWorker.eye = eye;
        newWorker.eyeColor = eyesColor;
        
        newWorker.body = body;
        newWorker.bodyColor = bodyColor;
        
        newWorker.leg = leg;
        newWorker.legColor = legColor;
        
        newWorker.foot = foot;
        newWorker.footColor = footColor;
        
        GameManager.instance.workers.Add(newWorker);
        
        WorkerBehaviour workerElement = Instantiate(prefabWorker, spawnPoint.position, spawnPoint.rotation, transform.parent);
        workerElement.Instantiate(newWorker);
    }
}
[System.Serializable]
public class Worker
{
    [Header("Attributes")] 
    public string id;
    public string name;

    [Header("Statistique")]
    public int energy;
    public int currentEnergy;

    [Header("Physique")]
    public Sprite skin;
    public Color skinColor;
    
    public Sprite hair;
    public Color hairColor;
    
    public Sprite eye;
    public Color eyeColor;

    public Sprite body;
    public Color bodyColor;
    
    public Sprite leg;
    public Color legColor;
    
    public Sprite foot;
    public Color footColor;
}