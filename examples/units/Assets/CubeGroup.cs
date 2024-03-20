using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGroup : MonoBehaviour
{
    BoxCollider[] boxes;
    Vector3 sum = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        boxes = GetComponentsInChildren<BoxCollider>();

        for (int i = 0; i < boxes.Length; i++)
        {
            sum += boxes[i].bounds.center;
        }
        sum /= boxes.Length;


        GameObject thing = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Destroy(thing.GetComponent<SphereCollider>());
        thing.transform.position = sum;
        thing.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
