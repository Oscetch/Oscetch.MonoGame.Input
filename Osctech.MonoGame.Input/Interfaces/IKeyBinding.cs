using Microsoft.Xna.Framework.Input;

namespace Osctech.MonoGame.Input.Interfaces
{
    public interface IKeyBinding
    {
        string BindingName { get; }
        Keys[] BoundKeys { get; }
        bool IsOnlyForClick { get; }

        void Invoke();
    }
}
