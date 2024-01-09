using ConfigDotNet.ObjectModel.Exceptions;
using static ConfigDotNet.ObjectModel.Exceptions.ExceptionMessagesConstants;

namespace ConfigDotNet.ObjectModel;

/// <summary>
/// Represent features for mapping configurations
/// </summary>
public static class ConfigurationMapper
{
    /// <summary>
    /// Mapping <see cref="IConfiguration{TKey,TValue}"/> to model
    /// </summary>
    /// <typeparam name="TModel">Type of model</typeparam>
    /// <typeparam name="TValue">Type of section value</typeparam>
    /// <param name="config">
    /// The instance of <see cref="IConfiguration{TKey,TValue}"/> from which the projection on
    /// the model will be made
    /// </param>
    /// <returns>Mapped model</returns>
    /// <exception cref="MappingException">Throw if model does not match the correct mapping implementation</exception>
    public static TModel MapToModel<TModel, TValue>(IConfiguration<string, TValue> config)
        where TModel : class
    {
        try
        {
            ModelValidator.Validate<TModel, TValue>();
            return new Model<TModel, TValue>().CreateInstance(config);
        }
        catch (InvalidModelException modelEx)
        {
            throw new MappingException(nameof(IConfiguration<string, TValue>), nameof(TModel), InvalidModelMapping, modelEx);
        }
    }

    /// <summary>
    /// Mapping instance of model to <see cref="Configuration{T}"/>
    /// </summary>
    /// <typeparam name="TModel">Type of model</typeparam>
    /// <typeparam name="TValue">Type of section value</typeparam>
    /// <param name="model">Instance of model that values of members (marked with the <see cref="SectionAttribute}"/>) 
    /// will be mapping to <see cref="Configuration{T}"/></param>
    /// <returns></returns>
    public static Configuration<TValue> MapToConfig<TModel, TValue>(TModel model)
    {
        try
        {
            ModelValidator.Validate<TModel, TValue>();
            Section<TValue>[] sections = new Model<TModel, TValue>().DestructOnSections(model);

            return new Configuration<TValue>(sections);
        }
        catch (InvalidModelException modelEx)
        {
            throw new MappingException(nameof(TModel), nameof(IConfiguration<string, TValue>), InvalidModelMapping, modelEx);
        }
    }
}
