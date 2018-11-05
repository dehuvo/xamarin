using Xamarin.Forms;

namespace Selector {
  public class PersonDataTemplateSelector : DataTemplateSelector {
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
      return ((Person) item).DateOfBirth.Year >= 1980 ? ValidTemplate : InvalidTemplate;
    }
    public DataTemplate   ValidTemplate { get; set; }
    public DataTemplate InvalidTemplate { get; set; }
  }
}