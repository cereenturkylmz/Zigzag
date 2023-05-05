using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [Header("Out Component")]
    [SerializeField] float speed;
    [SerializeField] Text scoreText, bestScoreText;
    [SerializeField] GameObject restartPanel, playGamePanel;

    [Header("Public Variable")]
    public GroundSpanner groundSpanner;
    public static bool isDead = true;
    public float hizlanmaZorlugu;

    Vector3 yon = Vector3.left;
    float score = 0f;
    float artisMiktari = 1f;
    int bestScore = 0;
    

    private void Start()
    {
        if(RestartGame.isRestart)
        {
            isDead = false;
            playGamePanel.SetActive(false);
        }

        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = "Best:" +bestScore.ToString();
    }

    void Update()
    {
        if(isDead)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
          if(yon.x == 0)
            {
                yon = Vector3.left;
            }
            else
            {
                yon = Vector3.back;
            }
        }

        if (transform.position.y < 0.1f)
        {
            isDead = true;
            
            Destroy(this.gameObject, 3f);
            if(bestScore < score)
            {
                bestScore = (int)score;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }

            restartPanel.SetActive(true);
            Destroy(this.gameObject, 3f);
            
        }
    }

    private void FixedUpdate()
    {
        if(isDead)
        {
            return;
        }

        Vector3 hareket = yon * speed * Time.deltaTime;
        speed += Time.deltaTime * hizlanmaZorlugu;
        transform.position += hareket; //hareket değerini sürekli pozisyona ekle

        score += artisMiktari * speed * Time.deltaTime;
     
        scoreText.text = "Score: "+((int)score).ToString();
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Zemin"))
        {
            StartCoroutine(YokEt(collision.gameObject));
            groundSpanner.ZeminOlustur();
        }
    }

   IEnumerator YokEt(GameObject zemin)
    {


        yield return new WaitForSeconds(0.2f);
        zemin.AddComponent<Rigidbody>();

        yield return new WaitForSeconds(0.4f);
        Destroy(zemin);   
    }

    public void PlayGame()
    {
        isDead = false;
        playGamePanel.SetActive(false);
    }


    










}//class
