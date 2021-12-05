using Microsoft.Xna.Framework.Input;
using Osctech.MonoGame.Input.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osctech.MonoGame.Input.Services
{
    public sealed class KeyboardStateService
    {
        private KeyboardState _previousKeyboardState;
        private KeyboardState _currentKeyboardState;

        internal KeyboardStateService() { }

        internal void Update()
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
        }

        internal void Invalidate()
        {
            _previousKeyboardState =
                _currentKeyboardState = new KeyboardState();
        }

        public bool AreKeysDown(params Keys[] keys)
        {
            return keys.All(x => IsKeyDown(x));
        }

        public bool IsKeyDown(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key);
        }

        public bool AreKeysHeld(params Keys[] keys)
        {
            return keys.All(x => IsKeyHeld(x));
        }

        public bool IsKeyHeld(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key) 
                && _previousKeyboardState.IsKeyDown(key);
        }

        public bool AreKeysClicked(params Keys[] keys)
        {
            return keys.All(x => _currentKeyboardState.IsKeyDown(x)) 
                && keys.Any(x => _previousKeyboardState.IsKeyUp(x));
        }

        public bool IsKeyClicked(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key)
                && _previousKeyboardState.IsKeyUp(key);
        }

        public Keys[] CurrentKeys()
        {
            return _currentKeyboardState.GetPressedKeys();
        }
    }
}
