using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cell : MonoBehaviour
{
    public bool hasMine;

    public Sprite[] emptyTextures;
    public Sprite mineTexture;

    // Start is called before the first frame update
    void Start()
    {
        GripHelper helper = GameObject.Find("Big Panel").GetComponent<GripHelper>();
        hasMine = (Random.value < helper.mineWeight); // 15% de probabilidad
        //LoadTexture(1);
        int x = (int)this.transform.position.x; // Casting
        int y = (int) this.transform.parent.transform.position.y; // Casting

        GripHelper.cells[x, y] = this;
    }

    public void LoadTexture(int adjacentCount)
    {
        if(hasMine)
        {
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        }else
        {
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
        }
    }

    // Método de ayuda para saber si la celda esta tapada
    public bool IsCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "tapado";
    }

    private void OnMouseUpAsButton() {
        if(hasMine)
        { // Game Over
            GripHelper.UncoverAllTheMines();
            Debug.Log("You lose!!");
            Invoke("ReturnToMainMenu", 3f);
        }else
        {
            // Cambiar la textura e la celda
            int x = (int)this.transform.position.x;
            int y = (int)this.transform.parent.transform.position.y;
            LoadTexture(GripHelper.CountAdjacentMines(x, y));
            // Descubrir toda el área sin minas alrededor de la celda abierta
            GripHelper.FloodFillUncover(x, y, new bool[GripHelper.w, GripHelper.h]);
            // Comprobar si el juego ha terminado
            if (GripHelper.HasTheGameEnded())
            {
                Debug.Log("Fin de la partida: You Win!!");
                Invoke("ReturnToMainMenu", 3f);
            }
        }
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
