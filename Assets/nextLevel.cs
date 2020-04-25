using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public TextMeshProUGUI t;
    private bool c;
    // Start is called before the first frame update
    void Start()
    {
        c = false;
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "You Beat Level " + (PlayerPrefs.GetInt("curLvl")+1).ToString();
        if(c == true){
            SceneManager.LoadScene("Lvl"+(PlayerPrefs.GetInt("curLvl")+2).ToString());
        }
    }

    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0)){
            c = true;
        }
        else{
            c = false;
        }
    }
}
