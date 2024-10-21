using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPartControl : MonoBehaviour
{
    private SpriteRenderer _compSpriteRenderer;

    private void Awake()
    {
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSprite(Sprite newSprite)
    {
        _compSpriteRenderer.sprite = newSprite;
    }
}
