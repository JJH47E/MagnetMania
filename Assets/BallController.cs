using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public SpriteRenderer spr;
    private bool fin;
    public Sprite south;
    public Sprite north;
    public bool ballPole; // false: north true: south
    public int lv;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.UnloadSceneAsync("Menu");
        fin = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("curLvl", lv);
        if(fin == true){
            SceneManager.LoadScene("LvlSel");
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
            if(lv == PlayerPrefs.GetInt("lvl")){
                PlayerPrefs.SetInt("lvl", lv + 1);
            }
        }
        if (collision.gameObject.tag == "Mutator")
        {
            ballPole = !ballPole;
        }
    }
}
