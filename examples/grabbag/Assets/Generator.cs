using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject colorCubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPoint = transform.position;
        float numCubes = 10;
        for (int x = 0; x < numCubes; x++)
        {
            for (int y = 0; y < numCubes; y++)
            {
                Vector3 pos = startPoint + new Vector3(x, 0, y);

                GameObject cube = Instantiate(colorCubePrefab, pos, Quaternion.identity);
                ColorCubeScript ccs = cube.GetComponent<ColorCubeScript>();
                ccs.xIndex = x;
                ccs.yIndex = y;
                Renderer rend = cube.GetComponentInChildren<Renderer>();
                float pNoise = Mathf.PerlinNoise(x * 0.05f, y * 0.05f);
                rend.material.color = Color.HSVToRGB(pNoise, 0.8f, 1);

                cube.transform.localScale = new Vector3(1, pNoise * 5, 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
