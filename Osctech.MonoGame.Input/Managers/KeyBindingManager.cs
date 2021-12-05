using Osctech.MonoGame.Input.Interfaces;
using System.Collections.Generic;

namespace Osctech.MonoGame.Input.Managers
{
    public class KeyBindingManager : IKeyBindingManager
    {
        private readonly Dictionary<string, IKeyBinding> _keyBindingMap = new();

        public void SetKeyBinding(IKeyBinding keyBinding)
        {
            if(keyBinding == null)
            {
                return;
            }

            _keyBindingMap[keyBinding.BindingName] = keyBinding;
        }

        public void ClearKeyBinding(IKeyBinding keyBinding)
            => ClearKeyBinding(keyBinding?.BindingName);

        public void ClearKeyBinding(string bindingName)
        {
            if (bindingName != null && _keyBindingMap.ContainsKey(bindingName))
            {
                _keyBindingMap.Remove(bindingName);
            }
        }

        public void SetKeyBindings(IEnumerable<IKeyBinding> keyBindings)
        {
            if(keyBindings == null)
            {
                return;
            }

            _keyBindingMap.Clear();
            foreach(var keyBinding in keyBindings)
            {
                _keyBindingMap[keyBinding.BindingName] = keyBinding;
            }
        }

        public void SetKeyBindings(params IKeyBinding[] keyBindings)
        {
            _keyBindingMap.Clear();
            for(var i = 0; i < keyBindings.Length; i++)
            {
                var binding = keyBindings[i];
                _keyBindingMap[binding.BindingName] = binding;
            }
        }

        public bool TryGetKeyBinding(string keyBindingName, out IKeyBinding keyBinding)
        {
            return _keyBindingMap.TryGetValue(keyBindingName, out keyBinding);
        }

        public IEnumerable<IKeyBinding> GetKeyBindings()
        {
            return _keyBindingMap.Values;
        }
    }
}
