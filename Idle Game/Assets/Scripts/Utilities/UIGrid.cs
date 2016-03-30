﻿using UnityEngine;

/// <summary>
/// Cette classe permet de placer très simplement des éléments dans une grille.
/// </summary>
[System.Serializable]
public class UIGrid
{
    #region Fields
    /// <summary>
    /// Nombre d'élements par ligne.
    /// </summary>
    [SerializeField]
    private int numberOfElementsPerLine = 2;
    /// <summary>
    /// Position initiale de la grille.
    /// </summary>
    [SerializeField]
    private Vector2 startPosition = Vector2.zero;
    /// <summary>
    /// Décallage par colonne et par ligne. (x, y)
    /// </summary>
    [SerializeField]
    private Vector2 offset;
    #endregion

    #region Properties
    public int NumberOfElementsPerLine
    {
        get { return numberOfElementsPerLine; }
        private set { numberOfElementsPerLine = value; }
    }

    public Vector2 StartPosition
    {
        get { return startPosition; }
        private set { startPosition = value; }
    }

    public Vector2 Offset
    {
        get { return offset; }
        private set { offset = value; }
    }
    #endregion

    #region Behaviour Methods
    /// <summary>
    /// Récupère la colonne avec l'index de la case. (l'index 0 est le première élément)
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public int GetColumn(int index)
    {
        return index % this.numberOfElementsPerLine;
    }

    /// <summary>
    /// Récupére la ligne avec l'index de la case. (l'index 0 est le première élément)
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public int GetLine(int index)
    {
        return Mathf.CeilToInt(index / this.numberOfElementsPerLine);
    }

    /// <summary>
    /// Récupère la position horizontal (en x) de la case, il faut spécifier le numéro de colonne.
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    public float GetHorizontalPosition(int column)
    {
        return this.startPosition.x + this.offset.x * column;
    }

    /// <summary>
    /// Récupère la position vertical (en y) de la case, il faut spécifier le numéro de ligne.
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public float GetVerticalPosition(int line)
    {
        return this.startPosition.y + this.offset.y * line;
    }

    /// <summary>
    /// Récupère la position horizontal (en x) de la case. (l'index 0 est le première élément)
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public float GetHorizontalPositionThanksAnIndex(int index)
    {
        return this.startPosition.x + this.offset.x * this.GetColumn(index);
    }

    /// <summary>
    /// Récupère la position vertical (en y) de la case. (l'index 0 est le première élément)
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public float GetVerticalPositionThanksAnIndex(int index)
    {
        return this.startPosition.y + this.offset.y * this.GetLine(index);
    }

    /// <summary>
    /// Récupère la position d'un élément à la colonne "column" et la ligne "line".
    /// </summary>
    /// <param name="column"></param>
    /// <param name="line"></param>
    /// <returns></returns>
    public Vector2 GetPosition(int column, int line)
    {
        return new Vector2(this.GetHorizontalPosition(column), this.GetVerticalPosition(line));
    }

    /// <summary>
    /// Récupère la position de la case grâce à son index. (l'index 0 est le première élément)
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Vector2 GetPositionThanksAnIndex(int index)
    {
        return new Vector2(this.GetHorizontalPositionThanksAnIndex(index), this.GetVerticalPositionThanksAnIndex(index));
    }

    /// <summary>
    /// Récupère la différence de largeur (x) entre le début de la grille et la case trouvé à cette index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public float GetWidth(int index)
    {
        return this.offset.x * this.GetLine(index);
    }

    /// <summary>
    /// Récupère la différence de hauteur (y) entre le début de la grille et la case trouvé à cette index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public float GetHeight(int index)
    {
        return this.offset.y * this.GetLine(index);
    }
    #endregion
}