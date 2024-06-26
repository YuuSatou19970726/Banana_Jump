using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    private GameObject[] bgs;
    private float height;
    private float highest_Y_Pos;

    void Awake()
    {
        bgs = GameObject.FindGameObjectsWithTag(Tags.BACKGROUND);
    }

    // Start is called before the first frame update
    void Start()
    {
        height = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y;

        highest_Y_Pos = bgs[0].transform.position.y;

        for (int i = 0; i < bgs.Length; i++)
        {
            if (bgs[i].transform.position.y > highest_Y_Pos)
                highest_Y_Pos = bgs[i].transform.position.y;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Tags.BACKGROUND)
        {
            // we collided with the highest Y BG
            if (target.transform.position.y >= highest_Y_Pos)
            {
                Vector3 temp = target.transform.position;

                for (int i = 0; i < bgs.Length; i++)
                {
                    // is the BG at "i" index is NOT active in the hierachy
                    if (!bgs[i].activeInHierarchy)
                    {
                        temp.y += height;
                        bgs[i].transform.position = temp;
                        bgs[i].gameObject.SetActive(true);

                        highest_Y_Pos = temp.y;
                    }
                }
            }
        }
    }
}
