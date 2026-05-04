namespace ArcNet.Application.Interfaces;

public interface IBuffer
{
    void BufferContent(IEnumerable<string> content);
    IEnumerable<string> UseBufferContent();
}