using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripHelper : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 1.0f)]
    public float mineWeight = 0.15f;
    public static int w = 12; // Ancho / Width
    public static int h = 22; // Alto / High
    public static Cell[,] cells = new Cell[w, h];

    public static void UncoverAllTheMines()
    {
        foreach (Cell c in cells)
        {
            if (c.hasMine)
            {
                c.LoadTexture(0);
            }
        }
    }

    public static bool HasMineAt(int x, int y)
    {
        if(x >= 0 && y >= 0 && x < w && y < h)
        {
            // Estoy dentro de la parrila
            Cell cell = cells[x, y];
            return cell.hasMine;
        }else
        {
            // Estoy fuera de la parrilla
            return false;
        }
    }

    public static int CountAdjacentMines(int x, int y)
    {
        int count = 0;

        if(HasMineAt(x - 1, y - 1)) count++;
        if(HasMineAt(x - 1, y    )) count++;
        if(HasMineAt(x - 1, y + 1)) count++;
        if(HasMineAt(x    , y - 1)) count++;
        if(HasMineAt(x    , y + 1)) count++;
        if(HasMineAt(x + 1, y - 1)) count++;
        if(HasMineAt(x + 1, y    )) count++;
        if(HasMineAt(x + 1, y + 1)) count++;

        return count;
    }

    public static void FloodFillUncover(int x, int y, bool [,] visited)
    {
        // Solo debemos proceder si el punto (x, y) es valido
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            // Si ya pasamos
            if (visited[x, y])
            {
                return;
            }
            // Si no la eh visitado
            // Cueto el número de minas adyacentes a mi posición (x, y)
            int adjacentMines = CountAdjacentMines(x, y);
            // Muestro en  la celda , el número de minas adyacentes (desde 0 hasta 8 máximo)
            cells[x, y].LoadTexture(adjacentMines);
            // Si tengo minas adyacentes, no puedo seguir destapando
            if(adjacentMines > 0)
            {
                return;
            }

            // Marco la actual como visitada
            visited[x, y] = true;

            FloodFillUncover(x - 1, y, visited);
            FloodFillUncover(x + 1, y, visited);
            FloodFillUncover(x, y - 1, visited);
            FloodFillUncover(x, y + 1, visited);

            FloodFillUncover(x - 1, y - 1, visited);
            FloodFillUncover(x - 1, y + 1, visited);
            FloodFillUncover(x + 1, y - 1, visited);
            FloodFillUncover(x + 1, y + 1, visited);
        }
    }

    public static bool HasTheGameEnded()
    {
        foreach (Cell cell in cells)
        {
            if (cell.IsCovered() && !cell.hasMine)
            {
                return false;
            }
        }
        return true;
    }
}
