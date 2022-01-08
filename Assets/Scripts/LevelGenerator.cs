using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public float offset = 5f;
    public Material[] materials;

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x,z);

        if(pixelColor.a == 0)
        {
            return;
        }

        foreach(ColorToPrefab colorMapping in colorMappings)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, 0, z) * offset;
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }

    public void GenerateLabirynth()
    {
        for(int x = 0; x < map.width; x++)
        {
            for(int z = 0; z < map.height; z++)
            {
                GenerateTile(x, z);
            }
        }
        ColorChildren();
    }

    public void ColorChildren()
    {
        foreach(Transform child in transform)
        {
            if(child.CompareTag("Wall"))
            {
                child.GetChild(0).gameObject.GetComponent<Renderer>().material = materials[Random.Range(0, materials.Length)];
            }
        }
    }
}
