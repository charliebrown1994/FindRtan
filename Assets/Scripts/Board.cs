using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using System.Linq; // 랜덤으로 섞기 위해 사용되는 using.

public class Board : MonoBehaviour
{
    public GameObject card; // prefab를 받아오는 코드

    // Start is called before the first frame update
    void Start()
    {
        // 카드를 렌덤으로 섞기 위해 ' [] ' 배열 함수를 써준다.
        // 배열은 동일한 자료들이 여러개 들어갈 수 있는 코드다.
        // 처음에 정해진 크기 만큼만 사용 가능.
        // arr[4]; 는 4번째 숫자를 자져오라는 명령으로 0부터 시작해 앞에 2가 나온다.
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();
        // 위 코드 해석:
        // arr 배열에서 orderdy 정렬을하다, 소괄호에 있는 코드는 어떻게 정렬을 진행할지 정의해 주는 코드다 ' x => Random.Range(0f, 7f) ', ' => ' 배열을 순서대로 한번씩 순해한다는 뜻, ' Random.Range(0f, 7f) ' 랜덤으로 range 범위에 있는 숫자들로 순해한다는 뜻, ' .ToArray() ' 배열로 다시 정리해 준다라는 뜻. ' arr = arr ' 기존에 arr에 다시 넣어준다는 뜻.

        // 일정 범위가 있는 반복문은 for 를 사용한다, 안에 3개의 값이 들어 간다.
        // 1. 'int i = 0;' 초기화 값 몇 번 반복 할지 조건을 정해준다.
        // 2. 'i < 16;' i 가 16보다 작으면 계속해서 중괄호에 있는 로직을 실행한다.
        // 3. 'i++' 중괄호 안에 로직을 실행 할 때 마다 i에 값을 하나 씩 증가해 준다.
        for (int i = 0; i < 16; i++)
        {
            GameObject go = Instantiate(card, this.transform); // object를 생성만 하면 좌표값이나 다른걸 할 수가 없다 생성과 동시에 변수를 지정로 지정하면 가능하다.

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;

            go.transform.position = new Vector2(x, y); // 생성된 object에 좌표값을 지정하려면 변수를 지정해야한다.
            // instantiate 일단 지금 이해한건 object를 생성 하기 위해 사용 하는 함수다. 
            // 생성된 게임 object의 위치를 정해 주기위해 변수 추가 'this.transform' 여기서 this는 object 자체에 생성해야 함으로 'this'를 사용.
            
            go.GetComponent<Card>().Setting(arr[i]);
        }

        GameManager.Instance.cardCount = arr.Length;
    }
}
