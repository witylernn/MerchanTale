using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DoozyUI;

public class PlantingManager : MonoBehaviour
{
    public Sprite plant1, plant2, plant3;
    public List<GameObject> plantList;
    public Color color1, color2, color3;
    public InventoryManager InventoryManager;
    public static PlantingManager instance;
    public static bool poor;

    private void Start()
    {
        plantList = new List<GameObject>();
        instance = this;

    }
    public void Plant(int plantType)
    {
        GameObject flower = Instantiate(Resources.Load("plant")) as GameObject;
        plantList.Add(flower);
        flower.transform.parent = Spot.parent.transform;
        flower.transform.localPosition = new Vector3(0, -.25f, 0);
        ParticleSystem.MainModule main = flower.transform.GetChild(0).GetComponent<ParticleSystem>().main;

        switch (plantType)
        {
            case 1:
                flower.GetComponent<SpriteRenderer>().sprite = plant1;
                flower.GetComponent<Plant>().life = 1;
                flower.GetComponent<Plant>().plantType = 1;
                main.startColor = color1;
                break;
            case 2:
                flower.GetComponent<SpriteRenderer>().sprite = plant2;
                flower.GetComponent<Plant>().life = 2;
                flower.GetComponent<Plant>().plantType = 2;
                main.startColor = color2;
                break;
            case 3:
                flower.GetComponent<SpriteRenderer>().sprite = plant3;
                flower.GetComponent<Plant>().life = 3;
                flower.GetComponent<Plant>().plantType = 3;
                main.startColor = color3;
                break;
        }
        if (InventoryManager.CheckPoorness(plantType * 5))
        {
            UIManager.ShowNotification("Notif1", -1, false, "Uh-oh!", "It looks like your pocket is a little light. Get some more money and come back!");
            plantList.Remove(flower);
            DestroyObject(flower);
        }
        else
        {
            InventoryManager.InventoryAdd(plantType * 5, 0, false);
        }

    }

    public void AgePlants()
    {
        List<GameObject> removeList = new List<GameObject>();

        foreach (GameObject plant in plantList)
        {
            if (plant == null)
            {
                break;
            }
            plant.GetComponent<Plant>().life -= 1;

            if (plant.GetComponent<Plant>().life == 0)
            {
                removeList.Add(plant);
                GrownPlant(plant);
            }
        }

        foreach (GameObject plant in removeList)
        {
            plantList.Remove(plant);
        }
    }

    public static void PickPlant(GameObject spot)
    {
        GameObject plant = spot.transform.GetChild(0).gameObject;

        if(plant.GetComponent<Plant>().life <= 0)
        {
            //add gold
            instance.InventoryManager.InventoryAdd(plant.GetComponent<Plant>().plantType * 3, 0, true);
            //add plants 
            instance.InventoryManager.InventoryAdd(1, plant.GetComponent<Plant>().plantType, true);
            plant.GetComponent<Animator>().Play("Picked");
            instance.StartCoroutine(instance.KillPlant(plant));
        }
        else
        {
            print("still growing!");
        }
    }

    void GrownPlant(GameObject plant)
    {
        //DestroyObject(plant);
        plant.transform.GetChild(0).gameObject.SetActive(true);
    }

    IEnumerator KillPlant(GameObject plant)
    {
        plant.GetComponentInChildren<ParticleSystem>().Pause();
        yield return new WaitForSeconds(.6f);
        DestroyObject(plant);
    }
}
