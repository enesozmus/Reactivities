namespace Udemy.Application.Test;

public class JwtSettings
{
     public string Secret { get; set; }
     public TimeSpan TokenLifetime { get; set; }
}
