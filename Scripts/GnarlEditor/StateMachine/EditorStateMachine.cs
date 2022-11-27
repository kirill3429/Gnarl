using UnityEngine;
using Zenject;

public class EditorStateMachine : MonoBehaviour
{
    [Inject] private InputHandler inputHandler;
    public LayerMask freeSlotsLayerMask;
    public GameObject freeBuild;
    public GameObject freeGnarl;
    public GameObject gnarlPrefab;
    public FreeSlotsEnabler slotsEnabler;
    public Slot currentSlot;
    public int freeBuildCost;

    public EditorState defaultState;
    public EditorState buildState;
    public EditorState gnarlState;


    public InputHandler InputHandler { get { return inputHandler; } }

    private Camera mainCamera;
    private EditorState state;



    private void Start()
    {
        mainCamera = Camera.main;
        defaultState = new DefaultState(this);
        buildState = new BuildState(this);
        gnarlState = new GnarlState(this);
        state = defaultState;

    }

    private void Update()
    {
        Ray ray = CreateRay();
        state.Tick(ray);
    }
    public void CreateBuild(GameObject buildToSpawn, int cost)
    {
        state.CreateBuild(buildToSpawn, cost);
    }

    public void SetState(EditorState editorState)
    {
        state = editorState;
    }

    private Ray CreateRay()
    {
        Ray ray = mainCamera.ScreenPointToRay(inputHandler.mouseInput);
        return ray;

       
    }

    private void OnDisable()
    {
        if (freeBuild != null)
            Destroy(freeBuild);
        if (freeGnarl != null)
            Destroy(freeGnarl);
        SetState(defaultState);
    }
}
