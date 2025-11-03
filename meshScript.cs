using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public int speed = 3;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"),
                                        Input.GetAxis("Vertical"),
                                        0)
                                        * Time.deltaTime
                                        *speed);
    }               
}
