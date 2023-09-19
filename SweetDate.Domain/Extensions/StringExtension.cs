using System.Text;

namespace SweetDate.Domain.Extensions;

public static class StringExtension
{
    public static string Join(this List<string> text) 
    {
        var stringBuilder = new StringBuilder();
            
        for (int i = 0; i < text.Count; i++)
        {
            stringBuilder.Append($"{i + 1}: {text[i]} ");
        }
            
        return stringBuilder.ToString();
    }
}