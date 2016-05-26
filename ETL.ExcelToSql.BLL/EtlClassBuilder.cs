using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using ETL.ExcelToSql.DAL.Models;

namespace ETL.ExcelToSql.BLL
{
    public class EtlClassBuilder
    {
        private static string _assemblyName;
        private static string _mainModule;

        public EtlClassBuilder(string assemblyName, string mainModule)
        {
            _assemblyName = assemblyName;
            _mainModule = mainModule;
            //CreateNewClass();
        }

        //
        public void CreateNewClass(List<DynamicModel> fields)
        {
            var modelType = CompileResultType(fields);
            Activator.CreateInstance(modelType);
        }

        public Type CompileResultType(List<DynamicModel> fields)
        {
            TypeBuilder tb = GetTypeBuilder();

            tb.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName |
                                            MethodAttributes.RTSpecialName);
            foreach (var field in fields)
            {
                CreateProperty(tb, field.FieldName, field.FieldType);
            }

            Type objecType = tb.CreateType();
            return objecType;
        }

        public TypeBuilder GetTypeBuilder()
        {
            var assemblyN = new AssemblyName(_assemblyName);
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyN,
                AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(_mainModule);
            TypeBuilder tb = moduleBuilder.DefineType(_assemblyName,
                TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass |
                TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout, null);

            return tb;
        }

        public void CreateProperty(TypeBuilder tb, string propertyName, Type propertyType)
        {
            FieldBuilder fb = tb.DefineField(propertyName, propertyType, FieldAttributes.Public);
            PropertyBuilder propertyBuilder = tb.DefineProperty(propertyName, PropertyAttributes.HasDefault,
                propertyType, null);
            MethodBuilder getPropertyMethodBuilder = tb.DefineMethod("get_" + propertyName,
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType,
                Type.EmptyTypes);
            ILGenerator ilGenerator = getPropertyMethodBuilder.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldfld, fb);
            ilGenerator.Emit(OpCodes.Ret);

            MethodBuilder setPropertyMethodBuilder = tb.DefineMethod("set_" + propertyName,
                  MethodAttributes.Public |
                  MethodAttributes.SpecialName |
                  MethodAttributes.HideBySig,
                  null, new[] { propertyType });

            ILGenerator setIl = setPropertyMethodBuilder.GetILGenerator();
            Label modifyProperty = setIl.DefineLabel();
            Label exitSet = setIl.DefineLabel();

            setIl.MarkLabel(modifyProperty);
            setIl.Emit(OpCodes.Ldarg_0);
            setIl.Emit(OpCodes.Ldarg_1);
            setIl.Emit(OpCodes.Stfld, fb);

            setIl.Emit(OpCodes.Nop);
            setIl.MarkLabel(exitSet);
            setIl.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getPropertyMethodBuilder);
            propertyBuilder.SetSetMethod(setPropertyMethodBuilder);
        }
    }
}
