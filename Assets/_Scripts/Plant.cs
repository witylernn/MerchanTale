using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Plant : MonoBehaviour
{
    public int life, plantType;
    // Use this for initialization

    private void Start()
    {
        if (PlantingManager.plantList.Contains(this.gameObject))
        {
            print("do nothing");
        }
        else
        {
            PlantingManager.plantList.Add(this.gameObject);
        }
    }
}
