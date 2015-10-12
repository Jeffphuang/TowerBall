using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
	public static void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}
}