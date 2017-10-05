using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int month, day;
    public PlantingManager PlantingManager;
    public UIUpdater UIUpdater;

    private void Start()
    {
        UIUpdater.DateChange(month,day);

    }

    public void ProgressDay()
    {
        print(month + "/" + day);
        if (day == 30)
        {
            if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                month++;
                day = 1;
                PlantingManager.AgePlants();
                UIUpdater.DateChange(month, day);
                return;
            }
        }
        else if (day == 31)
        {
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (month == 12)
                {
                    month = 1;
                    day = 1;
                    return;
                }
                month++;
                day = 1;
                PlantingManager.AgePlants();
                UIUpdater.DateChange(month, day);
                return;
            }

        }
        else if (day == 28)
        {
            if (month == 2)
            {
                month++;
                day = 1;
                PlantingManager.AgePlants();
                UIUpdater.DateChange(month, day);
                return;
            }
        }
        day++;
        PlantingManager.AgePlants();
        UIUpdater.DateChange(month, day);
    }


}
