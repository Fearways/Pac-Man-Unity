using UnityEngine;
using System.Collections;

public class Pacman : MonoBehaviour
{
    public GameObject Deadcondition;
    public GameObject ghosts;
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    Vector3 direction = Vector3.right;

    void Start()
    {
        dest = transform.position;
    }

    void Update()
    {
        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        rigidbody2D.MovePosition(p);
        if (WallHit(Vector3.up, 3.5f))
        {
            dest = (Vector2)transform.position + (Vector2)Vector3.down;
        }
        else if (WallHit(Vector3.down, 3.5f))
        {
            dest = (Vector2)transform.position + (Vector2)Vector3.up;
        }
        else if (WallHit(Vector3.right, 3.5f))
        {
            dest = (Vector2)transform.position + (Vector2)Vector3.left;
        }
        if (WallHit(Vector3.left, 3.5f))
        {
            dest = (Vector2)transform.position + (Vector2)Vector3.right;
        }
        if (!WallHit(direction, 3.5f))
        {
            dest = (Vector2)transform.position + (Vector2)direction;
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) &&
                !WallHit(Vector3.up, 3f) && !WallHit(new Vector3(1, 1, 0), 3f) && !WallHit(new Vector3(-1, 1, 0), 3f) &&
                !WallHit(new Vector3(0.5f, 1f, 0), 3f) && !WallHit(new Vector3(-0.5f, 1f, 0), 3f) &&
                !WallHit(new Vector3(0.75f, 1f, 0), 3f) && !WallHit(new Vector3(-0.75f, 1f, 0), 3f) &&
                !WallHit(new Vector3(0.25f, 1f, 0), 3f) && !WallHit(new Vector3(-0.25f, 1f, 0), 3f))
        {

            direction = Vector3.up;
        }
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) &&
            !WallHit(Vector3.right, 3f) && !WallHit(new Vector3(1, 1, 0), 3f) && !WallHit(new Vector3(1, -1, 0), 3f) &&
            !WallHit(new Vector3(1f, 0.5f, 0), 3f) && !WallHit(new Vector3(1f, -0.5f, 0), 3f) &&
            !WallHit(new Vector3(1f, -0.75f, 0), 3f) && !WallHit(new Vector3(1f, 0.75f, 0), 3f) &&
            !WallHit(new Vector3(1f, -0.25f, 0), 3f) && !WallHit(new Vector3(1f, 0.25f, 0), 3f))
        {
            direction = Vector3.right;
        }
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) &&
            !WallHit(Vector3.down, 3f) && !WallHit(new Vector3(1, -1, 0), 3f) && !WallHit(new Vector3(-1, -1, 0), 3f) &&
            !WallHit(new Vector3(0.5f, -1f, 0), 3f) && !WallHit(new Vector3(-0.5f, -1f, 0), 3f) &&
            !WallHit(new Vector3(0.75f, -1f, 0), 3f) && !WallHit(new Vector3(-0.75f, -1f, 0), 3f) &&
            !WallHit(new Vector3(0.25f, -1f, 0), 3f) && !WallHit(new Vector3(-0.25f, -1f, 0), 3f))
        {
            direction = Vector3.down;
        }
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) &&
            !WallHit(Vector3.left, 3f) && !WallHit(new Vector3(-1, 1, 0), 3f) && !WallHit(new Vector3(-1, -1, 0), 3f) &&
            !WallHit(new Vector3(-1f, -0.5f, 0), 3f) && !WallHit(new Vector3(-1f, 0.5f, 0), 3f) &&
            !WallHit(new Vector3(-1f, -0.75f, 0), 3f) && !WallHit(new Vector3(-1f, 0.75f, 0), 3f) &&
            !WallHit(new Vector3(-1f, -0.25f, 0), 3f) && !WallHit(new Vector3(-1f, 0.25f, 0), 3f))
        {
            direction = Vector3.left;
        }
        // Animation Parameters
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool WallHit(Vector3 dir, float length)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        bool wallhit = false;
        Vector3 pos = transform.position;
        Debug.DrawLine(pos + dir * length, pos, Color.red);
        RaycastHit2D[] hit = Physics2D.LinecastAll(pos + dir * length, pos);
        for (int i = 0; i < hit.Length; i++)
        {

            if (hit[i].collider.gameObject.name.CompareTo("Maze") == 0)
            {
                print(hit[i].collider);
                wallhit = true;
            }
        }
        return wallhit;
    }
    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name.Contains("Ghost"))
        {
            Deadcondition.SetActive(true);
            Application.Quit();
            Destroy(this.gameObject);
            Destroy(ghosts);

        }
    }
}