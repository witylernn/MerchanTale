using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int maxX, maxY;
    public Sprite coin1, coin2, coin3, coin4, coin5;

    public List<GameObject> toDelete = new List<GameObject>();

	void Start ()
    {
        Init();
	}
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            for(int y = 1; y<=maxY; y++)
            {
                for (int x = 1; x <= maxX; x++)
                {
                    MatchCheck(x, y);
                }
            }

            foreach (GameObject go in toDelete)
            {
                DestroyObject(go);
            }
            toDelete.Clear();

        }
    }

    void Init()
    {
        for (int y = 1; y <= maxY+1; y++)
        {
            for (int x = 1; x <= maxX+1; x++)
            {
                GameObject coin = Instantiate(Resources.Load("Coin")) as GameObject;
                coin.transform.position = new Vector2(x, y);
                print("placing coin at: " + x + ", " + y);
                AssignCoin(coin);
            }
        }
    }

    void AssignCoin(GameObject coin)
    {
        Coin coinScript = coin.GetComponent<Coin>();
        SpriteRenderer sr = coin.GetComponent<SpriteRenderer>();
        coinScript.type = Random.Range(1,6);

        if(coinScript.type == 1)
        {
            sr.sprite = coin1;
        }
        else if (coinScript.type == 2)
        {
            sr.sprite = coin2;
        }
        else if (coinScript.type == 3)
        {
            sr.sprite = coin3;
        }
        else if (coinScript.type == 4)
        {
            sr.sprite = coin4;
        }
        else if (coinScript.type == 5)
        {
            sr.sprite = coin5;
        }
    }

    void MatchCheck(int xPos, int yPos)
    {
        int tempType = 0;
        int coinType = 0;
        int count = 0;
        for (int x = 1; x <= maxX; x++)
        {
            GameObject coin = GetCoin(new Vector2(x, yPos));
            try
            {
                coinType = coin.GetComponent<Coin>().type;
            }
            catch (System.NullReferenceException)
            {
                //count = 1;
                if (count >= 3)
                {
                    print(count + " matched!");
                    for (int i = 1; i <= count; i++)
                    {
                        //DestroyObject(GetCoin(new Vector2(x - i, yPos)));
                        if (!toDelete.Contains(GetCoin(new Vector2(x - i, yPos))))
                        {
                            toDelete.Add(GetCoin(new Vector2(x - i, yPos)));
                        }

                    }
                }
                count = 1;
                continue;
            }

            if (tempType == coinType)
            {
                count++;
            }
            else
            {
                if (count >= 3)
                {
                    print(count + " matched!");
                    for (int i = 1; i <= count; i++)
                    {
                        //DestroyObject(GetCoin(new Vector2(x - i, yPos)));
                        if (!toDelete.Contains(GetCoin(new Vector2(x - i, yPos))))
                        {
                            toDelete.Add(GetCoin(new Vector2(x - i, yPos)));
                        }
                    }
                }
                count = 1;
            }
            tempType = coinType;
        }

        for (int y = 1; y <= maxY; y++)
        {
            GameObject coin = GetCoin(new Vector2(xPos, y));
            try
            {
                coinType = coin.GetComponent<Coin>().type;
            }
            catch (System.NullReferenceException)
            {
                //count = 1;
                if (count >= 3)
                {
                    print(count + " matched!");
                    for (int i = 1; i <= count; i++)
                    {
                        //DestroyObject(GetCoin(new Vector2(xPos, y - i)));
                        if(!toDelete.Contains(GetCoin(new Vector2(xPos, y - i))))
                        {
                            toDelete.Add(GetCoin(new Vector2(xPos, y - i)));
                        }
                    }
                }
                count = 1;
                continue;
            }

            if (tempType == coinType)
            {
                count++;
            }
            else
            {
                if (count >= 3)
                {
                    print(count + " matched!");
                    for (int i = 1; i <= count; i++)
                    {
                        //DestroyObject(GetCoin(new Vector2(xPos, y - i)));
                        if (!toDelete.Contains(GetCoin(new Vector2(xPos, y - i))))
                        {
                            toDelete.Add(GetCoin(new Vector2(xPos, y - i)));
                        }

                    }
                }
                count = 1;
            }
            tempType = coinType;
        }
    }

    GameObject GetCoin(Vector2 pos)
    {
        GameObject coin = null;
        Collider2D[] coll = Physics2D.OverlapCircleAll(pos, .5f);

        if (coll.Length > 0)
        {
            coin = coll[0].gameObject;
        }
        return coin;
    }
}
