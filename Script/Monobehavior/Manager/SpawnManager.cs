using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance {get; private set; }

    private void Awake() {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);
    }
    [SerializeField] private Spawn[] spawns;

    public GameObject Add(string name)
    {
        Spawn spawn = Array.Find(spawns, spawn => spawn.name == name);
        
        GameObject gameObject = Instantiate(spawn.prefab, spawn.location, Quaternion.identity);
        return gameObject;
    }

    public GameObject AddUI(string name)
    {
        Spawn spawn = Array.Find(spawns, spawn => spawn.name == name);
        Transform UICanvas = GameObject.Find("Canvas").GetComponent<Transform>();
        GameObject gameObject = Instantiate(spawn.prefab, UICanvas);
        gameObject.transform.localPosition = spawn.location;
        return gameObject;
    }

}
