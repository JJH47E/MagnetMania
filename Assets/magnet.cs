using UnityEngine;
using UnityEngine.SceneManagement;

public class magnet : MonoBehaviour
{
    public Transform ball;
    public Transform mag;
    public bool pole; // false: north true: south
    public Rigidbody2D ballPhys;
    public float magnetConstant;
    public float limit;
    public SpriteRenderer spr;
    public BallController ballBool;
    private float angle;
    private float offset;
    private float repulsion;
    public GameObject[] obs;
    private int attatch;
    private bool connect;
    public float[] check;
    private float ans;
    public Transform marker;
    public Vector3 VecOff;

    // Start is called before the first frame update
    void Start()
    {
        UnloadAllScenesExcept(SceneManager.GetActiveScene().name);
        attatch = 0;
        connect = false;
    }

    void FixedUpdate()
    {
        if(pole == true){
            offset = 0f;
        }
        else{
            offset = 180f;
        }
        if(pole == obs[attatch].GetComponent<PoleController>().Pole){
            repulsion = 1f;
        }
        else{
            repulsion = -1f;
        }
        if(connect == true){
            attatch = attatch + 1;
            attatch = attatch % obs.Length;
            connect = false;
        }
        mag.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mag.position = new Vector3(transform.position.x, transform.position.y, -1);
        float angle = Mathf.Atan2(obs[attatch].GetComponent<Transform>().position[0] - mag.position[0], obs[attatch].GetComponent<Transform>().position[1] - mag.position[1]) * Mathf.Rad2Deg;
        mag.rotation = Quaternion.Euler(0, 0, 180 - angle - offset);
        //Debug.Log(180 - angle + offset);
        if(Mathf.Sqrt(Mathf.Pow(obs[attatch].GetComponent<Transform>().position[0] - mag.position[0], 2) + Mathf.Pow(obs[attatch].GetComponent<Transform>().position[1] - mag.position[1], 2)) < limit){
            if((obs[attatch].GetComponent<Transform>().position[0] - mag.position[0] > 3 || obs[attatch].GetComponent<Transform>().position[0] - mag.position[0] < -3)){
                Color tmp = spr.color;
                tmp.a = 1f;
                spr.color = tmp;
                if(Mathf.Abs(obs[attatch].GetComponent<Transform>().position[0] - mag.position[0]) > Mathf.Abs(obs[attatch].GetComponent<Transform>().position[1] - mag.position[1])){
                    obs[attatch].GetComponent<Rigidbody2D>().velocity = new Vector3(repulsion * (magnetConstant/(obs[attatch].GetComponent<Transform>().position[0] - mag.position[0])), obs[attatch].GetComponent<Rigidbody2D>().velocity.y);
                }
            }
            else{
                Color tmp = spr.color;
                tmp.a = 0.25f;
                spr.color = tmp;
            }
        }
        marker.position = obs[attatch].GetComponent<Transform>().position + VecOff;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            pole = !pole;
        }
        else if(Input.GetMouseButtonDown(1)){
            connect = true;
        }
        else if(Input.GetKeyDown(KeyCode.R)){
            Debug.Log("resetting");
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
    void UnloadAllScenesExcept(string sceneName)
    {
        int c = SceneManager.sceneCount;
        for (int i = 0; i < c; i++) {
            Scene scene = SceneManager.GetSceneAt (i);
            if (scene.name != sceneName) {
                SceneManager.UnloadSceneAsync (scene);
            }
        }
    }
}