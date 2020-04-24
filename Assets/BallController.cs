using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public SpriteRenderer spr;
    private bool fin;
    public Sprite south;
    public Sprite north;
    public bool ballPole; // false: north true: south

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.UnloadSceneAsync("ReloadScene");
        fin = false;
        ballPole = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fin == true){
            SceneManager.LoadScene("ReloadScene");
        }
        if(ballPole == true){
            spr.sprite = south;
        }
        else{
            spr.sprite = north;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            fin = true;
            Debug.Log("finished");
        }
        if (collision.gameObject.tag == "Mutator")
        {
            ballPole = !ballPole;
            Debug.Log("inverting pole");
        }
    }
}
