using UnityEngine;
using Math = Utils.Math;
public class CameraBehaviour : MonoBehaviour
{
    Vector3 previousPlayerPos = Vector3.zero;

    [Header("-----Variable------")]
    [SerializeField] GameObject playerGO = null;
    [SerializeField] float cameraMoveSpeed = 2.0f;
    [SerializeField] float cameraOffset = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 _camera = Camera.current.ScreenToViewportPoint(Camera.current.WorldToScreenPoint(transform.position));

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //print("X : " + Math.Distance(previousPlayerPos.x, transform.position.x));
        //print("Y : " + Math.Distance(previousPlayerPos.y, transform.position.y));
        CameraFollowPlayer();
        previousPlayerPos = new Vector3(playerGO.transform.position.x, playerGO.transform.position.y, playerGO.transform.position.z);
    }

    private void CameraFollowPlayer()
    {
        //Early return if the player prefab is not instantiate
        if (!playerGO)
        {
            print("CameraBehaviour -> No Player Instantiate !");
            return;
        }

        transform.position = playerGO.transform.position + ( new Vector3(4.0f, 5.0f, 0.0f) * playerGO.transform.localScale.x) * -1.0f ;

        //Vector2 _lerpPosition = Vector2.Lerp(transform.position, previousPlayerPos, Time.deltaTime * cameraMoveSpeed);
        //if (IsTooFarLeftRight())
        //{
        //    transform.position = new Vector3(_lerpPosition.x, transform.position.y, transform.position.z);
        //}
        //else
        //// Is Too Far of Down
        //if (IsTooFarUpDown())
        //{
        //    transform.position = new Vector3(transform.position.x, _lerpPosition.y, transform.position.z);
        //}
    }

    //private bool IsTooFarLeftRight()
    //{
    //    // Is Too Far of Left
    //    if (Math.Distance(previousPlayerPos.x, transform.position.x) < 20.0f)
    //    {
    //        print("Too Far Of Left");
    //        return true;
    //    }
    //    // Is Too Far of Right
    //    else if (Math.Distance(previousPlayerPos.x, transform.position.x) > -20.0f)
    //    {
    //        print("Too Far Of Right");
    //        return true;
    //    }
    //    return false;
    //}

    //private bool IsTooFarUpDown()
    //{
    //    // Is Too Far of Up
    //    if (Math.Distance(previousPlayerPos.y, transform.position.y) < 2)
    //    {
    //        print("Too Far Of Up");
    //        return true;
    //    }

    //    // Is Too Far of Down
    //    else if (Math.Distance(previousPlayerPos.y, transform.position.y) > -2)
    //    {
    //        print("Too Far Of Down");
    //        return true;
    //    }
    //    return false;
    //}
}
