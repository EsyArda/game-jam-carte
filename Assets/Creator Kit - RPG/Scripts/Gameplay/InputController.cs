using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;

namespace RPGM.UI
{
    /// <summary>
    /// Sends user input to the correct control systems.
    /// </summary>
    public class InputController : MonoBehaviour
    {
        public float stepSize = 0.1f;
        GameModel model = Schedule.GetModel<GameModel>();

        public enum State
        {
            CharacterControl,
            DialogControl,
            Pause
        }

        State state;

        public void ChangeState(State state) => this.state = state;

        void Update()
        {
            switch (state)
            {
                case State.CharacterControl:
                    CharacterControl();
                    break;
                case State.DialogControl:
                    DialogControl();
                    break;
            }
        }

        void DialogControl()
        {
            model.player.nextMoveCommand = Vector3.zero;
            if ((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.Q)))
                model.dialog.FocusButton(-1);
            else if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D)))
                model.dialog.FocusButton(+1);
            if ((Input.GetKeyDown(KeyCode.Return)) || (Input.GetKeyDown(KeyCode.KeypadEnter)))
                model.dialog.SelectActiveButton();
        }

        void CharacterControl()
        {
            if ((Input.GetKeyDown(KeyCode.RightControl)) || (Input.GetKeyDown(KeyCode.LeftControl)))
                model.player.speed = 30;
            if ((Input.GetKeyUp(KeyCode.RightControl)) || (Input.GetKeyUp(KeyCode.LeftControl)))
                model.player.speed = 15;
            if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.Z)))
                model.player.nextMoveCommand = Vector3.up * stepSize;
            else if ((Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.S)))
                model.player.nextMoveCommand = Vector3.down * stepSize;
            else if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.Q)))
                model.player.nextMoveCommand = Vector3.left * stepSize;
            else if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D)))
                model.player.nextMoveCommand = Vector3.right * stepSize;
            else
                model.player.nextMoveCommand = Vector3.zero;
        }
    }
}