using System.Collections.Generic;

namespace Oscetch.MonoGame.Input.Interfaces
{
    public interface IKeyBindingManager
    {
        IEnumerable<IKeyBinding> GetKeyBindings();
    }
}
