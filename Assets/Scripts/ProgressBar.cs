using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("GameObject/UI/Linear Progress Bar")]
    public static void AddLinearProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/Linear Progress Bar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }

    [MenuItem("GameObject/UI/Rounded Progress Bar")]
    public static void AddRoundedProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/Rounded Progress Bar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }
#endif

    [SerializeField] private int maximum;
    [SerializeField] private int current;
    [SerializeField] private int minimum;
    [SerializeField] private Image mask;
    [SerializeField] private Image fill;
    [SerializeField] private Color color;

    void Start()
    {
        GetCurrentFill();
    }

    public void SetMaximum(int maximum)
    {
        this.maximum = maximum;
        GetCurrentFill();
    }

    public void SetCurrent(int current)
    {
        this.current = current;
        GetCurrentFill();
    }

    private void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;
        fill.color = color;
    }
}
