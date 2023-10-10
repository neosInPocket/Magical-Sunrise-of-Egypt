using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScreen : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private Image healthZoneArrow; 
	[SerializeField] private Image rightArrow; 
	[SerializeField] private Image leftArrow; 
	[SerializeField] private Image ballArrow;
	[SerializeField] private Image character;
	[SerializeField] private Image back;	
	
	public void PlayTutor()
	{
		StartCoroutine(Tutor());
	}
	
	private IEnumerator Tutor()
	{
		_text.text = "Welcome to Tiger Elite!";
		_text.gameObject.SetActive(true);
		back.gameObject.SetActive(true);
		character.gameObject.SetActive(true);
		yield return new WaitForSeconds(3);
		
		_text.GetComponent<Animator>().SetTrigger("Hide");
		yield return new WaitForSeconds(0.2f);
		
		_text.text = "Here is your ball. Move it by swinging platforms with touching screen!";
		_text.gameObject.SetActive(true);
		ballArrow.gameObject.SetActive(true);
		yield return new WaitForSeconds(3);
		
		_text.GetComponent<Animator>().SetTrigger("Hide");
		yield return new WaitForSeconds(0.2f);
		ballArrow.gameObject.SetActive(false);
		
		_text.text = "If you touch one of the edges of the screen, you will lose lives";
		_text.gameObject.SetActive(true);
		leftArrow.gameObject.SetActive(true);
		rightArrow.gameObject.SetActive(true);
		yield return new WaitForSeconds(4);
		
		_text.GetComponent<Animator>().SetTrigger("Hide");
		yield return new WaitForSeconds(0.2f);
		leftArrow.gameObject.SetActive(false);
		rightArrow.gameObject.SetActive(false);
		
		_text.text = "Collect coins and buy upgrades in shop, such as max lives amount";
		_text.gameObject.SetActive(true);
		healthZoneArrow.gameObject.SetActive(true);
		yield return new WaitForSeconds(4);
		
		_text.GetComponent<Animator>().SetTrigger("Hide");
		yield return new WaitForSeconds(0.2f);
		healthZoneArrow.gameObject.SetActive(false);
		
		_text.text = "Good luck!";
		_text.gameObject.SetActive(true);
		yield return new WaitForSeconds(3);
		
		_text.GetComponent<Animator>().SetTrigger("Hide");
		yield return new WaitForSeconds(0.2f);
		gameObject.SetActive(false);
	}
}
