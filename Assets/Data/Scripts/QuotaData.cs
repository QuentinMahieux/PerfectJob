using UnityEngine;

[CreateAssetMenu(fileName = "QuotaData", menuName = "Scriptable Objects/QuotaData")]
public class QuotaData : ScriptableObject
{
    public int moneyRequest = 100;
    public ActivityData[] unlockActivity;
}
