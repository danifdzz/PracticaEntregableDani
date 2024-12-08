using PracticaEntregable.MVVM.Models;

namespace PracticaEntregable.Selectors
{
    public class TareaDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Tarea? tarea = item as Tarea;
            if (tarea != null&&tarea.importancia=="baja") 
                {
                Application.Current!.Resources.TryGetValue("BajaTemplate", out var BajaTemplate);
                return BajaTemplate as DataTemplate ?? new DataTemplate();
            }else if(tarea!=null&&tarea.importancia=="media"){
                Application.Current!.Resources.TryGetValue("MediaTemplate", out var MediaTemplate);
                return MediaTemplate as DataTemplate ?? new DataTemplate();
            }
            Application.Current!.Resources.TryGetValue("AltaTemplate", out var AltaTemplate);
            return AltaTemplate as DataTemplate ?? new DataTemplate();
        }
    }
}
