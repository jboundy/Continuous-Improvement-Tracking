using System;
using System.Reflection;
using System.Reflection.Emit;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ETL.ExcelToSql.BLL.Tests
{
    [TestClass]
    public class EtlClassBuilderTests
    {

        #region GetTypeBuilder
        [TestMethod]
        public void CanCreateTypeBuilderObjectStub()
        {
            var assemblyN = new AssemblyName("AFreakingAssemblyName");
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyN,
                AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("AFreakingModuleName");
            TypeBuilder tb = moduleBuilder.DefineType("AFreakingAssemblyName",
                TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass |
                TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout, null);

            tb.Should().BeOfType<TypeBuilder>();
        }

        [TestMethod]
        public void CanCreateTypeBuilderObjectMock()
        {
            var tb = EtlClassBuilderMock().GetTypeBuilder();
            tb.Should().BeOfType<TypeBuilder>();
        }

        [TestMethod]
        public void CanCreateTypeBuilderObjectIntegration()
        {
            var builder = new EtlClassBuilder("AssName", "MainName");
            var tb = builder.GetTypeBuilder();
            tb.Should().BeOfType<TypeBuilder>();
        }

        #endregion

#region CreateProperty
        [TestMethod]

        public void CanCreatePropertyStub()
        {
            var tb = GetTypeBuilderMock();
            tb.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName |
                                           MethodAttributes.RTSpecialName);
            string propertyName = "PropertyName";
            Type propertyType = Type.GetType("System.String", true);

            FieldBuilder fb = tb.DefineField(propertyName,propertyType, FieldAttributes.Public);
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

            fb.Should().NotBeNull();
        }

        [TestMethod]
        public void CanCreatePropertyMock()
        {
            CreatePropertyMock();
        }

#endregion

        private TypeBuilder GetTypeBuilderMock()
        {
            var typeBuilder = EtlClassBuilderMock().GetTypeBuilder();
            return typeBuilder;
        }

        private void CreatePropertyMock()
        {
            var tb = GetTypeBuilderMock();
            tb.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName |
                                           MethodAttributes.RTSpecialName);
            string propertyName = "PropertyName";
            Type propertyType = Type.GetType("System.String", true);
            EtlClassBuilderMock().CreateProperty(tb, propertyName, propertyType);
        }

        private EtlClassBuilder EtlClassBuilderMock()
        {
            var classBuilder = new EtlClassBuilder("AssemblyName", "MainModule");
            return classBuilder;
        }
    }
}
