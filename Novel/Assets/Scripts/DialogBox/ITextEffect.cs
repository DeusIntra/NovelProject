using TMPro;

/// <summary>
/// Text effects apply while text is on screen
/// </summary>
public interface ITextEffect
{
    void Apply(TMP_Text text);
    void Terminate();
}
