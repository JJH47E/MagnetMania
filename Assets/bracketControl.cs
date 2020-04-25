using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bracketControl : MonoBehaviour
{
    public SpriteRenderer spr;
    public SpriteRenderer spr2;
    public Sprite south;
    public Sprite north;
    public bool bracketPole; // false: north true: south

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bracketPole == false){
            spr.sprite = north;
            spr2.sprite = north;
        }
        else{
            spr.sprite = south;
            spr2.sprite = south;
        }
    }
}
