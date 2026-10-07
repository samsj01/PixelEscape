internal abstract class ObjetoActivable : ObjetoInteractivo
{
    protected bool activo = false;

    public abstract bool Activar(Personaje escapista);
}