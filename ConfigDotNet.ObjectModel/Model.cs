// Licensed to the HardDriveS under one or more agreements.
// The HardDriveS licenses this file to you under the MIT license.

using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;

namespace ConfigDotNet.ObjectModel
{
    /// <summary>
    /// A class storing members with the <see cref="SectionAttribute"/> attribute of 
    /// a type marked with the <see cref="ConfigurationModelAttribute{T}"/> attribute
    /// </summary>
    /// <typeparam name="TModel">Type of model</typeparam>
    /// <typeparam name="TValue">Type of section value</typeparam>
    internal sealed class Model<TModel, TValue>
    {
        internal ImmutableList<FieldInfo> FieldSections { get; init; }
        internal ImmutableList<PropertyInfo> PropsSections { get; init; }

        internal Model()
        {
            var modelType = typeof(TModel);

            FieldSections = (from field in modelType.GetFields()
                where field.FieldType == typeof(TValue) &&
                      !field.IsInitOnly &&
                      field.GetCustomAttribute(typeof(SectionAttribute)) is not null
                select field).ToImmutableList();

            PropsSections = (from prop in modelType.GetProperties()
                where prop.PropertyType == typeof(TValue) &&
                      prop.CanWrite &&
                      prop.GetCustomAttribute(typeof(SectionAttribute)) is not null
                select prop).ToImmutableList();
        }

        /// <summary>
        /// Creates an instance of a model by filling it with sections from a class derived from <see cref="IConfiguration{TKey, TValue}"/>
        /// </summary>
        /// <param name="config">The configuration according to which the model will be created</param>
        /// <returns>A reference to the new model</returns>
        internal TModel CreateInstance(IConfiguration<string, TValue> config)
        {
            var model = Activator.CreateInstance<TModel>();

            foreach (var section in config)
            {
                GetFieldBySectionKey(section.Key)?.SetValue(model, section.Value);
                GetPropBySectionKey(section.Key)?.SetValue(model, section.Value);
            }

            return model!;
        }

        private FieldInfo? GetFieldBySectionKey(string sectionKey)
        {
            return FieldSections.FirstOrDefault(fld =>
                   GetSectionAttributeKey(fld) == sectionKey);
        }

        private PropertyInfo? GetPropBySectionKey(string sectionKey)
        {
            return PropsSections.FirstOrDefault(prop =>
                   GetSectionAttributeKey(prop) == sectionKey);
        }

        /// <summary>
        /// Destruct instance of model into <see cref="Section{T}"/>[]
        /// </summary>
        /// <param name="instance">Instance of model</param>
        /// <returns>A reference to the <see cref="Section{T}"/>[]</returns>
        internal Section<TValue>[] DestructOnSections(TModel instance)
        {
            Debug.Assert(instance != null);

            List<Section<TValue>> sections =
            [
                .. FieldSections.Select(f => ParseMemberToSection(f, () => (TValue)f.GetValue(instance)!)),
                .. PropsSections.Select(p => ParseMemberToSection(p, () => (TValue)p.GetValue(instance)!)),
            ];

            return sections.ToArray();
        }

        private Section<TValue> ParseMemberToSection<T>(T member, Func<TValue> getValue)
            where T : MemberInfo
        {
            string key = GetSectionAttributeKey(member);

            return new Section<TValue>(key, getValue());
        }

        private string GetSectionAttributeKey(MemberInfo member) => ((SectionAttribute?)member.GetCustomAttribute(typeof(SectionAttribute)))!.SectionName ?? null!;
    }


    /// <summary>
    /// Validator for <see cref="Model{TModel, TValue}"/>
    /// </summary>
    internal static class ModelValidator
    {
        /// <summary>
        /// Throws exceptions if the model not valid
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="Exceptions.InvalidModelException"/>
        internal static void Validate<TModel, TValue>()
        {
            Type modelType = typeof(TModel);

            ModelThrowHelper.ThrowIfModelNotHaveParameterlessConstructor(modelType);
            ModelThrowHelper.ThrowIfModelNotHaveConfigurationModelAttribute<TValue>(modelType);
        }
    }
}
