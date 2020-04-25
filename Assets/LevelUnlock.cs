using UnityEngine;
using TMPro;

public class LevelUnlock : MonoBehaviour
{
    public TextMeshProUGUI[] lvls;

    void Update()
    {
        for(int k = 0; k < lvls.Length; k++){
            if(canLoad(k)){
                lvls[k].text = (k + 1).ToString();
            }
            else{
                lvls[k].text = "Lock";
            }
        }
        Debug.Log(PlayerPrefs.GetInt("lvl"));
    }

    public bool canLoad(int i){
        if(i < PlayerPrefs.GetInt("lvl")){
            return true;
        }
        else{
            return false;
        }
    }
}
