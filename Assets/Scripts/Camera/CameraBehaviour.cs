using UnityEngine;
using Math = Utils.Math;
enum CameraType
{
    STATIC,
    DYNAMIC
};

public class CameraBehaviour : MonoBehaviour
{
    [Header("-----Variable------")]
    [SerializeField] GameObject playerGO = null;
    [SerializeField] float cameraMoveSpeed = 2.0f;
    [SerializeField] Vector3 cameraPosition = Vector3.zero;
    [SerializeField] Vector3 cameraOffset = Vector3.zero;
    [SerializeField] CameraType cameraType = CameraType.DYNAMIC;
    // Start is called before the first frame update  
    private void Start()
    {
        //Vector3 _camera = Camera.current.ScreenToViewportPoint(Camera.current.WorldToScreenPoint(transform.position));
        cameraPosition = new Vector3(0.0f, 0.0f, 0.0f); 
        cameraOffset = new Vector3(0.0f, transform.position.y - 3.0f, transform.position.z);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        switch(cameraType)
        {
            case CameraType.STATIC:
                //put the position to the target of the camera
                break;
            case CameraType.DYNAMIC:
                CameraFollowPlayer();
                break;
        default:
            break;
        }
    }

    private void CameraFollowPlayer()
    {
        //Early return if the player prefab is not instantiate
        if (!playerGO)
        {
            print("CameraBehaviour -> No Player Instantiate !");
            return;
        }
        //MoveCamera();
        MoveCameraToPlayerLeftRight();
        //MoveCameraToPlayerUpDown();

    }
    private void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, playerGO.transform.position + playerGO.transform.localScale.x * 1.0f * cameraPosition + cameraOffset, Time.deltaTime * cameraMoveSpeed);
    }

    void MoveCameraToPlayerLeftRight()
    {
        if (Math.Distance(transform.position.x, playerGO.transform.position.x) < 1.1f
            ||
            Math.Distance(transform.position.x, playerGO.transform.position.x) > -1.1f)
        {
            MoveCamera();
        }
    }

    //void MoveCameraToPlayerUpDown()
    //{
    //    //print(Math.Distance(transform.position.y, playerGO.transform.position.y));
    //    if (Math.Distance(transform.position.y, playerGO.transform.position.y) > 2.6f
    //        ||
    //        Math.Distance(transform.position.y, playerGO.transform.position.y) < -0.0f)

    //        MoveCamera();
    //    }
    //}

}