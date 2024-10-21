using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float energy;
    public float restingTime;
    public float timer;
    public Vector2 positionToMove;
    public float speedMove;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (energy <= 0)
        {
            timer = timer + Time.deltaTime;
            if (timer >= restingTime)
            {
                energy = 10f;
                timer = 0f;
            }           
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, positionToMove, speedMove * Time.deltaTime);
        }
    }
    public void SetNewPosition(Vector2 newPosition)
    {
        positionToMove = newPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            SetNewPosition(collision.GetComponent<NodeControl>().GetAdjacentNode().transform.position);
            energy = energy - 1;            
        }
    }
}
