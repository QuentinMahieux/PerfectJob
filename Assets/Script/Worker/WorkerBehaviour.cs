using UnityEngine;

public class WorkerBehaviour : MonoBehaviour
{
    public Worker worker;

    public SpriteRenderer skin;
    public SpriteRenderer hair;
    public SpriteRenderer eye;
    public SpriteRenderer habit;

    public Rigidbody2D rb;

    public void Instantiate(Worker newWorker)
    {
        worker = newWorker;

        skin.color = newWorker.skin;
        
        hair.sprite = newWorker.hair;
        hair.color = newWorker.hairColor;
        
        eye.sprite = newWorker.eye;
        eye.color = newWorker.eyeColor;
        
        habit.sprite = newWorker.habit;
        habit.color = newWorker.habitColor;
    }

}
