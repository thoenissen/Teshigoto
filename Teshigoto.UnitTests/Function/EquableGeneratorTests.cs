using Teshigoto.CompilationTests.DummyTypes;
using Teshigoto.CompilationTests.Equable;
using Teshigoto.Generators;
using Teshigoto.UnitTests.Function.Equable;

namespace Teshigoto.UnitTests.Function;

/// <summary>
/// Function tests of generated source by <see cref="EquableGenerator"/>
/// </summary>
[TestClass]
public class EquableGeneratorTests
{
    /// <summary>
    /// Asserts equality of <see cref="ClassWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void ClassWithOnePropertyAssertEquals() => EquableTesterOneValue<ClassWithOneProperty>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="RecordClassWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithOnePropertyAssertEquals() => EquableTesterOneValue<RecordClassWithOneProperty>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="RecordStructWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithOnePropertyAssertEquals() => EquableTesterOneValue<RecordStructWithOneProperty>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="StructWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void StructWithOnePropertyAssertEquals() => EquableTesterOneValue<StructWithOneProperty>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="ClassWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void ClassWithTwoPropertiesAssertEquals() => EquableTesterTwoValues<ClassWithTwoProperties>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="RecordClassWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithTwoPropertiesAssertEquals() => EquableTesterTwoValues<RecordClassWithTwoProperties>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="RecordStructWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithTwoPropertiesAssertEquals() => EquableTesterTwoValues<RecordStructWithTwoProperties>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="StructWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void StructWithTwoPropertiesAssertEquals() => EquableTesterTwoValues<StructWithTwoProperties>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="ClassWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void ClassWithThreePropertiesAssertEquals() => EquableTesterThreeValues<ClassWithThreeProperties, DummyClass?>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="RecordClassWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithThreePropertiesAssertEquals() => EquableTesterThreeValues<RecordClassWithThreeProperties, DummyRecordClass?>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="RecordStructWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithThreePropertiesAssertEquals() => EquableTesterThreeValues<RecordStructWithThreeProperties, DummyRecordStruct?>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="StructWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void StructWithThreePropertiesAssertEquals() => EquableTesterThreeValues<StructWithThreeProperties, DummyStruct?>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="ClassWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void ClassWithIgnoreAttributeAssertEquals() => EquableTesterIgnoreValues<ClassWithIgnoreAttribute>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="ClassWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void ClassWithExplicitIgnoreAttributeAssertEquals() => EquableTesterIgnoreValues<ClassWithExplicitIgnoreAttribute>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="RecordClassWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithIgnoreAttributeAssertEquals() => EquableTesterIgnoreValues<RecordClassWithIgnoreAttribute>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="RecordClassWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithExplicitIgnoreAttributeAssertEquals() => EquableTesterIgnoreValues<RecordClassWithExplicitIgnoreAttribute>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="RecordStructWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithIgnoreAttributeAssertEquals() => EquableTesterIgnoreValues<RecordStructWithIgnoreAttribute>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="RecordStructWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithExplicitIgnoreAttributeAssertEquals() => EquableTesterIgnoreValues<RecordStructWithExplicitIgnoreAttribute>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="StructWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void StructWithIgnoreAttributeAssertEquals() => EquableTesterIgnoreValues<StructWithIgnoreAttribute>.AssertEquals();

    /// <summary>
    /// Asserts equality of <see cref="StructWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void StructWithExplicitIgnoreAttributeAssertEquals() => EquableTesterIgnoreValues<StructWithExplicitIgnoreAttribute>.AssertEquals();

    /// <summary>
    /// Asserts not equality of <see cref="ClassWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void ClassWithOnePropertyAssertNotEquals() => EquableTesterOneValue<ClassWithOneProperty>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="RecordClassWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithOnePropertyAssertNotEquals() => EquableTesterOneValue<RecordClassWithOneProperty>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="RecordStructWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithOnePropertyAssertNotEquals() => EquableTesterOneValue<RecordStructWithOneProperty>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="StructWithOneProperty"/>
    /// </summary>
    [TestMethod]
    public void StructWithOnePropertyAssertNotEquals() => EquableTesterOneValue<StructWithOneProperty>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="ClassWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void ClassWithTwoPropertiesAssertNotEquals() => EquableTesterTwoValues<ClassWithTwoProperties>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="RecordClassWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithTwoPropertiesAssertNotEquals() => EquableTesterTwoValues<RecordClassWithTwoProperties>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="RecordStructWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithTwoPropertiesAssertNotEquals() => EquableTesterTwoValues<RecordStructWithTwoProperties>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="StructWithTwoProperties"/>
    /// </summary>
    [TestMethod]
    public void StructWithTwoPropertiesAssertNotEquals() => EquableTesterTwoValues<StructWithTwoProperties>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="ClassWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void ClassWithThreePropertiesAssertNotEquals() => EquableTesterThreeValues<ClassWithThreeProperties, DummyClass?>.AssertNotEquals(new DummyClass(0), new DummyClass(1));

    /// <summary>
    /// Asserts not equality  of <see cref="RecordClassWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithThreePropertiesAssertNotEquals() => EquableTesterThreeValues<RecordClassWithThreeProperties, DummyRecordClass?>.AssertNotEquals(new DummyRecordClass(0), new DummyRecordClass(1));

    /// <summary>
    /// Asserts not equality  of <see cref="RecordStructWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithThreePropertiesAssertNotEquals() => EquableTesterThreeValues<RecordStructWithThreeProperties, DummyRecordStruct?>.AssertNotEquals(new DummyRecordStruct(0), new DummyRecordStruct(1));

    /// <summary>
    /// Asserts not equality  of <see cref="StructWithThreeProperties"/>
    /// </summary>
    [TestMethod]
    public void StructWithThreePropertiesAssertNotEquals() => EquableTesterThreeValues<StructWithThreeProperties, DummyStruct?>.AssertNotEquals(new DummyStruct(0), new DummyStruct(1));

    /// <summary>
    /// Asserts not equality  of <see cref="ClassWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void ClassWithIgnoreAttributeAssertNotEquals() => EquableTesterIgnoreValues<ClassWithIgnoreAttribute>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="ClassWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void ClassWithExplicitIgnoreAttributeAssertNotEquals() => EquableTesterIgnoreValues<ClassWithExplicitIgnoreAttribute>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="RecordClassWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithIgnoreAttributeAssertNotEquals() => EquableTesterIgnoreValues<RecordClassWithIgnoreAttribute>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="RecordClassWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithExplicitIgnoreAttributeAssertNotEquals() => EquableTesterIgnoreValues<RecordClassWithExplicitIgnoreAttribute>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="RecordStructWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithIgnoreAttributeAssertNotEquals() => EquableTesterIgnoreValues<RecordStructWithIgnoreAttribute>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="RecordStructWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithExplicitIgnoreAttributeAssertNotEquals() => EquableTesterIgnoreValues<RecordStructWithExplicitIgnoreAttribute>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="StructWithIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void StructWithIgnoreAttributeAssertNotEquals() => EquableTesterIgnoreValues<StructWithIgnoreAttribute>.AssertNotEquals();

    /// <summary>
    /// Asserts not equality  of <see cref="StructWithExplicitIgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void StructWithExplicitIgnoreAttributeAssertNotEquals() => EquableTesterIgnoreValues<StructWithExplicitIgnoreAttribute>.AssertNotEquals();
}