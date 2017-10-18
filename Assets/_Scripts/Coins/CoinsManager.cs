using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public int maxX, maxY;
    public List<GameObject> coins;
    public List<GameObject> toRemove;
    public Sprite coin1, coin2, coin3, coin4, coin5;

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
            for (int i = 1; i <= maxY; i++)
            {
                print("checking row: " + i);
                RowCheck(i);
            }

            for (int i = 1; i <= maxX; i++)
            {
                print("checking column: " + i);
                ColumnCheck(i);
            }

            foreach (GameObject go in toRemove)
            {
                DestroyObject(go);
            }
            toRemove.Clear();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 1; i <= maxY; i++)
            {
                FallCoins(i);
            }
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

    void RowCheck(int rowNum)
    {
        int startX = maxX;
        int startY = maxY;
        int type = 0;
        int count = 0;
        int iteration = 0;
        List<GameObject> row = new List<GameObject>();

        for(int x = 1; x <= maxX; x++)
        {
            GameObject go = GetCoin(new Vector2(x, rowNum));
            row.Add(go);
        }

        foreach (GameObject coin in row)
        {

            if(coin == null)
            {
                count = 1;
                type = 0;
                iteration++;
                continue;
            }
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
                        //DestroyObject(row[iteration-1-i]);
						Debug.Log(row[iteration-1-i]);
                        toRemove.Add(row[iteration-1-i]);
                    }
                }
                type = coin.GetComponent<Coin>().type;
                count = 1;
            }
            
            //print("type: " + type + ", count: " + count);
            iteration++;
        }

        if (count >= 3)
        {

            for (int i = 0; i < count; i++)
            {
                //DestroyObject(row[iteration - 1 - i]);
                toRemove.Add(row[iteration - 1 - i]);

            }
        }

    }

    void ColumnCheck(int colNum)
    {
        int startX = maxX;
        int startY = maxY;
        int type = 0;
        int count = 0;
        int iteration = 0;
        List<GameObject> col = new List<GameObject>();

        for (int y = 1; y <= maxY; y++)
        {
            GameObject go = GetCoin(new Vector2(colNum, y));
            col.Add(go);
        }

        foreach (GameObject coin in col)
        {
            if (coin == null)
            {
                count = 1;
                type = 0;
                iteration++;
                continue;
            }

            if (type == 0)
            {
                type = coin.GetComponent<Coin>().type;
                count++;
            }
            else if (type == coin.GetComponent<Coin>().type)
            {
                count++;
            }
            else if (type != coin.GetComponent<Coin>().type)
            {
                if (count >= 3)
                {

                    for (int i = 0; i < count; i++)
                    {
                        //DestroyObject(row[iteration-1-i]);

                        toRemove.Add(col[iteration - 1 - i]);
                    }
                }
                type = coin.GetComponent<Coin>().type;
                count = 1;
            }

            //print("type: " + type + ", count: " + count);
            iteration++;
        }

        if (count >= 3)
        {

            for (int i = 0; i < count; i++)
            {
                //DestroyObject(col[iteration - 1 - i]);
                toRemove.Add(col[iteration - 1 - i]);
            }
        }
    }

    void FallCoins(int rowNum)
    {
        List<GameObject> row = new List<GameObject>();

        for (int x = 1; x <= maxX; x++)
        {
            GameObject go = GetCoin(new Vector2(x, rowNum));
            if (go == null)
            {
                VerticalDrop(new Vector2(x, rowNum));
                //GameObject above = GetCoin(new Vector2(x, rowNum + 1));
                //above.GetComponent<Transform>().position = new Vector2(x, rowNum);

            }
            row.Add(go);
        }

        //foreach (GameObject coin in row)
        //{
        //    Transform coinPos = coin.GetComponent<Transform>();
        //    GameObject above = GetCoin(new Vector2(coinPos.position.x, coinPos.position.y+1));
            
        //    if (above == null)
        //    {
        //        print("yes!");
        //    }
        //}
    }

    void VerticalDrop(Vector2 coin)
    {
        for (int i = Mathf.RoundToInt(coin.y); i <= maxY; i++)
        {
            GameObject go = GetCoin(new Vector2(coin.x, i));
            if(go != null)
            {
                go.transform.position = coin;
                break;
            }
        }
    }

    void ListUpdate()
    {
        coins.Clear();
        coins.AddRange(GameObject.FindGameObjectsWithTag("Coin"));
    }
}
