using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("L****** x:" + this.transform.position.x + " y:" + this.transform.position.y);
    }
}
