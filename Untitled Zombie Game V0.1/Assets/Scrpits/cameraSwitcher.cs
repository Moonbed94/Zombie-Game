using Cinemachine;
using UnityEngine;

public class cameraSwitcher : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera ThirdPersonView;
    [SerializeField] CinemachineVirtualCamera ThirdPersonAim;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1) && (Input.GetKey(KeyCode.LeftControl)))
        {
            Debug.Log("CAMERA SWITCH");
        }
    }
}
