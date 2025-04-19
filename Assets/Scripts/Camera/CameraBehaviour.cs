using UnityEngine;
//using Math = Utils.Math;
enum CameraType
{
    STATIC,
    DYNAMIC
};

public class CameraBehaviour : MonoBehaviour
{
    [Header("-----Variable------")]
    [SerializeField] GameObject spriteCharacter = null;
    [SerializeField] float cameraHorizontalMoveSpeed = 5.0f;
    [SerializeField] float cameraVerticalMoveSpeed = 5.0f;
    [SerializeField] Vector3 cameraPosition = Vector3.zero;
    [SerializeField] Vector3 cameraOffset = Vector3.zero;
    [SerializeField] CameraType cameraType = CameraType.DYNAMIC;
    Transform parent;
    // Start is called before the first frame update  
    private void Start()
    {
        parent = spriteCharacter.transform.parent;
    }

    // Update is called once per frame
    private void FixedUpdate()
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
        //slow camera for Horizontal deplacement
        MoveCameraHorizontal();

        //fast camera for Vertical deplacement
        MoveCameraVertical();

        //Idée à la poubelle...
        //MoveCameraToPlayerLeftRight();
        //MoveCameraToPlayerUpDown();
    }
    private void MoveCameraHorizontal()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, parent.position.x + parent.localScale.x * -1.0f * cameraPosition.x + cameraOffset.x, Time.deltaTime * cameraHorizontalMoveSpeed),transform.position.y, transform.position.z);
    }

    private void MoveCameraVertical()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, parent.position.y + parent.localScale.y * -1.0f * cameraPosition.y + cameraOffset.y, Time.deltaTime * cameraVerticalMoveSpeed), transform.position.z);
    }

    //void MoveCameraToPlayerLeftRight()
    //{
    //    if (Math.Distance(transform.position.x, sprite.transform.parent.position.x) < 1.1f
    //        ||
    //        Math.Distance(transform.position.x, sprite.transform.parent.position.x) > -1.1f)
    //    {
    //        MoveCamera();
    //    }
    //}

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