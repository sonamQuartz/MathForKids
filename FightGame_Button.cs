using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightGame_Button : MonoBehaviour
{
    public TextMeshProUGUI buttonText; //����� ������ ������
    FightGame_GameProcess fightGame_GameProcess; //��������� ������ FightGame_GameProcess
    FightGame_EnergyBar fightGame_EnergyBar; //��������� ������ FightGame_EnergyBar
    public Image enemyHealthBar; // ������ �������� �����

    public Animator enemyAnim; //�������� �����
    public Animator heroAnim; //�������� �����

    public TextMeshProUGUI enemyHealth;

    public GameObject startScreensaver;
    public GameObject endScreensaver;

    public GameObject restartButton;
    public GameObject gameOverBackground;

    private void Start()
    {
        fightGame_EnergyBar = GameObject.Find("Bar").GetComponent<FightGame_EnergyBar>();
        fightGame_GameProcess = GameObject.Find("Canvas").GetComponent<FightGame_GameProcess>();
    }

    public void Button_Click() // ����� ������� ������
    {
        fightGame_EnergyBar.button_Clicked = true; // ���������� ������������� �������� ������ ������� � ������� EnergyBar�

        if (buttonText.text == $"{fightGame_GameProcess.result}") // ���� ������ ������ �����
        {
            enemyAnim = fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].GetComponent<Animator>(); // �������� �����   

            fightGame_GameProcess.scoreText.text = fightGame_GameProcess.score.ToString(); // ����� ����� �������� ���������� �����

            fightGame_GameProcess.damage = Mathf.Round(fightGame_EnergyBar.timeLeft) / 100; // ���������� damage ������ �������� ����� ������ �� ����� ������,
                                                                                            // �� �.�. ������������ �������� fillAmount � Image �������� = 1,
                                                                                            // ��� ������ ������ ������ ���������� ���������� ����� �������� �� 100,
                                                                                            // ����� ���������� �������� ������ ��������� (����. 1 - 0,07 = 100 - 7)

            if (fightGame_GameProcess.damage >= enemyHealthBar.fillAmount) //���� ���� ������ ��������            
            {
                fightGame_GameProcess.score += 1f; // ������������� ���� ���� �� ������ ��� ������
                fightGame_GameProcess.scoreText.text = fightGame_GameProcess.score.ToString(); // ����� ����� �������� ���������� �����

                fightGame_EnergyBar.button_Clicked = true; // ������������� �������� ������ �������

                enemyAnim = fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].GetComponent<Animator>(); // �������� �����

                enemyHealthBar.fillAmount = 0; // �������� ����� ����
                enemyHealth.text = $"{enemyHealthBar.fillAmount}"; // ����� ������

                enemyAnim.SetTrigger("enemyDeath"); // �������� ������ 
                heroAnim.SetTrigger("correctAnswer"); // �������� ����� �����

                Invoke("EnemyDeath", 1);
            }
            else
            {
                
                enemyAnim.SetTrigger("correctAnswer"); // ��������� �������� ������� ������ � �����
                heroAnim.SetTrigger("correctAnswer"); // ��������� �������� ������� ������ � �����
                enemyHealthBar.fillAmount -= fightGame_GameProcess.damage; // ������ �������� �����������
                enemyHealth.text = $"{Mathf.Round(enemyHealthBar.fillAmount * 100)}";
                Invoke("AfterAnimation", 1f); // �������� ������ ���������� ��� ������� ������������ ��������
            }
        }
        else // �������� �����
        {
            fightGame_EnergyBar.button_Clicked = true; // ������������� �������� ������ �������

            enemyAnim = fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].GetComponent<Animator>(); // �������� �����

            enemyAnim.SetTrigger("wrongAnswer"); // �������� ��������� ������ � �����
            heroAnim.SetTrigger("wrongAnswer"); // �������� ��������� ������ � �����

            fightGame_EnergyBar.timeLeft = 10f; // ���������� ������ �������
            fightGame_GameProcess.score = 0f; // ���������� ����

            fightGame_GameProcess.scoreText.text = fightGame_GameProcess.score.ToString(); // ����� ����� �������� ���������� �����

            fightGame_EnergyBar.lifes[fightGame_GameProcess.lifesCount-1].SetActive(false); // ���������� ���� ����������� �����

            fightGame_GameProcess.lifesCount -= 1;  // ����������� �������� ���������� ������

            if (fightGame_GameProcess.lifesCount == 0) // ���� ����������� �����
            {
                heroAnim.SetTrigger("heroDeath");

                Invoke("GameOver", 1);
            }
            else // ���� ����� ��� ����
            {
                Invoke("AfterAnimation", 1f); // �������� ������ ���������� ��� ������� ������������ ��������
            }
        }
    }

    void AfterAnimation() // ����� �������� ���������� �������
    {

        fightGame_EnergyBar.timeLeft = 10f; // ���������� �������

        fightGame_GameProcess.Game();  // �������� ������ �������

        fightGame_EnergyBar.button_Clicked = false; // ������ ������ �������
    }
    void hideUI()
    {
        fightGame_EnergyBar.ui_Game.gameObject.SetActive(false);
    }

    void EnemyDeath()
    {
        fightGame_EnergyBar.energyBar_fill.fillAmount = 1;
        enemyHealthBar.fillAmount = 1; // ���������� ������ ��������
        enemyHealth.text = $"{enemyHealthBar.fillAmount * 100}"; // ����� ������ ��������
        fightGame_GameProcess.Game();  // �������� ������ �������
        fightGame_EnergyBar.timeLeft = 10f; // ���������� �������

        fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].SetActive(false); // ����������� �������� �����
        fightGame_GameProcess.enemiesIcons[fightGame_GameProcess.currentEnemy].SetActive(false); // ����������� ������ �������� �����

        while(fightGame_GameProcess.currentEnemy == fightGame_GameProcess.lastEnemy) // ��� ��������� �������
        {
            fightGame_GameProcess.currentEnemy = Random.Range(0, 3);
        }

        fightGame_GameProcess.lastEnemy = fightGame_GameProcess.currentEnemy; // �������� ���������� ������ ����� ����� �������� ��� � ����� � �������� �������

        fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].SetActive(true);      //��������� ������ �����
        fightGame_GameProcess.enemiesIcons[fightGame_GameProcess.currentEnemy].SetActive(true); // � ��� ������
        enemyAnim = fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].GetComponent<Animator>(); // �������� �����
        enemyAnim.SetTrigger("enemyAppearance");

        Invoke("TimerStart", 1);
    }

    void TimerStart()
    {
        fightGame_EnergyBar.button_Clicked = false; // ������ ������ �������
    }

    void GameOver()
    {
        endScreensaver.SetActive(true);
        Invoke("GameOverScene", 1);

    }
    void GameOverScene()
    {
        endScreensaver.SetActive(false);
        startScreensaver.SetActive(true);

        restartButton.SetActive(true);
        gameOverBackground.SetActive(true);

        Invoke("ScreensaverEnd", 1);
    }

    void ScreensaverEnd()
    {
        startScreensaver.SetActive(false);
    }
}
