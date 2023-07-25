using DS;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class State
{
    bool forceExit;
    List<StateAction> fixedUpdateActions = new List<StateAction>();
    List<StateAction> updateActions = new List<StateAction>();
    List<StateAction> lateUpdateActions = new List<StateAction>();

    public void FixedTick()
    {
        ExecuteListOfActions(fixedUpdateActions);
    }

    public void Tick()
    {
        ExecuteListOfActions(updateActions);
    }

    public void LateTick()
    {
        ExecuteListOfActions(lateUpdateActions);
        forceExit = false;
    }

    void ExecuteListOfActions(List<StateAction> actions)
    {
        for (int i = 0; i < actions.Count; i++)
        {
            if (forceExit) 
                return;

            actions[i].Execute();
        }
    }
}
