using SFML.System;
using IW4DumpHelperGUI.Core.Graphics;

namespace IW4DumpHelperGUI.Core.Graphics.Interfaces
{
    interface IMoveableElem
    {
        void MoveTo(Vector2f Pos, double speed);
        void UpdateMoveToPosition(float frametime);
        bool IsMoving { get; }
        double SpeedMulitplier { get; }
        MoveDirections DirectionX { get; }
        MoveDirections DirectionY { get; }
    }
}
