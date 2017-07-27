using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



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

    public UserInfo userInfoVar;

    private void Awake()
    {
        Instance = this;    
    }

    void Start()
    {
        StartCoroutine(MoveBackground());
        StartCoroutine("MainGameLoop");
        ChangeScene = GameScene.Title;
        StartCoroutine(TestCo());
        LoadGame();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        userInfoVar.score = AllyShip.Instance.thisShipScore;
        bf.Serialize(file, userInfoVar);
        file.Close();
    }

    public void LoadGame()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            UserInfo data = (UserInfo)bf.Deserialize(file);
            file.Close();

            userInfoVar = data;
            AllyShip.Instance.thisShipScore = data.score;
        }
    }

    private bool testBool;
    IEnumerator TestCo()
    {
        float val = 0;
        while(val < 2)
        {
            //Debug.Log(Time.time);
            val += Time.deltaTime;
            if(!testBool && val > 1)
            {
                Debug.Log("컷씬...");
                Time.timeScale = 0;
                yield return StartCoroutine(Test2());
            }

            
            Time.timeScale = 1;
            yield return null;
        }
    }

    IEnumerator Test2()
    {
        testBool = true;
        yield return new WaitForSecondsRealtime(2);

        Debug.Log("원래 씬으로...");
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
        SaveGame();
    }
}
