using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Card : MonoBehaviour
{
    // 각 카드에 랜덤으로 섞긴 값을 넣어 주기위해 값을 받을 수 있는 변수를 만든다.
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // dix 번호를 외부에서 세팅할 수 있는 함수를 만든다.
    // 매개변수 작성, 작성을 하면 외부에서 setting 함수를 호출 할 때 값을 넣어 줄 수 있다.
    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null) return;

        audioSource.PlayOneShot(clip);
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        // firstCard 가 비었다면
        if (GameManager.Instance.firstCard == null)
        {
            // firstCard 에 내 정보를 넘겨준다
            GameManager.Instance.firstCard = this;
        }
        // firstCard 가 비어있지 않다면
        else
        {
            // secondCard 에 내 정보를 넘겨준다
            GameManager.Instance.secondCard = this;
            // Matched 함수를 호줄해 준다
            GameManager.Instance.Matched();
        }
    }

    public void DestoryCard()
    {
        Invoke("DestoryCardInvoke", 0.5f);
    }

    void DestoryCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }
    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
