using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public int maxX, maxY;
    public List<GameObject> coins;
    public Sprite coin1, coin2, coin3, coin4, coin5;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyCoins();
            InitCoins();
            //MatchCheck();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MatchCheck();
        }
    }

    void InitCoins()
    {
        int startX = maxX;
        int startY = maxY;
        for (int i = maxX * maxY; i > 0; i--)
        {
            GameObject go = Instantiate(Resources.Load("Coin")) as GameObject;
            Transform coinPos = go.GetComponent<Transform>();
            Coin coin = go.GetComponent<Coin>();
            SpriteRenderer coinSR = go.GetComponent<SpriteRenderer>();

            coinPos.position = new Vector2(startX, startY);
            coin.type = Random.Range(1,6);
            switch (coin.type)
            {
                case 1:
                    coinSR.sprite = coin1;

                    break;
                case 2:
                    coinSR.sprite = coin2;

                    break;
                case 3:
                    coinSR.sprite = coin3;

                    break;
                case 4:
                    coinSR.sprite = coin4;

                    break;
                case 5:
                    coinSR.sprite = coin5;
                    break;
            }
            if (startX > 1)
            {
                startX--;
            }
            else
            {
                startX = maxX;
                startY--;
            }
        }
    }

    void DestroyCoins()
    {
        ListUpdate();
        foreach (GameObject go in coins)
        {
            DestroyObject(go);
        }
        coins.Clear();
    }

    bool EmptyCheck(Vector2 pos)
    {
        bool empty = true;
        Collider2D[] coll = Physics2D.OverlapCircleAll(pos, .5f);

        if (coll.Length > 0)
        {
            empty = false;
        }
        return empty;
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

    void MatchCheck()
    {
        int startX = maxX;
        int startY = maxY;
        int type = 0;
        int count = 0;
        int iteration = 0;
        List<GameObject> row = new List<GameObject>();

        for(int x = 1; x <= maxX; x++)
        {
            GameObject go = GetCoin(new Vector2(x, startY));
            row.Add(go);
        }

        foreach (GameObject coin in row)
        {
            if (type == 0)
            {
                type = coin.GetComponent<Coin>().type;
                count++;
            }
            else if(type == coin.GetComponent<Coin>().type)
            {
                count++;
            }
            else if (type != coin.GetComponent<Coin>().type)
            {
                if (count >= 3)
                {

                    for(int i = 0; i < count; i++)
                    {
                        DestroyObject(row[iteration-1-i]);
                    }
                }
                type = coin.GetComponent<Coin>().type;
                count = 1;
            }
            
            print("type: " + type + ", count: " + count);
            iteration++;
        }

        if (count >= 3)
        {

            for (int i = 0; i < count; i++)
            {
                DestroyObject(row[iteration - 1 - i]);
            }
        }

    }

    void Matched()
    {

    }

    void ListUpdate()
    {
        coins.Clear();
        coins.AddRange(GameObject.FindGameObjectsWithTag("Coin"));
    }
}
