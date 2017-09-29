using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveLoad : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public TimeManager TimeManager;
    public UIUpdater UIUpdater;

    private void Awake()
    {
        Load();
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
    }

    public void Load()
    {

        using(ES2Reader reader = ES2Reader.Create("Save.imp"))
        {
            TimeManager.month = reader.Read<int>();
            print(TimeManager.month);
            TimeManager.day = reader.Read<int>();
        }

        InventoryManager.inventory = ES2.LoadList<Vector2>("SaveInv.imp");

    }
}


