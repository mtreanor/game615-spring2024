using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCubeScript : MonoBehaviour
{
    public int xIndex;
    public int yIndex;

    float offsetX = 0;
    float offsetY = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //offsetX += Time.deltaTime * 0.1f;
        //offsetY += Time.deltaTime * 0.4f;

        //float pNoise = Mathf.PerlinNoise(xIndex * 0.05f + offsetX, yIndex * 0.05f + offsetY);
        //transform.localScale = new Vector3(1, pNoise * 5, 1);

        //Renderer rend = gameObject.GetComponentInChildren<Renderer>();
        //rend.material.color = Color.HSVToRGB(pNoise, 0.8f, 1);
    }
}
