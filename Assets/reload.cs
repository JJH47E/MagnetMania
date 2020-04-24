using UnityEngine;
using UnityEngine.SceneManagement;

public class reload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.UnloadSceneAsync("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            SceneManager.LoadScene("SampleScene");
        }
    }
}
