using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphControl : MonoBehaviour
{
    public List<NodeControl> listAllNodes;
    public TextAsset textNodesPositions;
    public string[] arrayNodeRowsPositions;
    public string[] arrayNodeColumnsPositions;
    public GameObject objectNodePrefab;

    public TextAsset textNodesConnections;
    public string[] arrayNodeRowsConnections;
    public string[] arrayNodeColumnsConnections;

    public EnemyControl currentEnemy;
    // Start is called before the first frame update
    void Start()
    {
        DrawNodes();
        ConnectNodes();
        SetInitialNode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DrawNodes()
    {
        GameObject currentNode;
        arrayNodeRowsPositions = textNodesPositions.text.Split('\n');
        for(int i = 0; i < arrayNodeRowsPositions.Length; ++i)
        {
            arrayNodeColumnsPositions = arrayNodeRowsPositions[i].Split(';');
            Vector2 positionToCreate = new Vector2(float.Parse(arrayNodeColumnsPositions[0]), float.Parse(arrayNodeColumnsPositions[1]));
            currentNode = Instantiate(objectNodePrefab, positionToCreate, transform.rotation);
            currentNode.name = "NODE" + i.ToString();
            listAllNodes.Add(currentNode.GetComponent<NodeControl>());
        }
    }
    void ConnectNodes()
    {
        arrayNodeRowsConnections = textNodesConnections.text.Split('\n');
        for (int i = 0; i < listAllNodes.Count; ++i)
        {
            arrayNodeColumnsConnections = arrayNodeRowsConnections[i].Split(';'); 
            for(int j = 0; j < arrayNodeColumnsConnections.Length; ++j)
            {
                listAllNodes[i].AddAdjacentNode(listAllNodes[int.Parse(arrayNodeColumnsConnections[j])]);
            }
        }          
    }
    void SetInitialNode()
    {
        int position = Random.Range(0, listAllNodes.Count);
        currentEnemy.SetNewPosition(listAllNodes[position].gameObject.transform.position);
    }
}
