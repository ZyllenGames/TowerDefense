using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] WayPointsTrans;

    private void Awake()
    {
        WayPointsTrans = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            WayPointsTrans[i] = transform.GetChild(i);
        }
    }
}
