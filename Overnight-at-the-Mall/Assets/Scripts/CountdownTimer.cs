using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CountdownTimer : MonoBehaviour
{
	public float m_startingMinutes; //in seconds
	public bool m_startTimer = false;
	public GUIText m_timerLabel; //drag GUIText in the scene here
	
	private float m_miliseconds;
	private float m_seconds;
	private float m_mins;
	private float m_totalmiliseconds;

	private GUIStyle style;

	// Use this for initialization
	void Start()
	{	
		m_startingMinutes = GlobalValues.S.startTime ();
		this.Init(m_startingMinutes);
		style = new GUIStyle();
		style.richText = true;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(GlobalValues.S.isGameDone() || GlobalValues.S.isGameOver()){
			return;
		}
		if (m_startTimer && m_totalmiliseconds >= 0)
		{
			if (m_miliseconds <= 0)
			{
				if (m_seconds <= 0)
				{
					m_mins--;
					m_seconds = 59;
				}
				else
				{
					m_seconds--;
				}
				
				m_miliseconds = 99;
			}
			
			m_miliseconds -= Time.deltaTime * 100;
			m_totalmiliseconds -= Time.deltaTime * 100;
		}
		else if (m_totalmiliseconds <= 0)
		{
			m_miliseconds = 0.0f;
			m_seconds = 0.0f;
			m_mins = 0.0f;
			GlobalValues.S.timeOver();
		}
	}
	void OnGUI(){
		GUI.contentColor = Color.white;
		GUI.Label(new Rect(Screen.width - 250, 0, Screen.width, Screen.height),
		          string.Format("<size=20><color=white>Until mall opens: {0:d2}:{1:d2}:{2:d2}</color></size>", (int) m_mins, (int) m_seconds, (int)m_miliseconds),
		          style);
	}
	
	/// <summary>
	/// Public function to initialize the timer
	/// </summary>
	/// <param name="p_startingTime"></param>
	public void Init(float p_startingTime)
	{
		//On the note of PlayerPrefs, you may want to read them in here on the initialize      
		m_totalmiliseconds = p_startingTime * (60/*seconds*/) * (100/*miliseconds*/);
		m_mins = p_startingTime;
		m_startTimer = true;
	}
	
	/// <summary>
	/// Public function to pause the timer
	/// </summary>
	/// <param name="p_pause"></param>
	public void PauseTimer(bool p_pause)
	{
		m_startTimer = p_pause;
	}
}