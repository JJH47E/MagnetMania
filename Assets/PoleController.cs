using UnityEngine;

public class PoleController : MonoBehaviour
{
    public bool Pole; // false: north true: south

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "Ball"){
            Pole = gameObject.GetComponent<BallController>().ballPole;
        }
        else if(gameObject.tag == "Bracket"){
            Pole = gameObject.GetComponent<bracketControl>().bracketPole;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Ball"){
            Pole = gameObject.GetComponent<BallController>().ballPole;
        }
        else if(gameObject.tag == "Bracket"){
            Pole = gameObject.GetComponent<bracketControl>().bracketPole;
        }
        Debug.Log("updated Poles");
    }

}
