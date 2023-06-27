using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightGame_EnergyBar : MonoBehaviour
{
    FightGame_GameProcess fightGame_GameProcess; // ������ ����

    public TextMeshProUGUI energyText; // ����� �������
    public Image energyBar_fill; // ����������� ������ �������

    public float time = 10f; // ���������� �������
    public float timeLeft = 10f; // ������� �������

    Animator heroAnim; // �������� �����
    Animator enemyAnim; // �������� ����� 

    public GameObject ui_Game;

    public GameObject heroFirstLife; // ����������� ������ �����
    public GameObject heroSecondLife; // ����������� ������ �����
    public GameObject heroThirdLife;  // ����������� ������� �����

    public GameObject[] lifes; // ������ ����������� ������

    bool invoke = false; // ������������ �������� �������

    public bool button_Clicked = false; // ���������� ������ �� ��� ������ �� ������

    private void Start()
    {
        lifes = new[] { heroThirdLife, heroSecondLife, heroFirstLife }; // ������ � �������� �������� ������

        energyText.text = "10"; // ��������� �������� �������

        heroAnim = GameObject.Find("Hero").GetComponent<Animator>(); // �������� �����

        fightGame_GameProcess = GameObject.Find("Canvas").GetComponent<FightGame_GameProcess>(); // ������ FightGame_GameProcess
        energyBar_fill.GetComponent<Image>(); // �������� ��������� Image ������� energyBar_fill
    }
    void Update()
    {
        if (timeLeft > 0) // ��������� ���� �� ����� �����
        {
            invoke = false; // � ������, ���� ����� �����, ���������� ��������� ������ ��� ������������ ��������,
                            // �� ���� �������� else, ������� ����� �������� ����������, �.�. ������� ������� ��
                            // �����������, � ������ ����� ����� ����������� else.
                            // ���� ����� �� ����� ���������� invoke ��������� ������������� �������� false,
                            // ����� �������� else if, � ������� invoke ���������� true, ������ ��� ����,
                            // ����� ������� ��������� ���� ���, �� � ���� �� ����� ���� �� ��������� �����,
                            // ��� ��������� ����� � ������� ����� ���� � ��������� ����

            if (button_Clicked == false) // ����� ������� ������ ������ ���������� button_Clicked ���������� true, 
                                         // � ������� �������� ������ ������� ���������������
            {
                timeLeft -= Time.deltaTime; // ������
                energyBar_fill.fillAmount = timeLeft / time; // �������� ������ �������
            }
            energyText.text = Mathf.RoundToInt(timeLeft).ToString(); //����� ������� �� �����
        }
        else if(!invoke)
        {
            enemyAnim = fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].GetComponent<Animator>(); // ����� �������� ��������� ����� �� �������
            invoke = true; // ���������� �������� ������������� ��� ����, ����� ������� ��������� ���� ���
            enemyAnim.SetTrigger("wrongAnswer"); // ������������ �������� ��������� ������ � ��������� �����
            heroAnim.SetTrigger("wrongAnswer"); // ������������ �������� ��������� ������ � ��������� ����

            lifes[fightGame_GameProcess.lifesCount - 1].gameObject.SetActive(false); // ���� ���������� ����� ����������� ������ �������,
                                                                                     // ����� �������� ����� ���������� ���������� ������                
            fightGame_GameProcess.lifesCount -= 1; // ���� ���������� ����� ���������� ���� �� ������

            Invoke("afterAnimation", 1f); // ����� ���������� � ��������� � �������,
                                          // ����� �������� ����� ������ ���������
        }
    }
    void afterAnimation() // � ������ ���� � ������ ����������� ����� ���������� ����� ���������,
                          // � ���� ������ ����������� �����
    {
        if (fightGame_GameProcess.lifesCount == 0) // � ������ ���� � ������ ����������� ����� ���������� ����� ���������
        {
            ui_Game.gameObject.SetActive(false);
        }
        else // � ���� ������ ����������� �����
        {
            timeLeft = 10f;
            fightGame_GameProcess.Game();
        }
    }
}
