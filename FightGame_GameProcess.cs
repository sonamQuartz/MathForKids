using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightGame_GameProcess : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //����� ���������� �����
    public float score = 0f; //���������� �����

    int lastNumberOne;  // ����������, � ������� �������� ��������� �������� �������
    int lastNumberTwo;  // � ������, ���� �������� ������� � ����� ������, ���������� numberOne numberTwo
    int lastNumberThree;  // ����� ��������������� �� ��������� �������

    int numberOne; //������ ���������� � ������
    int numberTwo; //������ ���������� � ������
    int numberThree; //������ ����� � ������� ����

    public TextMeshProUGUI taskText; //����� ������

    public int result;  //���������

    int numberOfRightAnswer; // ���������� �� ��������� ������� ����������� ������ 

    int var;    //������ ��������� ����������, ������� �����
                //��������� ������� ����� ���������� � ��������� �������

    int[] answers = new int[4]; //������ �������

    public TextMeshProUGUI blueButtonText;   //����� ������
    public TextMeshProUGUI redButtonText;    //����� ������
    public TextMeshProUGUI purpleButtonText; //����� ������
    public TextMeshProUGUI greenButtonText;  //����� ������

    public float damage; // ����

    public float health = 100; // �������� �����

    public int lifesCount = 3; // ����� �����

    public GameObject energyBar; // ������ �������

    public GameObject skeleton;
    public GameObject ogre;
    public GameObject stone;

    public GameObject skeletonIcon;
    public GameObject ogreIcon;
    public GameObject stoneIcon;

    public GameObject[] enemies; // ������ ������
    public GameObject[] enemiesIcons;

    public int currentEnemy; // ��������� �������� � �������� ������ ����� �� ������� �������� �������� �������
    public int lastEnemy; // ��������� �������� � �������� ������ ����� �� ������� �������� �������� �������

    public void Game() //�������� ����� �������� ��������
    {
        if (PlayerPrefs.GetString("MathMode") == "+" && PlayerPrefs.GetString("Difficulty") == "Easy")
        {

            taskText.fontSize = 200;

            numberOne = Random.Range(1, 10);    // ��������� �������� ���� ���������
            numberTwo = Random.Range(1, 10);    // ��������� �������� ���� ���������
                                                // 
            taskText.text = $"{numberOne} + {numberTwo}";   // ����� ������ �� �����

            result = numberOne + numberTwo; // ������ ����������

            numberOfRightAnswer = Random.Range(0, 3); //��������� ����� ������� ������� ������

            for (int i = 0; i < answers.Length; i++) //����, ����������� ������ ������� ����������
            {

                var = Random.Range(-3, 3);    //������ ��������� ����������, ������� �����
                                              //��������� ������� ����� ���������� � ��������� �������
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                else answers[i] += var;                                     //������������� �����, ������� ������ var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[1] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[1] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[2] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[2] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[3] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[3] += var;                                     //������������� �����, ������� ������ var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // ���� ���� ����� ��������� � �������� ������� ������
            }                                                           // ������ ������� ������������� ������ �����

            blueButtonText.text = $"{answers[0]}";      // ������������ ��������� ����������
            redButtonText.text = $"{answers[1]}"; ;     // �������� ������� �������
            purpleButtonText.text = $"{answers[2]}";    //
            greenButtonText.text = $"{answers[3]}";     //

        }
        if (PlayerPrefs.GetString("MathMode") == "+" && PlayerPrefs.GetString("Difficulty") == "Middle")
        {

            taskText.fontSize = 170;

            numberOne = Random.Range(10, 100);    // ��������� �������� ���� ���������
            numberTwo = Random.Range(10, 100);    // ��������� �������� ���� ���������
                                                  // 
            taskText.text = $"{numberOne} + {numberTwo}";   // ����� ������ �� �����

            result = numberOne + numberTwo; // ������ ����������

            numberOfRightAnswer = Random.Range(0, 3); //��������� ����� ������� ������� ������

            for (int i = 0; i < answers.Length; i++) //����, ����������� ������ ������� ����������
            {

                var = Random.Range(-5, 5);    //������ ��������� ����������, ������� �����
                                              //��������� ������� ����� ���������� � ��������� �������
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                else answers[i] += var;                                     //������������� �����, ������� ������ var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-5, 5);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[1] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[1] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[2] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[2] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[3] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[3] += var;                                     //������������� �����, ������� ������ var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // ���� ���� ����� ��������� � �������� ������� ������
            }                                                           // ������ ������� ������������� ������ �����

            blueButtonText.text = $"{answers[0]}";      // ������������ ��������� ����������
            redButtonText.text = $"{answers[1]}"; ;     // �������� ������� �������
            purpleButtonText.text = $"{answers[2]}";    //
            greenButtonText.text = $"{answers[3]}";     //

        }
        if (PlayerPrefs.GetString("MathMode") == "+" && PlayerPrefs.GetString("Difficulty") == "Hard")
        {

            taskText.fontSize = 120;

            numberOne = Random.Range(10, 100);    // ��������� �������� ���� ���������
            numberTwo = Random.Range(10, 100);    // ��������� �������� ���� ���������
            numberThree = Random.Range(10, 100);    // ��������� �������� ���� ���������
                                                    // 
            taskText.text = $"{numberOne} + {numberTwo} + {numberThree}";   // ����� ������ �� �����

            result = numberOne + numberTwo + numberThree; // ������ ����������

            numberOfRightAnswer = Random.Range(0, 3); //��������� ����� ������� ������� ������

            for (int i = 0; i < answers.Length; i++) //����, ����������� ������ ������� ����������
            {

                var = Random.Range(-3, 3);    //������ ��������� ����������, ������� �����
                                              //��������� ������� ����� ���������� � ��������� �������
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                else answers[i] += var;                                     //������������� �����, ������� ������ var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[1] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[1] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[2] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[2] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[3] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[3] += var;                                     //������������� �����, ������� ������ var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // ���� ���� ����� ��������� � �������� ������� ������
            }                                                           // ������ ������� ������������� ������ �����

            blueButtonText.text = $"{answers[0]}";      // ������������ ��������� ����������
            redButtonText.text = $"{answers[1]}"; ;     // �������� ������� �������
            purpleButtonText.text = $"{answers[2]}";    //
            greenButtonText.text = $"{answers[3]}";     //

        }

        if (PlayerPrefs.GetString("MathMode") == "-" && PlayerPrefs.GetString("Difficulty") == "Easy")
        {

            taskText.fontSize = 200;

            numberOne = Random.Range(1, 10);    // ��������� �������� ������������/�����������
            numberTwo = Random.Range(1, 10);    // ��������� �������� ������������/�����������                                             

            if (numberOne > numberTwo || numberOne == numberTwo)  // ����������� ������ ���� ������ �����������
            {
                taskText.text = $"{numberOne} - {numberTwo}";   // ����� ������ �� �����
                result = numberOne - numberTwo; // ������ ����������
            }
            if (numberTwo > numberOne)  // ����������� ������ ���� ������ �����������
            {
                taskText.text = $"{numberTwo} - {numberOne}";   // ����� ������ �� �����
                result = numberTwo - numberOne; // ������ ����������
            }

            numberOfRightAnswer = Random.Range(0, 3);   //��������� ����� ������� ������� ������

            for (int i = 0; i < answers.Length; i++) //����, ����������� ������ ������� ����������
            {

                var = Random.Range(-3, 3);    //������ ��������� ����������, ������� �����
                                              //��������� ������� ����� ���������� � ��������� �������
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                else answers[i] += var;                                     //������������� �����, ������� ������ var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[1] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[1] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[2] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[2] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[3] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[3] += var;                                     //������������� �����, ������� ������ var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // ���� ���� ����� ��������� � �������� ������� ������
            }                                                           // ������ ������� ������������� ������ �����

            blueButtonText.text = $"{answers[0]}";    // ������������ ��������� ����������
            redButtonText.text = $"{answers[1]}"; ;   // �������� ������� �������
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //
        }
        if (PlayerPrefs.GetString("MathMode") == "-" && PlayerPrefs.GetString("Difficulty") == "Middle")
        {

            taskText.fontSize = 170;

            numberOne = Random.Range(10, 100);    // ��������� �������� ������������/�����������
            numberTwo = Random.Range(10, 100);    // ��������� �������� ������������/�����������                                             

            while (!(numberOne > numberTwo && (numberOne - numberTwo > 0)))
            {
                numberOne = Random.Range(10, 100);    // ��������� �������� ������������/�����������
                numberTwo = Random.Range(10, 100);    // ��������� �������� ������������/�����������                                             
            }

            taskText.text = $"{numberOne} - {numberTwo}";   // ����� ������ �� �����
            result = numberOne - numberTwo; // ������ ����������

            numberOfRightAnswer = Random.Range(0, 3);   //��������� ����� ������� ������� ������

            for (int i = 0; i < answers.Length; i++) //����, ����������� ������ ������� ����������
            {

                var = Random.Range(-3, 3);    //������ ��������� ����������, ������� �����
                                              //��������� ������� ����� ���������� � ��������� �������
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                else answers[i] += var;                                     //������������� �����, ������� ������ var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[1] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[1] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[2] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[2] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[3] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[3] += var;                                     //������������� �����, ������� ������ var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // ���� ���� ����� ��������� � �������� ������� ������
            }                                                           // ������ ������� ������������� ������ �����

            blueButtonText.text = $"{answers[0]}";    // ������������ ��������� ����������
            redButtonText.text = $"{answers[1]}"; ;   // �������� ������� �������
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //
        }
        if (PlayerPrefs.GetString("MathMode") == "-" && PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            taskText.fontSize = 120;

            numberOne = Random.Range(10, 100);    // ��������� �������� ������������/�����������
            numberTwo = Random.Range(10, 100);    // ��������� �������� ������������/�����������                                             
            numberThree = Random.Range(10, 100);

            while (!(numberOne > numberTwo && numberOne > numberThree && numberTwo > numberThree && (numberOne - numberTwo - numberThree > 0)))
            {
                numberOne = Random.Range(10, 100);    // ��������� �������� ������������/�����������
                numberTwo = Random.Range(10, 100);    // ��������� �������� ������������/�����������                                             
                numberThree = Random.Range(10, 100);
            }

            taskText.text = $"{numberOne} - {numberTwo} - {numberThree}";   // ����� ������ �� �����
            result = numberOne - numberTwo - numberThree; // ������ ����������

            numberOfRightAnswer = Random.Range(0, 3);   //��������� ����� ������� ������� ������

            for (int i = 0; i < answers.Length; i++) //����, ����������� ������ ������� ����������
            {

                var = Random.Range(-3, 3);    //������ ��������� ����������, ������� �����
                                              //��������� ������� ����� ���������� � ��������� �������
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                else answers[i] += var;                                     //������������� �����, ������� ������ var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[1] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[1] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[2] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[2] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[3] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[3] += var;                                     //������������� �����, ������� ������ var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // ���� ���� ����� ��������� � �������� ������� ������
            }                                                           // ������ ������� ������������� ������ �����

            blueButtonText.text = $"{answers[0]}";    // ������������ ��������� ����������
            redButtonText.text = $"{answers[1]}"; ;   // �������� ������� �������
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //
        }

        if (PlayerPrefs.GetString("MathMode") == "*" && PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            taskText.fontSize = 200;

            numberOne = Random.Range(1, 10);    // ��������� �������� ������������/�����������
            numberTwo = Random.Range(1, 10);    // ��������� �������� ������������/�����������                                             

            while (numberOne == lastNumberOne || numberTwo == lastNumberTwo) //��������, ���������� ��������� ��������
            {
                numberOne = Random.Range(1, 10);    // ��������� �������� ������������/�����������
                numberTwo = Random.Range(1, 10);    // ��������� �������� ������������/�����������   
            }

            lastNumberOne = numberOne;
            lastNumberTwo = numberTwo;

            taskText.text = $"{numberOne} * {numberTwo}";   // ����� ������ �� �����

            result = numberOne * numberTwo; // ������ ����������

            numberOfRightAnswer = Random.Range(0, 3);   //��������� ����� ������� ������� ������

            for (int i = 0; i < answers.Length; i++) //����, ����������� ������ ������� ����������
            {

                var = Random.Range(-3, 3);    //������ ��������� ����������, ������� �����
                                              //��������� ������� ����� ���������� � ��������� �������
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                else answers[i] += var;                                     //������������� �����, ������� ������ var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[1] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[1] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[2] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[2] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[3] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[3] += var;                                     //������������� �����, ������� ������ var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // ���� ���� ����� ��������� � �������� ������� ������
            }                                                           // ������ ������� ������������� ������ �����

            blueButtonText.text = $"{answers[0]}";    // ������������ ��������� ����������
            redButtonText.text = $"{answers[1]}"; ;   // �������� ������� �������
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //

        }
        if (PlayerPrefs.GetString("MathMode") == "*" && PlayerPrefs.GetString("Difficulty") == "Middle")
        {
            taskText.fontSize = 170;

            numberOne = Random.Range(1, 10);    // ��������� �������� ������������/�����������
            numberTwo = Random.Range(1, 10);    // ��������� �������� ������������/�����������                                             
            numberTwo = Random.Range(1, 10);    // ��������� �������� ������������/�����������                                             

            while (numberOne == lastNumberOne || numberTwo == lastNumberTwo || numberThree == lastNumberThree) //��������, ���������� ��������� ��������
            {
                numberOne = Random.Range(1, 10);    // ��������� �������� ������������/�����������
                numberTwo = Random.Range(1, 10);    // ��������� �������� ������������/�����������    
                numberThree = Random.Range(1, 10);    // ��������� �������� ������������/�����������    
            }

            lastNumberOne = numberOne;
            lastNumberTwo = numberTwo;
            lastNumberThree = numberThree;

            taskText.text = $"{numberOne} * {numberTwo} * {numberThree}";   // ����� ������ �� �����

            result = numberOne * numberTwo * numberThree; // ������ ����������

            numberOfRightAnswer = Random.Range(0, 3);   //��������� ����� ������� ������� ������

            for (int i = 0; i < answers.Length; i++) //����, ����������� ������ ������� ����������
            {

                var = Random.Range(-3, 3);    //������ ��������� ����������, ������� �����
                                              //��������� ������� ����� ���������� � ��������� �������
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                else answers[i] += var;                                     //������������� �����, ������� ������ var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[1] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[1] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[2] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[2] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[3] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[3] += var;                                     //������������� �����, ������� ������ var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // ���� ���� ����� ��������� � �������� ������� ������
            }                                                           // ������ ������� ������������� ������ �����

            blueButtonText.text = $"{answers[0]}";    // ������������ ��������� ����������
            redButtonText.text = $"{answers[1]}"; ;   // �������� ������� �������
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //

        }
        if (PlayerPrefs.GetString("MathMode") == "*" && PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            taskText.fontSize = 120;

            numberOne = Random.Range(10, 100);    // ��������� �������� ������������/�����������
            numberTwo = Random.Range(1, 10);    // ��������� �������� ������������/�����������                                             

            while (numberOne == lastNumberOne || numberTwo == lastNumberTwo) //��������, ���������� ��������� ��������
            {
                numberOne = Random.Range(10, 100);    // ��������� �������� ������������/�����������
                numberTwo = Random.Range(1, 10);    // ��������� �������� ������������/�����������   
            }

            lastNumberOne = numberOne;
            lastNumberTwo = numberTwo;

            taskText.text = $"{numberOne} * {numberTwo}";   // ����� ������ �� �����

            result = numberOne * numberTwo; // ������ ����������

            numberOfRightAnswer = Random.Range(0, 3);   //��������� ����� ������� ������� ������

            for (int i = 0; i < answers.Length; i++) //����, ����������� ������ ������� ����������
            {

                var = Random.Range(-3, 3);    //������ ��������� ����������, ������� �����
                                              //��������� ������� ����� ���������� � ��������� �������
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                else answers[i] += var;                                     //������������� �����, ������� ������ var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[1] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[1] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[2] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[2] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[3] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[3] += var;                                     //������������� �����, ������� ������ var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // ���� ���� ����� ��������� � �������� ������� ������
            }                                                           // ������ ������� ������������� ������ �����

            blueButtonText.text = $"{answers[0]}";    // ������������ ��������� ����������
            redButtonText.text = $"{answers[1]}"; ;   // �������� ������� �������
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //

        }

        if (PlayerPrefs.GetString("MathMode") == "/" && PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            taskText.fontSize = 200;

            numberOne = Random.Range(1, 10);    //���������� ���������� ���������� ���������� 
            numberTwo = Random.Range(1, 10);    // 

            while (numberOne % numberTwo != 0 || numberOne == lastNumberOne || numberTwo == lastNumberTwo || numberOne == numberTwo || numberTwo == 1)
            //������ ������� ������������� ��� ����������� ����������� �������
            {
                numberOne = Random.Range(1, 10);    //���������� ���������� ���������� ���������� 
                numberTwo = Random.Range(1, 10);    // 
            }
            taskText.text = $"{numberOne} / {numberTwo}";   // ����� ������ �� �����
            result = numberOne / numberTwo;    // ������ ����������
            lastNumberOne = numberOne;
            lastNumberTwo = numberTwo;

            numberOfRightAnswer = Random.Range(0, 3);   //��������� ����� ������� ������� ������

            for (int i = 0; i < answers.Length; i++) //����, ����������� ������ ������� ����������
            {

                var = Random.Range(-3, 3);    //������ ��������� ����������, ������� �����
                                              //��������� ������� ����� ���������� � ��������� �������
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                else answers[i] += var;                                     //������������� �����, ������� ������ var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[1] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[1] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[2] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[2] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[3] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[3] += var;                                     //������������� �����, ������� ������ var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // ���� ���� ����� ��������� � �������� ������� ������
            }                                                           // ������ ������� ������������� ������ �����

            blueButtonText.text = $"{answers[0]}";    // ������������ ��������� ����������
            redButtonText.text = $"{answers[1]}"; ;   // �������� ������� �������
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //

        }
        if (PlayerPrefs.GetString("MathMode") == "/" && PlayerPrefs.GetString("Difficulty") == "Middle")
        {
            taskText.fontSize = 170;

            numberOne = Random.Range(10, 100);    //���������� ���������� ���������� ���������� 
            numberTwo = Random.Range(1, 10);

            while (numberOne % numberTwo != 0 || numberOne == lastNumberOne || numberTwo == lastNumberTwo || numberOne == numberTwo || numberTwo == 1)
            //������ ������� ������������� ��� ����������� ����������� �������
            {
                numberOne = Random.Range(10, 100);    //���������� ���������� ���������� ���������� 
                numberTwo = Random.Range(1, 10);    // 
            }
            taskText.text = $"{numberOne} / {numberTwo}";   // ����� ������ �� �����
            result = numberOne / numberTwo;    // ������ ����������
            lastNumberOne = numberOne;
            lastNumberTwo = numberTwo;

            numberOfRightAnswer = Random.Range(0, 3);   //��������� ����� ������� ������� ������

            for (int i = 0; i < answers.Length; i++) //����, ����������� ������ ������� ����������
            {

                var = Random.Range(-3, 3);    //������ ��������� ����������, ������� �����
                                              //��������� ������� ����� ���������� � ��������� �������
                answers[i] = result;

                if (answers[i] + var <= 0) answers[i] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                else answers[i] += var;                                     //������������� �����, ������� ������ var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[1] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[1] + var <= 0) answers[1] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[1] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[2] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[2] + var <= 0) answers[2] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[2] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[3] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[3] + var <= 0) answers[3] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[3] += var;                                     //������������� �����, ������� ������ var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // ���� ���� ����� ��������� � �������� ������� ������
            }                                                           // ������ ������� ������������� ������ �����

            blueButtonText.text = $"{answers[0]}";    // ������������ ��������� ����������
            redButtonText.text = $"{answers[1]}"; ;   // �������� ������� �������
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //

        }
        if (PlayerPrefs.GetString("MathMode") == "/" && PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            taskText.fontSize = 120;

            numberOne = Random.Range(10, 100);    //���������� ���������� ���������� ���������� 
            numberTwo = Random.Range(1, 10);
            numberThree = Random.Range(1, 10);

            while (numberOne % numberTwo != 0 || numberOne / numberTwo % numberThree != 0 || numberOne == lastNumberOne || numberTwo == lastNumberTwo || numberOne == numberTwo || numberTwo == 1 || numberThree == 1)
            //������ ������� ������������� ��� ����������� ����������� �������
            {
                numberOne = Random.Range(10, 100);    //���������� ���������� ���������� ���������� 
                numberTwo = Random.Range(1, 10);    // 
                numberThree = Random.Range(1, 10);    // 
            }
            taskText.text = $"{numberOne} / {numberTwo} / {numberThree}";   // ����� ������ �� �����

            result = numberOne / numberTwo / numberThree;    // ������ ����������

            lastNumberOne = numberOne;
            lastNumberTwo = numberTwo;
            lastNumberThree = numberThree;

            numberOfRightAnswer = Random.Range(0, 3);   //��������� ����� ������� ������� ������

            for (int i = 0; i < answers.Length; i++) //����, ����������� ������ ������� ����������
            {

                var = Random.Range(-3, 3);    //������ ��������� ����������, ������� �����
                                              //��������� ������� ����� ���������� � ��������� �������
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                else answers[i] += var;                                     //������������� �����, ������� ������ var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[1] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[1] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[2] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[2] += var;                                     //������������� �����, ������� ������ var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //������ ��������� ����������, ������� �����
                                                //��������� ������� ����� ���������� � ��������� �������

                    answers[3] = result;    //����� �������� ������ ���������� � ������� ���������
                                            // ������������ ������ �� ��� � ����������

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //� ������, ���� ���������� var � ����� �  
                    else answers[3] += var;                                     //������������� �����, ������� ������ var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // ���� ���� ����� ��������� � �������� ������� ������
            }                                                           // ������ ������� ������������� ������ �����

            blueButtonText.text = $"{answers[0]}";    // ������������ ��������� ����������
            redButtonText.text = $"{answers[1]}"; ;   // �������� ������� �������
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //

        }
    }
    public void Start()
    {
        scoreText.text = "0"; //��������� ����� ��� �������
        Game(); // �������� ������� � �������
        Invoke("GameStart", 1);

        enemies = new[] { skeleton, ogre, stone }; // ������ ������
        enemiesIcons = new[] { skeletonIcon, ogreIcon, stoneIcon }; // ������ ������ � ������ ��������

        currentEnemy = Random.Range(0, 3); // ���������� ��������� ����
        lastEnemy = currentEnemy;

        enemies[currentEnemy].SetActive(true); // ������������ ����
        enemiesIcons[currentEnemy].SetActive(true); // � ��� ������
    }

    void GameStart()
    {
        energyBar.GetComponent<FightGame_EnergyBar>().enabled = true;
    }
}