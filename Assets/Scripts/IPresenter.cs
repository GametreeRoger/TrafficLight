using System.Collections;
using System.Threading.Tasks;

public interface IPresenter
{
    Task LoadAsync(IPrepareData data);
    IEnumerator Run();
    void OnShow() { }
    void OnHide() { }
}
