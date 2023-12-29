using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    private Movement player;

    private RaycastHit2D hit;

    [SerializeField] private LayerMask obstacleMask;

    [SerializeField] private float timeAfterSpikesKill;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Movement>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D info)
    {
        if (info.collider.tag == "Spikes")
        {
            switch (player.movingDir)
            {
                case Direction.North:
                   hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 1, obstacleMask);
                   break;
                case Direction.South:
                   hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 1, obstacleMask);
                   break;
                case Direction.East:
                   hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1, obstacleMask);
                   break;
                case Direction.West:
                    hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1, obstacleMask);
                    break;
            }

            if (hit != null)
            {
                Destroy(GameObject.Find("Player"));
            }
        }

        if (info.collider.tag == "SpikesAfterTime")
        {
            info.collider.GetComponent<SpikesAfterTime>().startCountDown();
        }
    }
}
