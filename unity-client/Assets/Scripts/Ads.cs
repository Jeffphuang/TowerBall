using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
	public static int count = -1;
	public static void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}
}