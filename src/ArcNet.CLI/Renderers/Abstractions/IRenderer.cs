namespace ArcNet.CLI.Renderers.Abstractions;

public interface IRenderer<T>
{
    void Render(T model);
}