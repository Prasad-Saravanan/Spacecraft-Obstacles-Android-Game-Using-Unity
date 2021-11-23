using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

	public delegate void GameDelegate();
	public static event GameDelegate OnGameStarted;
	public static event GameDelegate OnGameOverConfirmed;

	public static GameManager Instance;

	public GameObject startPage;
	public GameObject gameOverPage;
	public GameObject countdownPage;
    public GameObject enterNamePage;
    //public GameObject leaderboardPage;
    public Button btnOK;
	public Text scoreText;
    public Text enterName;
    

	enum PageState {
		None,
		Start,
		Countdown,
        enterName,
		GameOver
	}

	int score = 0;
	bool gameOver = true;
    public bool created;

    public bool GameOver { get { return gameOver; } }

	void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


	void OnEnable() {
		TapController.OnPlayerDied += OnPlayerDied;
		TapController.OnPlayerScored += OnPlayerScored;
		CountdownText.OnCountdownFinished += OnCountdownFinished;
	}

	void OnDisable() {
		TapController.OnPlayerDied -= OnPlayerDied;
		TapController.OnPlayerScored -= OnPlayerScored;
		CountdownText.OnCountdownFinished -= OnCountdownFinished;
        
    }

	void OnCountdownFinished() {
		SetPageState(PageState.None);
		OnGameStarted();
		score = 0;
		gameOver = false;
	}

	void OnPlayerScored() {
		score++;
		scoreText.text = score.ToString();
	}

	public void OnPlayerDied() {
		gameOver = true;
		int savedScore = PlayerPrefs.GetInt("HighScore");
		if (score > savedScore)
        {
            enterNamePage.SetActive(true);
            PlayerPrefs.SetInt("HighScore", score);
            enterNamePage.SetActive(false);
        }
		SetPageState(PageState.GameOver);
	}

	void SetPageState(PageState state) {
		switch (state) {
			case PageState.None:
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
                enterNamePage.SetActive(false);
				break;
			case PageState.Start:
				startPage.SetActive(true);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
                enterNamePage.SetActive(false);
                break;
			case PageState.Countdown:
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(true);
                enterNamePage.SetActive(false);
                break;
			case PageState.GameOver:
				startPage.SetActive(false);
				gameOverPage.SetActive(true);
				countdownPage.SetActive(false);
                //enterNamePage.SetActive(false);
                break;
        }
	}
	
	public void ConfirmGameOver() {
		SetPageState(PageState.Start);
		scoreText.text = "0";
		OnGameOverConfirmed();
	}

    //public void Name()
    //{
        //PlayerPrefs.GetString("Name");
        //enterNamePage.SetActive(false);
    //}

	public void StartGame() {
		SetPageState(PageState.Countdown);
	}

}
