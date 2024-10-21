using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorControl : MonoBehaviour
{
    public TextAsset txtMap;
    public string[] arrayRowsInformation;
    public string[] arrayColumnsInformation;
    public Sprite[] arrayMapSprites;
    public GameObject objectMapPrefab;
    public Vector2 positionInitialMapParts;
    public Vector2 separationFromMapParts;
    // Start is called before the first frame update
    void Start()
    {
        DrawMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DrawMap()
    {
        int index = 0;
        GameObject currentMapPart;
        Vector2 positionToCreateMapPart;
        arrayRowsInformation = txtMap.text.Split('\n');
        for (int i = 0; i < arrayRowsInformation.Length; ++i) 
        {
            arrayColumnsInformation = arrayRowsInformation[i].Split(';');
            for (int j = 0; j < arrayColumnsInformation.Length; ++j) 
            {
                index = int.Parse(arrayColumnsInformation[j]);

                positionToCreateMapPart = new Vector2(positionInitialMapParts.x + separationFromMapParts.x * j, positionInitialMapParts.y - separationFromMapParts.y * i);

                currentMapPart = Instantiate(objectMapPrefab, positionToCreateMapPart, transform.rotation);
                currentMapPart.GetComponent<MapPartControl>().SetSprite(arrayMapSprites[index]);

                currentMapPart.transform.SetParent(this.transform);
            }
            
        }
    }
}
