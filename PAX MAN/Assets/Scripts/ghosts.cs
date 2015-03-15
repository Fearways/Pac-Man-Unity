using UnityEngine;
using System.Collections;

public class ghosts : MonoBehaviour
{
    public Transform[] waypoints;
    int cur = 0;
    public float speed = 0.3f;
    public Transform turns;

    void Start()
    {
        waypoints = new Transform[turns.childCount];
        for (int i = 0; i < turns.childCount; i++)
        {
            waypoints[i] = turns.GetChild(i);
        }
    }
    void FixedUpdate()
    {
        // Waypoint not reached yet? then move closer
        print(Vector3.Distance(transform.position, waypoints[cur].position));
        if (Vector3.Distance(transform.position, waypoints[cur].position) > 0.2)
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            rigidbody2D.MovePosition(p);
        }
        // Waypoint reached, select next one
        else
        {
            Debug.DrawLine(transform.position + Vector3.left * 20, transform.position, Color.red);
            bool found = false;
            while (!found)
            {
                int randdir = Random.Range(0, 4);
                if (randdir == 0)
                {
                    RaycastHit2D[] hit = Physics2D.LinecastAll(transform.position, transform.position + Vector3.up * 20);
                    for (int i = 0; i < hit.Length; i++)
                    {
                        if (hit[i].collider.gameObject.name.CompareTo("Maze") == 0)
                        {
                            break;
                        }
                        if (hit[i].collider.gameObject.name.Contains("Turn"))
                        {
                            string[] turn = hit[i].collider.gameObject.name.Split(' ');
                            print(turn[1]);
                            if (int.Parse(turn[1]) != cur)
                            {
                                cur = int.Parse(turn[1]);
                                found = true;
                                break;
                            }
                        }
                    }
                }
                if (randdir == 1)
                {
                    RaycastHit2D[] hit = Physics2D.LinecastAll(transform.position, transform.position + Vector3.down * 20);
                    for (int i = 0; i < hit.Length; i++)
                    {
                        if (hit[i].collider.gameObject.name.CompareTo("Maze") == 0)
                        {
                            break;
                        }
                        if (hit[i].collider.gameObject.name.Contains("Turn"))
                        {
                            string[] turn = hit[i].collider.gameObject.name.Split(' ');
                            print(turn[1]);
                            if (int.Parse(turn[1]) != cur)
                            {
                                cur = int.Parse(turn[1]);
                                found = true;
                                break;
                            }
                        }
                    }
                }
                if (randdir == 2)
                {
                    RaycastHit2D[] hit = Physics2D.LinecastAll(transform.position, transform.position + Vector3.left * 20);
                    for (int i = 0; i < hit.Length; i++)
                    {
                        if (hit[i].collider.gameObject.name.CompareTo("Maze") == 0)
                        {
                            break;
                        }
                        if (hit[i].collider.gameObject.name.Contains("Turn"))
                        {
                            string[] turn = hit[i].collider.gameObject.name.Split(' ');
                            print(turn[1]);
                            if (int.Parse(turn[1]) != cur)
                            {
                                cur = int.Parse(turn[1]);
                                found = true;
                                break;
                            }
                        }
                    }
                }
                if (randdir == 3)
                {
                    RaycastHit2D[] hit = Physics2D.LinecastAll(transform.position, transform.position + Vector3.right * 20);
                    for (int i = 0; i < hit.Length; i++)
                    {
                        if (hit[i].collider.gameObject.name.CompareTo("Maze") == 0)
                        {
                            break;
                        }
                        if (hit[i].collider.gameObject.name.Contains("Turn"))
                        {
                            string[] turn = hit[i].collider.gameObject.name.Split(' ');
                            print(turn[1]);
                            if (int.Parse(turn[1]) != cur)
                            {
                                cur = int.Parse(turn[1]);
                                found = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }
    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
            Destroy(co.gameObject);
    }
}
