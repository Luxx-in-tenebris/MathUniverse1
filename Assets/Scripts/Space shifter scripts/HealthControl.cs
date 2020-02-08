// HealthControl – управляет очками здоровья каждого юнита и их отображением на экране в виде не интерактивного «ползунка».
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    public Animator animator;                   //позволяет руководить набором анимаций для персонажа и переключаться между ними когда выполняется некоторое условие
    public float startingHealth;                //начальные очки здоровья
    public Slider slider;                       //"ползунок" на который будет выводится текущее число очков здоровья
    public Image fillimage;                     //то чем будет заполняться ползунок
    public Color fullHealthColor = Color.green; //цвет полного здоровья
    public Color zeroHealthColor = Color.red;   //цвет нулевого здоровья

    private float currentHealth;                //текущее число очков здоровья
    private bool dead;                          //умер или нет юнит?

    //вызывается  один раз в первом кадре до функции Update
    void Start()
    {
        //текущее здоровье:= начальному
        currentHealth = startingHealth;
        dead = false;
        //выводим на полузнок текущее число HP     
        SetHealthUI();
    }//end Start()

     //изменение текущего количества хп
    public void TakeDamage(float amount)
    {
        //отражаем на текущем здоровье нанесенный урон
        currentHealth -= amount;
        //выводим на полузнок текущее число HP 
        SetHealthUI();
        //если текущее здоровье меньше 0, то 
        if(currentHealth<=0f&&!dead)
        {
            //смерть
            OnDeath();
        }//end if
    }//end TakeDamage(float amount)

    //выводим на полузнок текущее число HP
    void SetHealthUI()
    {
        slider.value = currentHealth;
        //Изменяем цвет изображения на ползунке с помощью линейной интерполяции между зеленым 
        //и красным в зависимости от отношения текущего количества ХП и начального;     
        fillimage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth / startingHealth);

    }//end SetHealthUI()

    //если объект умер 
    void OnDeath()
    {
        dead = true;
        //анимация смерти
        animator.SetTrigger("Death"); 
        //уничтожаем объект    
        Destroy(gameObject,2);
    }//end OnDeath()

    //возвращает текущее HP
    public float getCurrentHp()
    {
        return currentHealth;
    } //end getCurrentHp()
}//end class

//__________________END OF FILE____________________________