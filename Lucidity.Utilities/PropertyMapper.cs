using System;

namespace Lucidity.Utilities
{
    public static class PropertyMapper
    {
        public static TOutput MapMatchingProperties<TInput, TOutput>(TInput input) where TOutput : new()
        {
            return MapMatchingProperties<TInput, TOutput>(input, false);
        }

        public static TOutput MapMatchingProperties<TInput, TOutput>(TInput input, bool mapNullables) where TOutput : new()
        {
            var output = new TOutput();

            var inputType = typeof (TInput);
            var outputType = typeof (TOutput);

            foreach (var inputProperty in inputType.GetProperties())
            {
                var outputProperty = outputType.GetProperty(inputProperty.Name);

                if (outputProperty != null)
                {
                    if (inputProperty.PropertyType == outputProperty.PropertyType)
                    {
                        var inputValue = inputProperty.GetValue(input, null);
                        outputProperty.SetValue(output, inputValue, null);
                    }
                    //else if (mapNullables)
                    //{
                    //    //todo: finish this.
                    //    var inputIsNullable = inputProperty.PropertyType.IsGenericType &&
                    //                          inputProperty.PropertyType.GetGenericTypeDefinition() ==
                    //                          typeof (Nullable<>);

                    //    var outputIsNullable = outputProperty.PropertyType.IsGenericType &&
                    //                           outputProperty.PropertyType.GetGenericTypeDefinition() ==
                    //                           typeof (Nullable<>);

                    //    if (inputIsNullable && !outputIsNullable)
                    //    {
                    //        var underlyingInputType = inputProperty.PropertyType.GetGenericArguments()[0];
                    //        var a = inputProperty.GetValue(input, null);
                    //        var inputHasValue = (bool)inputProperty.GetValue(input, null);

                    //        if(inputHasValue)
                    //        {
                                
                    //        }
                    //    }
                    //}
                }
            }


            return output;
        }
    }
}
