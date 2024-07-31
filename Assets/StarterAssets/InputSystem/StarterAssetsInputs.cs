using System;
using Unity.VisualScripting;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		public event EventHandler OnInteraction;
		public event EventHandler onFlashLightTurn;
		public event EventHandler onChanageFlashLightType;

		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool crotch;

        [Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		private PlayerInteractions playerInteractions;

        private void Awake()
        {
            playerInteractions = new PlayerInteractions();
			playerInteractions.Player.Enable();

            playerInteractions.Player.Interaction.performed += Interaction_performed;
            playerInteractions.Player.FlashLight.performed += FlashLight_performed;
            playerInteractions.Player.FlashLitghtTypes.performed += FlashLitghtTypes_performed;
        }

        private void FlashLitghtTypes_performed(InputAction.CallbackContext obj)
        {
            onChanageFlashLightType?.Invoke(this, EventArgs.Empty);
        }

        private void FlashLight_performed(InputAction.CallbackContext obj)
        {
            onFlashLightTurn?.Invoke(this, EventArgs.Empty);
        }

        private void Interaction_performed(InputAction.CallbackContext obj)
        {
			OnInteraction?.Invoke(this, EventArgs.Empty);
        }

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnCrotch(InputValue value)
		{
			CrotchInput(value.isPressed);
		}
#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
		
		public void CrotchInput(bool newCrotchState)
		{
			crotch = newCrotchState;
		}


        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

    }


}
