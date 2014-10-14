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
	
	//-----------------------------------------------------------------------------------
	//Note: If you had a way to take in a username or initials you could 
	//do something along the lines of the below code instead of just using 
	//a list
	//
	//private Dictionary<string, int> m_scoreDictionary = new Dictionary<string, int>();
	//
	//With a dictionary you could link a name to a score value, just a thought :P
	//For now this script just uses the list set up below.
	//-----------------------------------------------------------------------------------
	private List<int> m_scores = new List<int>();
	
	// Use this for initialization
	void Start()
	{	
		m_startingMinutes = GlobalValues.S.startTime ();
		this.Init(m_startingMinutes);
		//m_timerLabel = guiText;
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
		}/*
		
		if ((int)m_miliseconds > 9)
		{
			m_timerLabel.text = string.Format("{0}:{1}:{2}", m_mins, m_seconds, (int)m_miliseconds);
		}
		else
		{
			m_timerLabel.text = string.Format("{0}:{1}:0{2}", m_mins, m_seconds, (int)m_miliseconds);
		}*/

	}
	void OnGUI(){
		if ((int)m_miliseconds > 9)
		{
		//	m_timerLabel.text = string.Format("{0}:{1}:{2}", m_mins, m_seconds, (int)m_miliseconds);
			GUI.Label(new Rect(Screen.width-50, 0, Screen.width, Screen.height), string.Format("{0}:{1}:{2}", m_mins, m_seconds, (int)m_miliseconds));
		}
		else
		{
		//	m_timerLabel.text = string.Format("{0}:{1}:0{2}", m_mins, m_seconds, (int)m_miliseconds);
			GUI.Label(new Rect(Screen.width-50, 0, Screen.width, Screen.height), string.Format("{0}:{1}:0{2}", m_mins, m_seconds, (int)m_miliseconds));
		}
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
	
	/// <summary>
	/// Store the score in a list
	/// </summary>
	public void StoreScore()
	{
		//Store the total milisceconds left in as the score so it we want to
		//use it later we have a number we can format back into MM:SS:mm
		this.m_scores.Add((int)m_totalmiliseconds);
		
		//Something to consider here is that these score will not be persistent 
		//between games, you may want to consider using the PlayerPrefs to store
		//a string that can be parsed out and fed back into the m_scores list.
		//link: http://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.html
		
	}

	/*private Camera perspective;
	private Camera orthographic;
	void Awake(){
		perspective = GameObject.Find ("Main Camera").camera;
		orthographic = GameObject.Find ("Main Camera").camera;
	}
	void LateUpdate()
	{       
		var position = perspective.WorldToNormalizedViewportPoint(transform.position);
		transform.localPosition = orthographic.NormalizedViewportToWorldPoint(position);
	}*/
}