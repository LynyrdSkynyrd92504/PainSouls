using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace DS
{
    public abstract class StateManager : MonoBehaviour
    {
        State currentState;
        Dictionary<string, State> allStates = new Dictionary<string, State>();

        private void Start ()
        {
            Init();
        }

        public abstract void Init();

        public void FixedTick()
        {
            if (currentState == null)
                return;

            currentState.FixedTick();
        }

        public void Tick()
        {
            if (currentState == null)
                return;

            currentState.Tick();
        }

        public void LateTick()
        {
            if (currentState == null)
                return;

            currentState.LateTick();
        }

        public void ChangeState(string targetId)
        {
            if (currentState != null)
            {
                // Run on exit actions
            }

            State targetState = GetState(targetId);
            // Run on enter actions
            currentState = targetState;

        }

        State GetState(string targetId)
        {
            allStates.TryGetValue(targetId, out State retVal);
            return retVal;
        }

        protected void RegisterState(string statedId, State state)
        {
            allStates.Add(statedId, state);
        }
    }
}