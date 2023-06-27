using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightGame_Button : MonoBehaviour
{
    public TextMeshProUGUI buttonText; //Текст кнопки ответа
    FightGame_GameProcess fightGame_GameProcess; //Экземпляр класса FightGame_GameProcess
    FightGame_EnergyBar fightGame_EnergyBar; //Экземпляр класса FightGame_EnergyBar
    public Image enemyHealthBar; // Полоса здоровья врага

    public Animator enemyAnim; //Аниматор врага
    public Animator heroAnim; //Аниматор героя

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

    public void Button_Click() // Метод нажатия кнопки
    {
        fightGame_EnergyBar.button_Clicked = true; // Переменная останавливает движение полосы энергии в скрипте EnergyBarё

        if (buttonText.text == $"{fightGame_GameProcess.result}") // Если выбран верный ответ
        {
            enemyAnim = fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].GetComponent<Animator>(); // Аниматор врага   

            fightGame_GameProcess.scoreText.text = fightGame_GameProcess.score.ToString(); // Текст берет значение переменной счета

            fightGame_GameProcess.damage = Mathf.Round(fightGame_EnergyBar.timeLeft) / 100; // Переменная damage хранит оставшее время игрока по время ответа,
                                                                                            // но т.к. максимальное значение fillAmount у Image объектов = 1,
                                                                                            // для верной работы метода необходимо оставшееся время поделить на 100,
                                                                                            // чтобы образовать примерно верную пропорцию (прим. 1 - 0,07 = 100 - 7)

            if (fightGame_GameProcess.damage >= enemyHealthBar.fillAmount) //Если урон больше здоровья            
            {
                fightGame_GameProcess.score += 1f; // Засчитывается одно очко за победу над врагом
                fightGame_GameProcess.scoreText.text = fightGame_GameProcess.score.ToString(); // Текст берет значение переменной счета

                fightGame_EnergyBar.button_Clicked = true; // Останавливает движение полосы времени

                enemyAnim = fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].GetComponent<Animator>(); // Аниматор врага

                enemyHealthBar.fillAmount = 0; // Здоровье равно нулю
                enemyHealth.text = $"{enemyHealthBar.fillAmount}"; // Вывод текста

                enemyAnim.SetTrigger("enemyDeath"); // Анимация смерти 
                heroAnim.SetTrigger("correctAnswer"); // Анимация удара героя

                Invoke("EnemyDeath", 1);
            }
            else
            {
                
                enemyAnim.SetTrigger("correctAnswer"); // Активация анимации верного ответа у врага
                heroAnim.SetTrigger("correctAnswer"); // Активация анимации верного ответа у героя
                enemyHealthBar.fillAmount -= fightGame_GameProcess.damage; // Полоса здоровья уменьшается
                enemyHealth.text = $"{Mathf.Round(enemyHealthBar.fillAmount * 100)}";
                Invoke("AfterAnimation", 1f); // Задержка метода необходима для полного произведения анимации
            }
        }
        else // Неверный ответ
        {
            fightGame_EnergyBar.button_Clicked = true; // Останавливает движение полосы времени

            enemyAnim = fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].GetComponent<Animator>(); // Аниматор врага

            enemyAnim.SetTrigger("wrongAnswer"); // Анимация неверного ответа у врага
            heroAnim.SetTrigger("wrongAnswer"); // Анимация неверного ответа у героя

            fightGame_EnergyBar.timeLeft = 10f; // Обновление полосы времени
            fightGame_GameProcess.score = 0f; // Обнуляется счет

            fightGame_GameProcess.scoreText.text = fightGame_GameProcess.score.ToString(); // Текст берет значение переменной счета

            fightGame_EnergyBar.lifes[fightGame_GameProcess.lifesCount-1].SetActive(false); // Скрывается одно изображение жизни

            fightGame_GameProcess.lifesCount -= 1;  // Уменьшается значение количества жизней

            if (fightGame_GameProcess.lifesCount == 0) // Если закончились жизни
            {
                heroAnim.SetTrigger("heroDeath");

                Invoke("GameOver", 1);
            }
            else // Если жизни еще есть
            {
                Invoke("AfterAnimation", 1f); // Задержка метода необходима для полного произведения анимации
            }
        }
    }

    void AfterAnimation() // Метод создания следующего примера
    {

        fightGame_EnergyBar.timeLeft = 10f; // Обновление времени

        fightGame_GameProcess.Game();  // Создание нового примера

        fightGame_EnergyBar.button_Clicked = false; // Запуск полосы времени
    }
    void hideUI()
    {
        fightGame_EnergyBar.ui_Game.gameObject.SetActive(false);
    }

    void EnemyDeath()
    {
        fightGame_EnergyBar.energyBar_fill.fillAmount = 1;
        enemyHealthBar.fillAmount = 1; // Заполнение полосы здоровья
        enemyHealth.text = $"{enemyHealthBar.fillAmount * 100}"; // Вывод текста здоровья
        fightGame_GameProcess.Game();  // Создание нового примера
        fightGame_EnergyBar.timeLeft = 10f; // Обновление времени

        fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].SetActive(false); // Деактивация текущего врага
        fightGame_GameProcess.enemiesIcons[fightGame_GameProcess.currentEnemy].SetActive(false); // Деактивация иконки текущего врага

        while(fightGame_GameProcess.currentEnemy == fightGame_GameProcess.lastEnemy) // Для избежания повтора
        {
            fightGame_GameProcess.currentEnemy = Random.Range(0, 3);
        }

        fightGame_GameProcess.lastEnemy = fightGame_GameProcess.currentEnemy; // Фиксация последнего номера врага чтобы сравнить его в новым и избежать повтора

        fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].SetActive(true);      //Активация нового врага
        fightGame_GameProcess.enemiesIcons[fightGame_GameProcess.currentEnemy].SetActive(true); // и его иконки
        enemyAnim = fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].GetComponent<Animator>(); // Аниматор врага
        enemyAnim.SetTrigger("enemyAppearance");

        Invoke("TimerStart", 1);
    }

    void TimerStart()
    {
        fightGame_EnergyBar.button_Clicked = false; // Запуск полосы времени
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
