using Teshigoto.CompilationTests.Comparable;
using Teshigoto.CompilationTests.DummyTypes;
using Teshigoto.Generators;
using Teshigoto.UnitTests.Function.Comparable;

namespace Teshigoto.UnitTests.Function;

/// <summary>
/// Function tests of generated source by <see cref="ComparableGenerator"/>
/// </summary>
[TestClass]
public class ComparableGeneratorTests
{
    /// <summary>
    /// Asserts equality of <see cref="ClassWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void ClassWithOnePropertyAssertEquals()
    {
        ComparableTesterOneValue<ClassWithOneProperty>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="RecordClassWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithOnePropertyAssertEquals()
    {
        ComparableTesterOneValue<RecordClassWithOneProperty>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="RecordStructWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithOnePropertyAssertEquals()
    {
        ComparableTesterOneValue<RecordStructWithOneProperty>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="StructWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void StructWithOnePropertyAssertEquals()
    {
        ComparableTesterOneValue<StructWithOneProperty>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="ClassWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void ClassWithTwoPropertiesAssertEquals()
    {
        ComparableTesterTwoValues<ClassWithTwoProperties>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="RecordClassWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithTwoPropertiesAssertEquals()
    {
        ComparableTesterTwoValues<RecordClassWithTwoProperties>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="RecordStructWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithTwoPropertiesAssertEquals()
    {
        ComparableTesterTwoValues<RecordStructWithTwoProperties>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="StructWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void StructWithTwoPropertiesAssertEquals()
    {
        ComparableTesterTwoValues<StructWithTwoProperties>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="ClassWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void ClassWithThreePropertiesAssertEquals()
    {
        ComparableTesterThreeValues<ClassWithThreeProperties, DummyClass?>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="RecordClassWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithThreePropertiesAssertEquals()
    {
        ComparableTesterThreeValues<RecordClassWithThreeProperties, DummyRecordClass?>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="RecordStructWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithThreePropertiesAssertEquals()
    {
        ComparableTesterThreeValues<RecordStructWithThreeProperties, DummyRecordStruct?>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="StructWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void StructWithThreePropertiesAssertEquals()
    {
        ComparableTesterThreeValues<StructWithThreeProperties, DummyStruct?>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="ClassWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void ClassWithIgnoreAttributeAssertEquals()
    {
        ComparableTesterIgnoreValues<ClassWithIgnoreAttribute>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="ClassWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void ClassWithExplicitIgnoreAttributeAssertEquals()
    {
        ComparableTesterIgnoreValues<ClassWithExplicitIgnoreAttribute>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="RecordClassWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithIgnoreAttributeAssertEquals()
    {
        ComparableTesterIgnoreValues<RecordClassWithIgnoreAttribute>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="RecordClassWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithExplicitIgnoreAttributeAssertEquals()
    {
        ComparableTesterIgnoreValues<RecordClassWithExplicitIgnoreAttribute>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="RecordStructWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithIgnoreAttributeAssertEquals()
    {
        ComparableTesterIgnoreValues<RecordStructWithIgnoreAttribute>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="RecordStructWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithExplicitIgnoreAttributeAssertEquals()
    {
        ComparableTesterIgnoreValues<RecordStructWithExplicitIgnoreAttribute>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="StructWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void StructWithIgnoreAttributeAssertEquals()
    {
        ComparableTesterIgnoreValues<StructWithIgnoreAttribute>.AssertEquals();
    }

    /// <summary>
    /// Asserts equality of <see cref="StructWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void StructWithExplicitIgnoreAttributeAssertEquals()
    {
        ComparableTesterIgnoreValues<StructWithExplicitIgnoreAttribute>.AssertEquals();
    }

    /// <summary>
    /// Asserts greater comparability of <see cref="ClassWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void ClassWithOnePropertyAssertGreater()
    {
        ComparableTesterOneValue<ClassWithOneProperty>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="RecordClassWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithOnePropertyAssertGreater()
    {
        ComparableTesterOneValue<RecordClassWithOneProperty>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="RecordStructWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithOnePropertyAssertGreater()
    {
        ComparableTesterOneValue<RecordStructWithOneProperty>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="StructWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void StructWithOnePropertyAssertGreater()
    {
        ComparableTesterOneValue<StructWithOneProperty>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="ClassWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void ClassWithTwoPropertiesAssertGreater()
    {
        ComparableTesterTwoValues<ClassWithTwoProperties>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="RecordClassWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithTwoPropertiesAssertGreater()
    {
        ComparableTesterTwoValues<RecordClassWithTwoProperties>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="RecordStructWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithTwoPropertiesAssertGreater()
    {
        ComparableTesterTwoValues<RecordStructWithTwoProperties>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="StructWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void StructWithTwoPropertiesAssertGreater()
    {
        ComparableTesterTwoValues<StructWithTwoProperties>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="ClassWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void ClassWithThreePropertiesAssertGreater()
    {
        ComparableTesterThreeValues<ClassWithThreeProperties, DummyClass?>.AssertGreater(new DummyClass(0), new DummyClass(1));
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="RecordClassWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithThreePropertiesAssertGreater()
    {
        ComparableTesterThreeValues<RecordClassWithThreeProperties, DummyRecordClass?>.AssertGreater(new DummyRecordClass(0), new DummyRecordClass(1));
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="RecordStructWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithThreePropertiesAssertGreater()
    {
        ComparableTesterThreeValues<RecordStructWithThreeProperties, DummyRecordStruct?>.AssertGreater(new DummyRecordStruct(0), new DummyRecordStruct(1));
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="StructWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void StructWithThreePropertiesAssertGreater()
    {
        ComparableTesterThreeValues<StructWithThreeProperties, DummyStruct?>.AssertGreater(new DummyStruct(0), new DummyStruct(1));
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="ClassWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void ClassWithIgnoreAttributeAssertGreater()
    {
        ComparableTesterIgnoreValues<ClassWithIgnoreAttribute>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="ClassWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void ClassWithExplicitIgnoreAttributeAssertGreater()
    {
        ComparableTesterIgnoreValues<ClassWithExplicitIgnoreAttribute>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="RecordClassWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithIgnoreAttributeAssertGreater()
    {
        ComparableTesterIgnoreValues<RecordClassWithIgnoreAttribute>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="RecordClassWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithExplicitIgnoreAttributeAssertGreater()
    {
        ComparableTesterIgnoreValues<RecordClassWithExplicitIgnoreAttribute>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="RecordStructWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithIgnoreAttributeAssertGreater()
    {
        ComparableTesterIgnoreValues<RecordStructWithIgnoreAttribute>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="RecordStructWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithExplicitIgnoreAttributeAssertGreater()
    {
        ComparableTesterIgnoreValues<RecordStructWithExplicitIgnoreAttribute>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="StructWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void StructWithIgnoreAttributeAssertGreater()
    {
        ComparableTesterIgnoreValues<StructWithIgnoreAttribute>.AssertGreater();
    }

    /// <summary>
    /// Asserts greater comparability  of <see cref="StructWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void StructWithExplicitIgnoreAttributeAssertGreater()
    {
        ComparableTesterIgnoreValues<StructWithExplicitIgnoreAttribute>.AssertGreater();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="ClassWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void ClassWithOnePropertyAssertLess()
    {
        ComparableTesterOneValue<ClassWithOneProperty>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="RecordClassWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithOnePropertyAssertLess()
    {
        ComparableTesterOneValue<RecordClassWithOneProperty>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="RecordStructWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithOnePropertyAssertLess()
    {
        ComparableTesterOneValue<RecordStructWithOneProperty>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="StructWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void StructWithOnePropertyAssertLess()
    {
        ComparableTesterOneValue<StructWithOneProperty>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="ClassWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void ClassWithTwoPropertiesAssertLess()
    {
        ComparableTesterTwoValues<ClassWithTwoProperties>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="RecordClassWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithTwoPropertiesAssertLess()
    {
        ComparableTesterTwoValues<RecordClassWithTwoProperties>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="RecordStructWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithTwoPropertiesAssertLess()
    {
        ComparableTesterTwoValues<RecordStructWithTwoProperties>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="StructWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void StructWithTwoPropertiesAssertLess()
    {
        ComparableTesterTwoValues<StructWithTwoProperties>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="ClassWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void ClassWithThreePropertiesAssertLess()
    {
        ComparableTesterThreeValues<ClassWithThreeProperties, DummyClass?>.AssertLess(new DummyClass(0), new DummyClass(1));
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="RecordClassWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithThreePropertiesAssertLess()
    {
        ComparableTesterThreeValues<RecordClassWithThreeProperties, DummyRecordClass?>.AssertLess(new DummyRecordClass(0), new DummyRecordClass(1));
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="RecordStructWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithThreePropertiesAssertLess()
    {
        ComparableTesterThreeValues<RecordStructWithThreeProperties, DummyRecordStruct?>.AssertLess(new DummyRecordStruct(0), new DummyRecordStruct(1));
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="StructWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void StructWithThreePropertiesAssertLess()
    {
        ComparableTesterThreeValues<StructWithThreeProperties, DummyStruct?>.AssertLess(new DummyStruct(0), new DummyStruct(1));
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="ClassWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void ClassWithIgnoreAttributeAssertLess()
    {
        ComparableTesterIgnoreValues<ClassWithIgnoreAttribute>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="ClassWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void ClassWithExplicitIgnoreAttributeAssertLess()
    {
        ComparableTesterIgnoreValues<ClassWithExplicitIgnoreAttribute>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="RecordClassWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithIgnoreAttributeAssertLess()
    {
        ComparableTesterIgnoreValues<RecordClassWithIgnoreAttribute>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="RecordClassWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithExplicitIgnoreAttributeAssertLess()
    {
        ComparableTesterIgnoreValues<RecordClassWithExplicitIgnoreAttribute>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="RecordStructWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithIgnoreAttributeAssertLess()
    {
        ComparableTesterIgnoreValues<RecordStructWithIgnoreAttribute>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="RecordStructWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithExplicitIgnoreAttributeAssertLess()
    {
        ComparableTesterIgnoreValues<RecordStructWithExplicitIgnoreAttribute>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="StructWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void StructWithIgnoreAttributeAssertLess()
    {
        ComparableTesterIgnoreValues<StructWithIgnoreAttribute>.AssertLess();
    }

    /// <summary>
    /// Asserts less comparability  of <see cref="StructWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void StructWithExplicitIgnoreAttributeAssertLess()
    {
        ComparableTesterIgnoreValues<StructWithExplicitIgnoreAttribute>.AssertLess();
    }
}