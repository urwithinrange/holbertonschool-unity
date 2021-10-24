using UnityEngine;
 
public class CameraController : MonoBehaviour {

    private Transform _Xform_Camera;
    private Transform _Xform_Parent;

    private Vector3 _LocalRotation;
    // private float _CameraDistance = 10f;

    public float MouseSensitivity = 4f;
    public float OrbitSpeed = 10f;

    public bool CameraDisable;


    void Start () {
        this._Xform_Camera = this.transform;
        this._Xform_Parent = this.transform.parent;
        CameraDisable = true;
    }

    void LateUpdate ()
    {
        if(Input.GetMouseButtonDown(1))
        {
            CameraDisable = false;
        }
        if(CameraDisable == false)
        {
            if(Input.GetAxis("Mouse X") != 0)
            {
                _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;                 
            }
            Quaternion QT = Quaternion.Euler(0, _LocalRotation.x, 0);
            this._Xform_Parent.rotation = Quaternion.Lerp(this._Xform_Parent.rotation, QT, Time.deltaTime * OrbitSpeed);
        }
        if(Input.GetMouseButtonUp(1))
        {
            CameraDisable = true;
        }
    }
}
