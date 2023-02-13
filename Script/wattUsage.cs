using UnityEngine;


[System.Serializable]
public class WattUsage
{
    public EletronicalUsageData eletronicalUsageData;
    [HideInInspector]
    public float watt;
    [HideInInspector]
    public int totalUsage;
    public string name;
}