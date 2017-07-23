using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameScene
{
    Title, Stage, InterMission,    
}

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public float scrollSpeed;
    public float length;
    public Transform backTransform;
    private GameScene CurrentScene;
    private bool moveOn;

    private void Awake()
    {
        Instance = this;    
    }

    void Start()
    {
        StartCoroutine(MoveBackground());
        StartCoroutine("MainGameLoop");
    }

    IEnumerator MoveBackground()
    {
        Vector3 startPosition = backTransform.position;
        moveOn = true;
        while(moveOn)
        {
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, length);
            backTransform.position = startPosition + Vector3.left * newPosition;
            yield return null;
        }
    }

    public GameScene ChangeScene
    {
        get { return CurrentScene; }
        set {
            if(value != CurrentScene)
            {
                CurrentScene = value;
                GameSceneChanged(CurrentScene);
            }
        }
    }

    public void GameSceneChanged(GameScene scene)
    {
        Debug.Log("Game scene changed to " + scene);
    }

    IEnumerator MainGameLoop()
    {
        for (;;)
        {
            while(CurrentScene == GameScene.Title)
            {
                yield return StartCoroutine(Title());
            }
            while (CurrentScene == GameScene.Stage)
			{
				yield return StartCoroutine(StagePlay());
			}
            while (CurrentScene == GameScene.InterMission)
			{
				yield return StartCoroutine(InterMission());
			}
        }
    }

    IEnumerator Title()
    {
        while(CurrentScene == GameScene.Title)
        {
            yield return null;
        }
    }

	IEnumerator StagePlay()
	{
		while (CurrentScene == GameScene.Stage)
		{
			yield return null;
		}
	}

	IEnumerator InterMission()
	{
		while (CurrentScene == GameScene.InterMission)
		{
			yield return null;
		}
	}

    public void AddScore(int amount)
    {
        AllyShip.Instance.thisShipScore = AllyShip.Instance.thisShipScore + amount;
    }
}
