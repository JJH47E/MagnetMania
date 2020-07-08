using UnityEngine;
using UnityEngine.SceneManagement;

public class reload : MonoBehaviour
{
    public Transform mag;
    public SpriteRenderer playVec;
    public SpriteRenderer InstVec;
    private int menuCount;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("lvl") == false){
            PlayerPrefs.SetInt("lvl", 1);
        }
        SceneManager.UnloadSceneAsync("Lvl1");
        SceneManager.UnloadSceneAsync("Instructions");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if((mousePos[0] > -5.8) && (mousePos[0] < 5.8)){
            if((mousePos[1] < 0f) && (mousePos[1] > -14f)){
                Color tmp = playVec.color;
                tmp.a = 1f;
                playVec.color = tmp;
                tmp = InstVec.color;
                tmp.a = 0f;
                InstVec.color = tmp;
                menuCount = 0;
            }
            else if((mousePos[1] < -14.2f) && (mousePos[1] > -16f)){
                Color tmp = playVec.color;
                tmp.a = 0f;
                playVec.color = tmp;
                tmp = InstVec.color;
                tmp.a = 1f;
                InstVec.color = tmp;
                menuCount = 1;
            }
        }
        
        if(Input.GetMouseButtonDown(0)){
            if(menuCount == 0){
                SceneManager.LoadScene("LvlSel");
            }
            else if(menuCount == 1){
                SceneManager.LoadScene("Instructions");
            }
        }
        //reset code
        //if(Input.GetMouseButtonDown(1)){
        //    PlayerPrefs.SetInt("lvl", 1);
        //    PlayerPrefs.SetInt("curLvl", 0);
        //}
    }
}
