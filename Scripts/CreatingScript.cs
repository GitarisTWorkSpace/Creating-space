using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingScript : MonoBehaviour
{
    private Vector3 pos = new Vector3(0, 5, 0);
    public void CreatingBatton(GameObject obj)
    { 
        Instantiate(obj, pos, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
