using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public int[,] vs = new int[16, 12];
    private void Start()
    {
        print(vs.LongLength);
    }
}
