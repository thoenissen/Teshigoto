using Teshigoto.CompilationTests.Comparable;
using Teshigoto.CompilationTests.DummyTypes;
using Teshigoto.Generators;

namespace Teshigoto.UnitTests.Function;

/// <summary>
/// Function tests of generated source by <see cref="ComparableGenerator"/>
/// </summary>
[TestClass]
public class ComparableGeneratorTests
{
    /// <summary>
    /// Equality tests
    /// </summary>
    [TestMethod]
    public void Equals()
    {
        ComparableTesterOneValue<ClassWithOneProperty>.AssertEquals();
        ComparableTesterOneValue<RecordClassWithOneProperty>.AssertEquals();
        ComparableTesterOneValue<RecordStructWithOneProperty>.AssertEquals();
        ComparableTesterOneValue<StructWithOneProperty>.AssertEquals();

        ComparableTesterTwoValues<ClassWithTwoProperties>.AssertEquals();
        ComparableTesterTwoValues<RecordClassWithTwoProperties>.AssertEquals();
        ComparableTesterTwoValues<RecordStructWithTwoProperties>.AssertEquals();
        ComparableTesterTwoValues<StructWithTwoProperties>.AssertEquals();

        ComparableTesterThreeValues<ClassWithThreeProperties, DummyClass?>.AssertEquals();
        ComparableTesterThreeValues<RecordClassWithThreeProperties, DummyRecordClass?>.AssertEquals();
        ComparableTesterThreeValues<RecordStructWithThreeProperties, DummyRecordStruct?>.AssertEquals();
        ComparableTesterThreeValues<StructWithThreeProperties, DummyStruct?>.AssertEquals();
    }

    /// <summary>
    /// Greater tests
    /// </summary>
    [TestMethod]
    public void Greater()
    {
        ComparableTesterOneValue<ClassWithOneProperty>.AssertGreater();
        ComparableTesterOneValue<RecordClassWithOneProperty>.AssertGreater();
        ComparableTesterOneValue<RecordStructWithOneProperty>.AssertGreater();
        ComparableTesterOneValue<StructWithOneProperty>.AssertGreater();

        ComparableTesterTwoValues<ClassWithTwoProperties>.AssertGreater();
        ComparableTesterTwoValues<RecordClassWithTwoProperties>.AssertGreater();
        ComparableTesterTwoValues<RecordStructWithTwoProperties>.AssertGreater();
        ComparableTesterTwoValues<StructWithTwoProperties>.AssertGreater();

        ComparableTesterThreeValues<ClassWithThreeProperties, DummyClass?>.AssertGreater(new DummyClass(0), new DummyClass(1));
        ComparableTesterThreeValues<RecordClassWithThreeProperties, DummyRecordClass?>.AssertGreater(new DummyRecordClass(0), new DummyRecordClass(1));
        ComparableTesterThreeValues<RecordStructWithThreeProperties, DummyRecordStruct?>.AssertGreater(new DummyRecordStruct(0), new DummyRecordStruct(1));
        ComparableTesterThreeValues<StructWithThreeProperties, DummyStruct?>.AssertGreater(new DummyStruct(0), new DummyStruct(1));
    }

    /// <summary>
    /// Less tests
    /// </summary>
    [TestMethod]
    public void Less()
    {
        ComparableTesterOneValue<ClassWithOneProperty>.AssertLess();
        ComparableTesterOneValue<RecordClassWithOneProperty>.AssertLess();
        ComparableTesterOneValue<RecordStructWithOneProperty>.AssertLess();
        ComparableTesterOneValue<StructWithOneProperty>.AssertLess();

        ComparableTesterTwoValues<ClassWithTwoProperties>.AssertLess();
        ComparableTesterTwoValues<RecordClassWithTwoProperties>.AssertLess();
        ComparableTesterTwoValues<RecordStructWithTwoProperties>.AssertLess();
        ComparableTesterTwoValues<StructWithTwoProperties>.AssertLess();

        ComparableTesterThreeValues<ClassWithThreeProperties, DummyClass?>.AssertLess(new DummyClass(0), new DummyClass(1));
        ComparableTesterThreeValues<RecordClassWithThreeProperties, DummyRecordClass?>.AssertLess(new DummyRecordClass(0), new DummyRecordClass(1));
        ComparableTesterThreeValues<RecordStructWithThreeProperties, DummyRecordStruct?>.AssertLess(new DummyRecordStruct(0), new DummyRecordStruct(1));
        ComparableTesterThreeValues<StructWithThreeProperties, DummyStruct?>.AssertLess(new DummyStruct(0), new DummyStruct(1));
    }
}