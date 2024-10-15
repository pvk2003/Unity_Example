using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] Transform center_Pos;
    [SerializeField] Transform left_Pos;
    [SerializeField] Transform right_Pos;

    int current_Pos = 0; // Fixed typo
    public float side_speed;
    public float running_speed;
    public float jump_Force;

    [SerializeField] Rigidbody rb;
    bool isGameStarted = false;

    [SerializeField] Animator player_Animator;

    void Start()
    {
        isGameStarted = false;
        current_Pos = 0;
    }

    void Update()
    {
        if (!isGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Game is started");
                isGameStarted = true;
                player_Animator.SetInteger("isRunning", 1); // Chuyển đổi trạng thái

            }
        }


        if (isGameStarted)
        {
            // Player runs forward
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + running_speed * Time.deltaTime);

            // Handle input to change the current position
            if (current_Pos == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow)) current_Pos = 1;
                else if (Input.GetKeyDown(KeyCode.RightArrow)) current_Pos = 2;
            }
            else if (current_Pos == 1 && Input.GetKeyDown(KeyCode.RightArrow)) current_Pos = 0;
            else if (current_Pos == 2 && Input.GetKeyDown(KeyCode.LeftArrow)) current_Pos = 0;

            // Move the player to the appropriate position
            Vector3 targetPosition = transform.position;
            if (current_Pos == 0) targetPosition = new Vector3(center_Pos.position.x, transform.position.y, transform.position.z);
            else if (current_Pos == 1) targetPosition = new Vector3(left_Pos.position.x, transform.position.y, transform.position.z);
            else if (current_Pos == 2) targetPosition = new Vector3(right_Pos.position.x, transform.position.y, transform.position.z);

            if (Vector3.Distance(transform.position, targetPosition) >= 0.1f)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, side_speed * Time.deltaTime);
            }

            // Jump
            if (rb != null && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector3.up * jump_Force;
            }
        }
    }
}
