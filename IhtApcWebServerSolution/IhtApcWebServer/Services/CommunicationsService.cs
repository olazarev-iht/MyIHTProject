namespace IhtApcWebServer.Services
{
	public class CommunicationsService
	{
		public event EventHandler? OnButtonPressed;

		public void ButtonPressed()
		{
			OnButtonPressed?.Invoke(this, EventArgs.Empty);
		}
	}
}
