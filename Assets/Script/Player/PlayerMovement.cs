using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float smoothTime = 0.08f;
 
    private Vector3 currentVelocity;
    private Vector3 velocityRef;
 
    private void Update()
    {
        float moveX = 0f;
        float moveY = 0f;
 
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) moveX = 1f;
        if (Input.GetKey(KeyCode.UpArrow)) moveY = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) moveY = -1f;
        Vector3 inputDir = new Vector3(moveX, moveY, 0f).normalized;
        Vector3 targetVelocity = inputDir * moveSpeed;
        currentVelocity = Vector3.SmoothDamp(currentVelocity, targetVelocity, ref velocityRef, smoothTime);
 
        transform.position += currentVelocity * Time.deltaTime;
    }
}
 