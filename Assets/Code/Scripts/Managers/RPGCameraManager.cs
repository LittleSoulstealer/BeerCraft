using Cinemachine;
using UnityEngine;

public class RPGCameraManager : MonoBehaviour
{
    public static RPGCameraManager sharedInstance = null;
    public CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        if(sharedInstance != null && sharedInstance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
        GameObject vCamGameObject = GameObject.FindWithTag("VirtualCamera");
        virtualCamera = vCamGameObject.GetComponent<CinemachineVirtualCamera>();
    }

}
