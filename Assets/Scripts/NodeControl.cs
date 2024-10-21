using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public List<NodeControl> listAdjacentNodes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddAdjacentNode(NodeControl adjacentNode)
    {
        listAdjacentNodes.Add(adjacentNode);
    }
    public NodeControl GetAdjacentNode()
    {
        return listAdjacentNodes[Random.Range(0, listAdjacentNodes.Count)];
    }
}
