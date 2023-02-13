using UnityEngine;

[CreateAssetMenu(fileName = "New Eletronical", menuName = "Eletronical")]
public class EletronicalUsageData : ScriptableObject
{
    public float watt;
    public float totalUsage;

    public void Clear()
    {
        totalUsage = 0;
    }
}
