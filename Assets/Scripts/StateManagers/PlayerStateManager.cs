using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DS
{
    public class PlayerStateManager : CharacterStateManager
    {
        [Header("Inputs")]
        public float mouseX;
        public float mouseY;
        public float moveAmount;
        public Vector3 rotateDirection;

        public string locomotionId = "locomotion";
        public string attackStateId = "attackState";

        public override void Init()
        {
            base.Init();

            State locomotion = new State(
                new List<StateAction>() // Fixed Update
                {
                    new InputManager(this),
                },
                new List<StateAction>() // Update
                {

                },
                new List<StateAction>() // Late Update
                {

                }
            ); 

            State attackState = new State(
                new List<StateAction>() // Fixed Update
                {

                },
                new List<StateAction>() // Update
                {

                },
                new List<StateAction>() // Late Update
                {

                }
            );

            RegisterState(locomotionId, locomotion);
            RegisterState(attackStateId, attackState);

            ChangeState(locomotionId);
        }

        private void FixedUpdate()
        {
            base.FixedTick();
        }

        private void Update()
        {
            base.Tick();
        }

        private void LateUpdate()
        {
            base.LateTick();
        }
    }
}
