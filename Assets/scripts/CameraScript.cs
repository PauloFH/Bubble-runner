
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0.0f, 2.0f, -3.0f);
    public Vector3 angle = Vector3.zero;
    public float damping = 5.0f;

    void CameraFolow(bool allowRotTrack = true)
    {
       // angle = player.eulerAngles;

        Quaternion init = Quaternion.Euler(angle);
        if (allowRotTrack)
        {
            Quaternion rot = Quaternion.Slerp(transform.rotation, player.rotation * Quaternion.Euler(angle), Time.deltaTime * damping);
            transform.rotation = rot;
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(angle), Time.deltaTime * damping);
        }

        Vector3 foward = transform.rotation * Vector3.forward;
        Vector3 right = transform.rotation * Vector3.right;
        Vector3 up = transform.rotation * Vector3.up;

        Vector3 target = player.position;
        Vector3 desiredPos = target + foward * offset.z + right * offset.x + up * offset.y;

        Vector3 position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * damping);
        transform.position = position;
    }

    private void LateUpdate()
    {
        CameraFolow();
    }
}













