using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ball.position[0] - mag.position[0]);
        Debug.Log(ball.position[1] - mag.position[1]);
    }

    void FixedUpdate()
    {
        if(pole == true){
            offset = 0f;
        }
        else{
            offset = 180f;
        }
        if(pole == ballBool.ballPole){
            repulsion = 1f;
        }
        else{
            repulsion = -1f;
        }
        mag.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mag.position = new Vector3(transform.position.x, transform.position.y, -1);
        float angle = Mathf.Atan2(ball.position[0] - mag.position[0], ball.position[1] - mag.position[1]) * Mathf.Rad2Deg;
        mag.rotation = Quaternion.Euler(0, 0, 180 - angle - offset);
        //Debug.Log(180 - angle + offset);
        if(Mathf.Sqrt(Mathf.Pow(ball.position[0] - mag.position[0], 2) + Mathf.Pow(ball.position[1] - mag.position[1], 2)) < limit){
            if((ball.position[0] - mag.position[0] > 3 || ball.position[0] - mag.position[0] < -3)){
                Color tmp = spr.color;
                tmp.a = 1f;
                spr.color = tmp;
                if(Mathf.Abs(ball.position[0] - mag.position[0]) > Mathf.Abs(ball.position[1] - mag.position[1])){
                    ballPhys.velocity = new Vector3(repulsion * (magnetConstant/(ball.position[0] - mag.position[0])), ballPhys.velocity.y);
                }
            }
            else{
                Color tmp = spr.color;
                tmp.a = 0.25f;
                spr.color = tmp;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            pole = !pole;
        }
    }
}
