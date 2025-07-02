using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // text는 ui component로 using을 사용해야 쓸 수 있다.

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public Text timeTxt; // component를 사용하기 전에 먼저  public로 불러 와야한다.
    public GameObject endTxt;

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;
    float time = 0.0f; //시간을 표기 하기 전에 먼저 시간을 담을 수 있는 변수가 필요하다.

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; // 시간을 계속 추가해 줘야 하니까 += 사용한다, 그리고 고정으로 'Time.deltaTime' 사용. (값을 계속 더해주는 코드)
        timeTxt.text = time.ToString("N2"); // text component 안에 있는 text에 넣어 줘야 한다, 그리고 ToString은 문자열로 변경해 주는 코드다, 'N2'는 소수점 2자리 까지 표기해 준다.

        if (time > 30.0f)
        {
            Time.timeScale = 0.0f;
            endTxt.SetActive(true);
        }
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            // 파괴하라
            audioSource.PlayOneShot(clip);
            firstCard.DestoryCard();
            secondCard.DestoryCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            // 닫아라
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
}
