using UnityEngine;
using UnityEngine.SceneManagement;

public class instructions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.UnloadSceneAsync("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("Menu");
        }
        
    }
}
