using Microsoft.Xna.Framework.Input;
using Oscetch.MonoGame.Input.Interfaces;
using System;

namespace Oscetch.MonoGame.Input.Util
{
    public class ActionKeyBinding(string bindingName, bool isOnlyForClick, Action action, params Keys[] boundKeys) : IKeyBinding
    {
        public string BindingName { get; } = bindingName;
        public Keys[] BoundKeys { get; } = boundKeys;
        public bool IsOnlyForClick { get; } = isOnlyForClick;
        public Action Action { get; set; } = action;

        public void Invoke() => Action?.Invoke();
    }
}
