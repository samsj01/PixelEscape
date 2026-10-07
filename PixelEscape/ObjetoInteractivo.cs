public abstract class ObjetoInteractivo
{
    protected int posicionX;
    protected int posicionY;

    protected int hitbox = 0;
    protected bool colision = false;

    public int PosicionX
{
    get
    {
        return posicionX;
    }
    protected set
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(PosicionX),
                "La posición X no puede ser negativa."
            );
        }

        posicionX = value;
    }
}

public int PosicionY
{
    get
    {
        return posicionY;
    }
    protected set
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(PosicionY),
                "La posición Y no puede ser negativa."
            );
        }

        posicionY = value;
    }

}
}