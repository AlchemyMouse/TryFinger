using HarmonyLib;
using UnityEngine.InputSystem;

namespace TryFinger
{
	[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
	public class ModInput : MonoSingleton<ModInput>
	{
		global::PlayerInput pinput;

		public InputActionState TryFinger
		{
			get
			{
				return pinput.Actions["TryFinger"];
			}
		}

		public ModInput()
		{
			pinput = MonoSingleton<InputManager>.Instance.InputSource;
            pinput.Actions["TryFinger"] = new InputActionState(new InputAction("TryFinger", InputActionType.Button, null, null, null, null));
            TryFinger.Action.AddBinding($"<Keyboard>/{Plugin.conf.TryFinger.Value.ToLower()}", null, null, null).WithGroup("Keyboard");
			pinput.Enable();
		}
	}
}