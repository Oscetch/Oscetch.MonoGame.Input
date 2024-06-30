# Oscetch.MonoGame.Input
A project for handling input comming from the MonoGame api

## Usage

### MouseManager

The `MouseManager` is a static class that can be accessed from anywhere.
To set it up, go to your `Game` derived class and inform the `MouseManager` of the screen size.
Then make sure to update it with each `Update` call.
```csharp
protected override void Initialize()
{
  base.Initialize();
  MouseManager.SetScreenSize(1280, 720);
}

protected override void Update(GameTime gameTime)
{
  // with no camera translation
  MouseManager.Update();
  // with camera translation
  MouseManager.Update(Camera.ViewMatrix);
}
```

To check if the mouse is over an object you would use
```csharp
var bounds = new Rectangle(0, 0, 100, 100);
// to check with the current camera translation
if (MouseManager.IsOverArea(bounds))
{
  // do stuff
}
// to check without any camera offset
if (MouseManager.IsOverAreaRaw(bounds))
{
  // do stuff
}
```

You can check if a click occurred(defined as if the previous mouse state pressed, and the current state is released) like so:
```csharp
if (MouseManager.IsLeftButtonClicked)
{
  // MouseManager.IsLeftButtonClicked will be set to false the next MouseManager.Update() call with the following line.
  MouseManager.LeftClickHandled = true;
  // do stuff
}
```

### KeyboardManager

The `KeyboardManager` is a static class that can be accessed from anywhere.
To setup, simply ensure you update the `KeyboardManager` with each `Update()` call.

```csharp
protected override void Update(GameTime gameTime)
{
    KeyboardManager.Update();
}
```

To check if a key has been clicked you do so by:
```csharp
if (KeyboardManager.GetGeneral().IsKeyClicked(Keys.Enter))
{
  // do stuff
}
```

You can setup general key bindings using the `IKeyBindingManager` interface, or using the concrete implementation `KeyBindingManager`
```csharp
protected override void Initialize()
{
  base.Initialize();
  var keybindingManager = new KeyBindingManager();
  keybindingManager.SetKeyBindings(
    new ActionKeyBinding("Exit", true, () => Exit(), Keys.Escape), 
    new ActionKeyBinding("Toggle fullscreen", true, () => _graphics.ToggleFullScreen(), Keys.LeftAlt, Keys.Enter)
  );
  KeyboardManager.KeyBindingManager = keybindingManager;
}
```

#### General and private keyboards

Often in games, we want to switch the keyboard focus away from the game to some sort of input or dialog.
To easily switch between such states you can implement your general game logic to use the "general" keyboard, and when you don't want your game to recognize input from that keyboard you call `KeyboardManager.GetPrivate()`. When you want to switch back to the general gameplay, you release the private keyboard with `KeyboardManager.ReleasePrivate()`.
```csharp
class Player
{
  private readonly KeyboardStateService _keyboard;
  private Vector2 _velocity;

  public Player()
  {
    _keyboard = KeyboardManager.GetGeneral();
  }

  public void Update(GameTime gameTime)
  {
    if (_keyboard.IsKeyDown(Keys.W))
    {
      _velocity -= new Vector(0, 10);
    }
    // etc
  }
}

class Dialog
{
  private KeyboardStateService _privateKeyboard;
  private bool _show;

  public string Text { get; private set; }

  public bool Show
  {
    get => _show;
    set
    {
      _show = value;
      if (_show)
      {
        // if multiple private keyboards are fetched, only the latest one will receive updates.
        _privateKeyboard = KeyboardManager.GetPrivate();
      }
      else
      {
        // will always give focus back to the general keyboard
        KeyboardManager.ReleasePrivate();
      }
    }
  }

  public void Update(GameTime gameTime)
  {
    var newText = _privateKeyboard?.CurrentKeys().Select(x => StringKeys[x]) ?? new string[0];
    Text += string.Join("", newText);
  }
}

class Game1 : Game
{
  private readonly Player _player = new Player();
  private readonly Dialog _dialog = new Dialog();

  // etc

  override void Update(GameTime gameTime)
  {
    // only player receives keyboard input
    _dialog.Show = false;
    KeyboardManager.Update();
    _player.Update(gameTime);
    _dialog.Update(gameTime);

    // only _dialog receives keyboard input
    _dialog.Show = true;
    KeyboardManager.Update();
    _player.Update(gameTime);
    _dialog.Update(gameTime);
  }
}
```

