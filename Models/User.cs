using System.Reflection;

namespace WebApplication8_PDF.Models;

public class User
{
    public string FullName { get; set; } = null!;
    public string Login { get; set; } = null!;
    public Gender? Gender { get; set; }
    public DateTime? Date { get; set; }
    public string Email { get; set; } = null!;
    public string Site { get; set; } = null!;
    public string Card { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Message { get; set; } = null!;

    public Dictionary<string, string?> ToDict()
    {
        return GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
          .ToDictionary(prop => prop.Name, prop =>
          {
              if (prop.GetValue(this, null) is DateTime date)
              {
                  return date.ToShortDateString();
              }
              return prop.GetValue(this, null)?.ToString();
          });
    }
}
