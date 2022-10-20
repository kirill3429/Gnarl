using Kirill;
using UnityEngine;
using Cinemachine;

public class CameraScroller : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private float scrollerSpeed;
    private CinemachineVirtualCamera cam;

    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if (inputHandler.cameraScroller != 0 && GnalEditorEnabler.isActive == false)
        {
            cam.m_Lens.OrthographicSize -= inputHandler.cameraScroller * Time.deltaTime * scrollerSpeed;
        }
    }
}
