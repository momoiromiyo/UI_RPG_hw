using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    [SerializeField] private TMP_Text playerHealthText, enemyHealthText, shieldText, powerupText, healText;
    [SerializeField] private TMP_Text youLostText, youWonText;
    [SerializeField] private Button attackButton, healButton, powerupButton;
    [SerializeField] private Toggle shieldToggle;

    private int shieldHP = 30;
    private int powerupCount = 3;
    private int healCount = 1;
    private bool buffActive = false;
    private bool gameOver = false;

    private void Start()
    {
        youLostText.gameObject.SetActive(false);
        youWonText.gameObject.SetActive(false);

        attackButton.onClick.AddListener(DoRound);
        healButton.onClick.AddListener(Heal);
        powerupButton.onClick.AddListener(UsePowerup);
        shieldToggle.onValueChanged.AddListener(delegate { UpdateUI(); });

        UpdateUI();
    }

    private void UpdateUI()
    {
        playerHealthText.text = player.GetHealth().ToString();
        enemyHealthText.text = enemy.GetHealth().ToString();
        shieldText.text = shieldHP.ToString();
        powerupText.text = powerupCount.ToString();
        healText.text = healCount.ToString();

        attackButton.interactable = !gameOver;
        healButton.interactable = healCount > 0 && !gameOver;
        powerupButton.interactable = powerupCount > 0 && !gameOver;
    }

    private void DoRound()
    {
        if (gameOver) return;

        int damage = player.Attack();
        if (buffActive) damage += 5;
        enemy.GetHit(damage);

        if (enemy.IsDead())
        {
            ShowResult("You Won!");
            return;
        }

        int enemyDamage = Random.Range(1, 8);
        if (shieldToggle.isOn && shieldHP > 0)
        {
            shieldHP -= enemyDamage;
            if (shieldHP <= 0) shieldToggle.isOn = false;
            enemyDamage = 0;
        }
        player.GetHit(enemyDamage);

        if (player.IsDead())
        {
            ShowResult("You Lost!");
        }

        UpdateUI();
    }

    private void Heal()
    {
        if (healCount > 0 && !gameOver)
        {
            player.RestoreHealth(20);
            healCount--;
            UpdateUI();
        }
    }

    private void UsePowerup()
    {
        if (powerupCount > 0 && !gameOver)
        {
            buffActive = true;
            powerupCount--;
            UpdateUI();
        }
    }

    private void ShowResult(string message)
    {
        gameOver = true;
        youLostText.gameObject.SetActive(message == "You Lost!");
        youWonText.gameObject.SetActive(message == "You Won!");
        UpdateUI();
    }
}
