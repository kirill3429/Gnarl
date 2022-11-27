
using UnityEngine;
using Zenject;
using Cinemachine;

public class CameraScroller : MonoBehaviour
{
    [Inject] private InputHandler inputHandler;
    [SerializeField] private float scrollerSpeed;
    private CinemachineVirtualCamera cam;

    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if (inputHandler.cameraScroller != 0 && EditorEnabler.isActive == false)
        {
            cam.m_Lens.OrthographicSize -= inputHandler.cameraScroller * Time.deltaTime * scrollerSpeed;
        }
    }
}
