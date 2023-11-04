using Makeup_1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Makeup_1.ModelBinders
{
    public class CartModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(Cart) ? new CartModelBinder() : null;
        }
    }
}
