using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveLoad : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public PlantingManager PlantingManager;
    public TimeManager TimeManager;
    public UIUpdater UIUpdater;

    private void Awake()
    {
        //Load();
    }
    public void Save()
    {
        using (ES2Writer writer = ES2Writer.Create("Save.imp"))
        {
            writer.Write(TimeManager.month);
            writer.Write(TimeManager.day);

            writer.Save(false);
        }
        ES2.Save(InventoryManager.inventory, "SaveInv.imp");
        ES3.Save<GameObject>("test", PlantingManager.plantList[0]);
    }

    public void Load()
    {

        //using(ES2Reader reader = ES2Reader.Create("Save.imp"))
        //{
        //    TimeManager.month = reader.Read<int>();
        //    TimeManager.day = reader.Read<int>();
        //}

        //InventoryManager.inventory = ES2.LoadList<Vector2>("SaveInv.imp");
        //ES3.Load<GameObject>("test");

    }
}


