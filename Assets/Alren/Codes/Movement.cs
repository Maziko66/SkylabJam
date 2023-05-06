using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody player;
    public int speed = 5;

    private void FixedUpdate()
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