using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : MonoBehaviour
{

    public void Sleep()
    {
        SpawnManager.instance.AddUI("Sleeping");
    }
}
