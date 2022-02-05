using UnityEngine;

public class RateMore : MonoBehaviour
{

	public void Rate()
	{
		// "market" works for android  (iOS: put your app link
		Application.OpenURL("market://details?id=com.DarkMatterGames.SpriteNInja");
	}

	public void More()
	{
		// Android  ,(iOS: put you app store link)
		Application.OpenURL("https://play.google.com/store/apps/developer?id=Dark+Matter+Game+Production");
	}

	public void Feedback()
	{
		Application.OpenURL("mailto:darkmattergamedev@gmail.com");
	}
}