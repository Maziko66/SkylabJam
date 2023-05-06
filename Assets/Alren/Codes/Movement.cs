using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody player;
    public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.velocity = new Vector3(player.velocity.x, player.velocity.y, speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.velocity = new Vector3(player.velocity.x, player.velocity.y, -speed);
        }
    }
}