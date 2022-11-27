using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AllBuildsController : BuildsController
{
    private List<Build> allBuildsList = new List<Build>();
    [Inject] private InputHandler inputHandler;

    private void Start()
    {
        inputHandler.editorModeButton += () =>
        {   
            if (EditorEnabler.isActive)
            {
                AssignBuilds();
                DeactivateAllBuilds();
            }
            else
            {
                AssignBuilds();
                ActivateAllBuilds();
            }
        };
        StartCoroutine(PerformAllBuilds());
    }

    public void AssignBuilds()
    {
        allBuildsList.Clear();
        FindBuilds(ref allBuildsList);
    }

    public void ActivateAllBuilds()
    {
        foreach (Build build in allBuildsList)
        {
            build.Activate();
        }
    }
    public void DeactivateAllBuilds()
    {
        foreach (Build build in allBuildsList)
        {
            build.Deactivate();
        }
    }

    private IEnumerator PerformAllBuilds()
    {
        while (true)
        {
            
            float currentTime = Time.time;
            foreach (Build b in allBuildsList)
            {
                if (b.isActive)
                {
                    if (currentTime - b.LastPerformedTime > b.Cooldown)
                    {
                        b.Perform();
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
