using System.Collections.Generic;

namespace Osctech.MonoGame.Input.Interfaces
{
    public interface IKeyBindingManager
    {
        IEnumerable<IKeyBinding> GetKeyBindings();
    }
}
