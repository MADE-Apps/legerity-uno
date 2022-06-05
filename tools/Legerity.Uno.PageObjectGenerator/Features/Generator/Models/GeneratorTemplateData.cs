namespace Legerity.Uno.Features.Generator.Models;

using System.Collections.Generic;

internal class GeneratorTemplateData
{
    public GeneratorTemplateData(string ns, string page, string baseElementType)
    {
        this.Namespace = ns;
        this.Page = page;
        this.Type = baseElementType;
    }

    public string Page { get; set; }

    public string Type { get; set; }

    public string Namespace { get; set; }
    
    public List<UiElement> Elements { get; set; } = new();

    public override string ToString()
    {
        return $"[Page] {this.Page}";
    }
}