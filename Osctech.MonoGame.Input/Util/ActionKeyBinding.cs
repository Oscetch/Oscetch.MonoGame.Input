using Microsoft.Xna.Framework.Input;
using Osctech.MonoGame.Input.Interfaces;
using System;

namespace Osctech.MonoGame.Input.Util
{
    public class ActionKeyBinding : IKeyBinding
    {
        public string BindingName { get; }
        public Keys[] BoundKeys { get; }
        public bool IsOnlyForClick { get; }
        public Action Action { get; set; }

        public ActionKeyBinding(string bindingName, bool isOnlyForClick, Action action, params Keys[] boundKeys)
        {
            BindingName = bindingName;
            Action = action;
            BoundKeys = boundKeys;
            IsOnlyForClick = isOnlyForClick;
        }

        public void Invoke() => Action?.Invoke();
    }
}
