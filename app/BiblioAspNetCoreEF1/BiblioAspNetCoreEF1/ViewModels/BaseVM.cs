using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioAspNetCoreEF1.ViewModels
{
    public static class BaseVM
    {
        public static void CopyToTargeFromSource<TTarget,TSource>(TTarget target, TSource source)
        {
            var targetType = typeof(TTarget);
            var sourceType = typeof(TSource);
            var sourceProps = sourceType.GetProperties();
            foreach (var prop in sourceProps)
            {
                targetType.GetProperty(prop.Name).SetValue(target, sourceType.GetProperty(prop.Name).GetValue(source));
            }
        }
    }
}
