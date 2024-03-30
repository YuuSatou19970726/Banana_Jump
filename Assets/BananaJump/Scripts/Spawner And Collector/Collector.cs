using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Tags.BACKGROUND || target.tag == Tags.PLATFORM ||
            target.tag == Tags.NORMAL_PUSH || target.tag == Tags.EXTRA_PUSH ||
            target.tag == Tags.BIRD_TAG)
        {
            target.gameObject.SetActive(false);
        }
    }
}
