using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = gameObject.GetComponent<Renderer>();
        rend.material.color = new Color(Random.value, Random.value, Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
