using UnityEngine;

public class WorkerCreator : MonoBehaviour
{
    [Header("Spawn")] 
    public int numberWorker;
    public WorkerElement prefabWorker;
    
    [Header("DataBases")]
    public string[] names;
    public Vector2 energieTranche;

    public Color[] skins;
    
    public Sprite[] hairs;
    public Color[] hairColors;
    
    public Sprite[] eyes;
    public Color[] eyesColors;
    
    public Sprite[] habits;
    public Color[] habitColors;
    
    void Start()
    {
        MakeWorker(numberWorker);
    }

    //Choix des elements du travailleur
    void MakeWorker(int nbrWorker)
    {
        string name = " ";
        int energy = 0;
        
        Color skin = new Color();

        Sprite hair = null;
        Color hairColor = new Color();
    
        Sprite eye = null;
        Color eyeColor = new Color();
         
        Sprite habit = null;
        Color habitColor = new Color();
        
        
        for (int i = 0; i < numberWorker; i++)
        {
            name = names[Random.Range(0, names.Length)];
            energy = Random.Range(100, 200);
            
            skin = skins[Random.Range(0, skins.Length)];
            
            hair = hairs[Random.Range(0, hairs.Length)];
            hairColor = hairColors[Random.Range(0, hairs.Length)];
            
            eye = eyes[Random.Range(0, eyes.Length)];
            eyeColor = eyesColors[Random.Range(0, eyes.Length)];
            
            
            habit = habits[Random.Range(0, habits.Length)];
            habitColor = habitColors[Random.Range(0, habitColors.Length)];
            
            CreateWorker(name, energy, hair, eye, habit, habitColor, skin, hairColor, eyeColor);
        }
    }

    //Génération du travailleur
    void CreateWorker(string name, int energy, Sprite hair, Sprite eye, Sprite habit, Color habitColor, Color skin, Color hairColor, Color eyesColor)
    {
        Worker newWorker = new Worker();
        
        newWorker.name = name;
        newWorker.energy = energy;
        
        newWorker.skin = skin;
        
        newWorker.hair = hair;
        newWorker.hairColor = hairColor;
        
        newWorker.eye = eye;
        newWorker.eyeColor = eyesColor;
        
        newWorker.habit = habit;
        newWorker.habitColor = habitColor;
        
        
        WorkerElement workerElement = Instantiate(prefabWorker,null);
        workerElement.Instantiate(newWorker);
        
    }
}
[System.Serializable]
public class Worker
{
    [Header("Attributes")] 
    public string name;

    [Header("Statistique")]
    public int energy;

    [Header("Physique")] 
    public Color skin;
    
    public Sprite hair;
    public Color hairColor;
    
    public Sprite eye;
    public Color eyeColor;

    public Sprite habit;
    public Color habitColor;
}