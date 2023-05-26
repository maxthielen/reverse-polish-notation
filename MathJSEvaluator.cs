using System.Web;

namespace reverse_polish_notation;

public class MathJsEvaluator : IExpressionEvaluator
{
    private HttpClient _client = new();
    
    public EvaluationResult Evaluate(string expression)
    {
        string request = "https://api.mathjs.org/v4/?expr=" + HttpUtility.UrlEncode(expression);
        var task = _client.GetAsync(request).Result;
        var response = task.Content.ReadAsStringAsync().Result;
        
        if (Double.TryParse(response, out var num)) return new EvaluationResult(result: num);
        throw new Exception(response);
    }

    public IList<string> Help => new List<string> { "nothing yet" };
    
    public string Description => "MathJSEvaluator";
}