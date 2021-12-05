using Oscetch.MonoGame.Input.Interfaces;
using Oscetch.MonoGame.Input.Services;

namespace Oscetch.MonoGame.Input.Managers
{
    public static class KeyboardManager
    {
        private static readonly KeyboardStateService _generalStateService = new ();
        private static KeyboardStateService _currentStateService = _generalStateService;
        private static bool _isUsingPrivateKeyState;

        public static IKeyBindingManager KeyBindingManager { get; set; } = new KeyBindingManager();

        public static void Update()
        {
            _currentStateService.Update();

            if (_isUsingPrivateKeyState || KeyBindingManager == null)
            {
                return;
            }

            foreach(var keyBinding in KeyBindingManager.GetKeyBindings())
            {
                if (keyBinding.IsOnlyForClick)
                {
                    if (_generalStateService.AreKeysClicked(keyBinding.BoundKeys))
                    {
                        keyBinding.Invoke();
                    }

                    continue;
                }

                if (_generalStateService.AreKeysDown(keyBinding.BoundKeys))
                {
                    keyBinding.Invoke();
                }
            }
        }

        public static KeyboardStateService GetPrivate()
        {
            _generalStateService.Invalidate();
            _currentStateService = new ();
            _isUsingPrivateKeyState = true;

            return _currentStateService;
        }

        public static KeyboardStateService GetGeneral()
        {
            return _generalStateService;
        }

        public static void ReleasePrivate()
        {
            _currentStateService = _generalStateService;
            _isUsingPrivateKeyState = false;
        }
    }
}
