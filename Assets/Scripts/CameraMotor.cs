using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    // Late Update is being called after update and fixed update 
    // make sure we move the camera after player moves, otherwise there would be small desync
    private void LateUpdate()
    {
        // difference between this frame and the next frame
        Vector3 delta = Vector3.zero;

        // transform.position.x center of the camera
        // we get the distance between focus area and the player
        // if this is bigger than boundX then it means we are outside the bound 
        // this is to check if we're inside the bound on the X axis
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            // is the center of the camera smaller thant the lookAt / player?
            // then it means the player is on the right and the focus of the camera is on the left
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        // this is to check if we're inside the bound on the Y axis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            // is the center of the camera smaller than the lookAt / player?

            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
