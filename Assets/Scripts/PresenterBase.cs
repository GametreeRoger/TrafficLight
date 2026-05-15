using System.Collections;
using System.Threading.Tasks;

public abstract class PresenterBase : IPresenter
{
    public abstract Task LoadAsync(IPrepareData data);
    public abstract IEnumerator Run();
    public virtual void OnShow() { }
    public virtual void OnHide() { }

    protected void Hide() => UIController.Get.Close(GetType());
}
