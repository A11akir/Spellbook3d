using UnityEngine;

namespace Services.Input
{
    public interface IInputServices
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }

    public class InputServices : IInputServices
    {
        public Vector2 Axis
        {
            get
            {
                Vector2 axis = UnityAxis();
                return axis;
            }
        }

        private static Vector2 UnityAxis() =>
            new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
        

        public bool IsAttackButtonUp()
        {
            throw new System.NotImplementedException();
        }
    }
}