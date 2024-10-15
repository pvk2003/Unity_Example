using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] Transform center_Pos;
    [SerializeField] Transform left_Pos;
    [SerializeField] Transform right_Pos;
    
    int currunt_Pos = 0;
    public float side_speed;

    public float running_speed;

    public float jump_Force;

    [SerializeField] Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        currunt_Pos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + running_speed * Time.deltaTime);
        // Handle input to change the current position
        if (currunt_Pos == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currunt_Pos = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currunt_Pos = 2;
            }
        }
        else if (currunt_Pos == 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currunt_Pos = 0;
            }
        }
        else if (currunt_Pos == 2)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currunt_Pos = 0;
            }
        }

        // Move the player to the appropriate position
        if (currunt_Pos == 0)
        {
            if (Vector3.Distance(transform.position, new Vector3(center_Pos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
            {
                Vector3 dir = new Vector3(center_Pos.position.x, transform.position.y, transform.position.z) - transform.position;
                transform.Translate(dir.normalized * side_speed * Time.deltaTime, Space.World);
            }
        }
        else if (currunt_Pos == 1)
        {
            if (Vector3.Distance(transform.position, new Vector3(left_Pos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
            {
                Vector3 dir = new Vector3(left_Pos.position.x, transform.position.y, transform.position.z) - transform.position;
                transform.Translate(dir.normalized * side_speed * Time.deltaTime, Space.World);
            }
        }
        else if (currunt_Pos == 2)
        {
            if (Vector3.Distance(transform.position, new Vector3(right_Pos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
            {
                Vector3 dir = new Vector3(right_Pos.position.x, transform.position.y, transform.position.z) - transform.position;
                transform.Translate(dir.normalized * side_speed * Time.deltaTime, Space.World);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            // rb.AddForce(Vector3.up * jump_Force);
            rb.velocity = Vector3.up * jump_Force;
        }
    }
}
