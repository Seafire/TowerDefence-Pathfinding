using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour 
{
	public Image img;
	public AnimationCurve curve;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (FadeIn ());
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void FadeTo (string scene)
	{
		StartCoroutine (FadeOut (scene));
	}

	IEnumerator FadeIn ()
	{
		float t = 1f;

		while (t > 0f)
		{
			t -= Time.deltaTime * 0.5f;
			float a = curve.Evaluate (t);
			img.color = new Color (0, 0, 0, a);
			yield return 0;
		}
	}

	IEnumerator FadeOut (string scene)
	{
		float t = 0f;
		
		while (t < 1f)
		{
			t += Time.deltaTime;
			float a = curve.Evaluate (t);
			img.color = new Color (0, 0, 0, a);
			yield return 0;
		}

		Application.LoadLevel (scene);
	}
}
