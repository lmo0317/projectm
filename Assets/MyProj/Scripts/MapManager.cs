using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(Resources.Load("map/game/sector/sector1"), new Vector3(0, 0, i*10), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
