using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Terminal : MonoBehaviour
{
	private bool Interactable = true;
	[SerializeField]
	private GameObject Bottom;
	[SerializeField]
	private TMP_Text Text;
	
	private List<GameObject> History = new List<GameObject>();
	
	private const string Prefix = "TKirk@SparrowWestS218:~$ ";
	
	private List<Command> Commands = new List<Command>();
	
    // Start is called before the first frame update
    void Start()
    {
		Commands.Add(new RunCommand());
        Text.text = Prefix;
    }

    // Update is called once per frame
    void Update()
    {
        if (Interactable)
		{
			foreach (char c in Input.inputString)
			{
				if (c == '\b') // has backspace/delete been pressed?
				{
					if (Text.text.Length > Prefix.Length)
					{
						Text.text = Text.text.Substring(0, Text.text.Length - 1);
					}
				}
				else if ((c == '\n') || (c == '\r')) // enter/return
				{
					Enter();
				}
				else
				{
					Text.text += c;
				}
			}
		}
    }
	
	public void Finish()
	{
		Enter(false);
		Interactable = true;
	}
	
	public void Write(string text)
	{
		Interactable = false;
		foreach (char c in text)
		{
			if (c == '\b') // has backspace/delete been pressed?
			{
				if (Text.text.Length != 0)
				{
					Text.text = Text.text.Substring(0, Text.text.Length - 1);
				}
			}
			else if ((c == '\n') || (c == '\r')) // enter/return
			{
				Enter(true, false);
			}
			else
			{
				Text.text += c;
			}
		}
	}
	
	private void Enter(bool clearPrefix = false, bool addPrefix = true)
	{
		if (clearPrefix)
		{
			Text.text = Text.text.Substring(Prefix.Length, Text.text.Length - Prefix.Length);
		}
		
		GameObject newText = Instantiate(Bottom, transform);
		
		History.Add(newText);
		Vector2 pos;
		foreach (GameObject text in History)
		{
			pos = text.GetComponent<RectTransform>().anchoredPosition;
			pos.y += 10f;
			text.GetComponent<RectTransform>().anchoredPosition = pos;
		}
		
		/*if (Regex.Match(s, @"^([\w\-]+)").value == "run")
		{
			Commands[0].Parse(
		}
Console.WriteLine(result.Value); // Result is "Hello"*/
		
		Text.text = Prefix;
	}
}
