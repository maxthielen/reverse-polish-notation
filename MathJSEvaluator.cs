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

    public string Help => "Enter expressions using normal notation, for instance to calculate:" + 
                          "\n\t2 + 3 * 4" +
                          "\n\tenter '2 + 3 * 4'" +
                          "\nenter (o)ps to see available operations";
    
    public string Description => "MathJSEvaluator";
}