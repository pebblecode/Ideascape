using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ideascape.Models
{
    public class NewIdeaSubmissionBinder : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor)
        {
            if (propertyDescriptor.PropertyType != typeof(ICollection<string>))
            {
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
                return;
            }

            var tagsString = bindingContext.ValueProvider.GetValue(propertyDescriptor.Name).AttemptedValue;

            var tags = tagsString.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            propertyDescriptor.SetValue(bindingContext.Model, tags);
        }
    }
}